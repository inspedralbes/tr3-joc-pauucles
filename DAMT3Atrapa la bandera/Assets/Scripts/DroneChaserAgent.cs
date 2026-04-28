using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

/// <summary>
/// DroneChaserAgent: Un agente entrenado para perseguir al jugador, esquivar límites
/// y aplicar un castigo (debuff) al contacto.
/// </summary>
public class DroneChaserAgent : Agent
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 8f;
    public string targetTag = "Player";
    public float detectionRadius = 20f;
    
    [Header("Estat Actual (Debug)")]
    public Transform targetPlayer;
    public bool playerInSight = false;
    public DroneTrainingManager trainingManager;
    
    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private float lastDistanceToTarget;
    private float episodeTimer = 0f;
    private float maxEpisodeTime = 90f; // Tiempo máximo por episodio para evitar bucles infinitos

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        
        if (rb != null)
        {
            rb.gravityScale = 0; 
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            rb.freezeRotation = true;
        }
        
        // Asegurar que tenemos el DecisionRequester para que el agente tome decisiones
        if (GetComponent<DecisionRequester>() == null)
        {
            DecisionRequester dr = gameObject.AddComponent<DecisionRequester>();
            dr.DecisionPeriod = 5;
        }
    }

    public override void OnEpisodeBegin()
    {
        episodeTimer = 0f;

        // Si tenemos un manager y estamos entrenando, dejamos que él maneje el posicionamiento
        if (trainingManager != null && Academy.Instance.IsCommunicatorOn)
        {
            trainingManager.ResetEpisode();
        }

        FindTargetPlayer();
        
        if (targetPlayer != null)
        {
            lastDistanceToTarget = Vector2.Distance(transform.position, targetPlayer.position);
        }
        else
        {
            lastDistanceToTarget = 0f;
        }
    }

    /// <summary>
    /// Encuentra al jugador más cercano que no esté en un minijuego (frozen).
    /// </summary>
    private void FindTargetPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(targetTag);
        float minDistance = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject p in players)
        {
            // Omitir si es un clon remoto sin el script Player principal o si está en combate/congelado
            Player scriptP = p.GetComponent<Player>();
            if (scriptP == null || scriptP.isFrozen || !scriptP.potMoure) continue; 

            float dist = Vector2.Distance(transform.position, p.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = p.transform;
            }
        }
        targetPlayer = closest;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // 1. Posición propia (2 valores)
        sensor.AddObservation(transform.position.x);
        sensor.AddObservation(transform.position.y);

        // 2. Posición del objetivo (2 valores) + Distancia (1 valor)
        if (targetPlayer != null)
        {
            sensor.AddObservation(targetPlayer.position.x);
            sensor.AddObservation(targetPlayer.position.y);
            sensor.AddObservation(Vector2.Distance(transform.position, targetPlayer.position));
        }
        else
        {
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
        }

        // 3. Velocidad propia (2 valores) + Estado de visión (1 valor) = Total 8
        Vector2 vel = rb != null ? rb.linearVelocity : Vector2.zero;
        sensor.AddObservation(vel.x);
        sensor.AddObservation(vel.y);
        sensor.AddObservation(playerInSight ? 1f : 0f); 
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Si el objetivo está en combate (frozen o no puede moverse), el dron se detiene
        if (targetPlayer != null)
        {
            Player scriptP = targetPlayer.GetComponent<Player>();
            if (scriptP != null && (scriptP.isFrozen || !scriptP.potMoure))
            {
                if (rb != null) rb.linearVelocity = Vector2.zero;
                return;
            }
        }

        // Movimiento continuo en X e Y
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(moveX, moveY) * moveSpeed;
        }

        // Re-evaluar target periódicamente (cada step de acción)
        FindTargetPlayer();

        if (targetPlayer != null)
        {
            float distance = Vector2.Distance(transform.position, targetPlayer.position);
            
            // --- RECOMPENSAS ---

            // 1. Recompensa por acercarse (shaping)
            if (distance < lastDistanceToTarget) 
            {
                AddReward(0.01f);
            }
            else 
            {
                AddReward(-0.015f); // Castigo ligeramente mayor por alejarse
            }

            // 2. Recompensa por detección visual
            if (distance < detectionRadius)
            {
                AddReward(0.005f);
                playerInSight = true;
            }
            else
            {
                playerInSight = false;
            }

            lastDistanceToTarget = distance;
        }

        // Penalización existencial para incentivar la rapidez
        AddReward(-0.0005f);
        
        episodeTimer += Time.fixedDeltaTime;
        if (episodeTimer > maxEpisodeTime)
        {
            Debug.Log("[DRON-TRAINING] Tiempo agotado sin capturar al jugador.");
            EndEpisode();
        }
    }

    private void FixedUpdate()
    {
        // --- SEGURO DE LÍMITES (FAILSAFE) ---
        if (trainingManager != null && trainingManager.trainingArea != null && trainingManager.isTrainingMode)
        {
            if (!trainingManager.trainingArea.bounds.Contains(transform.position))
            {
                Debug.LogWarning("[DRON-TRAINING] ¡Dron fuera de límites! Reset automático.");
                SetReward(-5.0f);
                EndEpisode();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ÉXITO: Tocar al jugador
        if (other.CompareTag(targetTag))
        {
            Player p = other.GetComponent<Player>();
            if (p != null && !p.isFrozen)
            {
                Debug.Log($"[DRON] ¡Jugador {p.username} capturado!");
                p.RecibirAtaqueDron(); // Aplicar vidas=0, teleport y debuff
                
                SetReward(10.0f); // Gran recompensa por completar el objetivo
                EndEpisode();
            }
        }

        // FRACASO: Tocar límites del mapa (Boundary)
        if (other.CompareTag("DroneBoundary"))
        {
            Debug.Log("[DRON-TRAINING] ¡Límite alcanzado! Castigo aplicado.");
            SetReward(-5.0f);
            
            // Opcional: Teletransportar al inicio o simplemente terminar
            transform.position = initialPosition; 
            EndEpisode();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Castigo por chocar contra paredes u obstáculos físicos
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            AddReward(-0.5f);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Control manual con flechas o WASD para pruebas
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxisRaw("Horizontal");
        continuousActionsOut[1] = Input.GetAxisRaw("Vertical");
    }
}

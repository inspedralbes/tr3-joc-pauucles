using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

/// <summary>
/// MiniDinoAgent: Un agente sencillo que aprende a perseguir al jugador que tiene la bandera.
/// </summary>
public class MiniDinoAgent : Agent
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 6f;
    public string targetTag = "Player";
    
    [Header("Estat Actual (Debug)")]
    public Transform targetPlayer;
    public float distanceToTarget;
    
    private Rigidbody2D rb;
    private float lastDistanceToTarget;
    private Vector3 initialPosition;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        
        if (rb != null)
        {
            rb.gravityScale = 0; 
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }

    public override void OnEpisodeBegin()
    {
        // Opcional: Resetejar la posició al començar si estem en un entorn d'entrenament tancat
        // transform.position = initialPosition;
        
        FindTargetPlayer();
        
        if (targetPlayer != null)
        {
            lastDistanceToTarget = Vector2.Distance(transform.position, targetPlayer.position);
        }
    }

    /// <summary>
    /// Busca dinàmicament qui és el jugador a perseguir.
    /// Prioritza el jugador que porta la bandera.
    /// </summary>
    private void FindTargetPlayer()
    {
        // 1. Intentem trobar qui porta la bandera (mare dinosaure)
        Bandera[] banderas = Object.FindObjectsByType<Bandera>(FindObjectsSortMode.None);
        foreach (var b in banderas)
        {
            if (b.transform.parent != null && b.transform.parent.CompareTag(targetTag))
            {
                targetPlayer = b.transform.parent;
                return;
            }
        }

        // 2. Si ningú la porta, busquem el jugador més proper per mantenir l'agent actiu
        GameObject[] players = GameObject.FindGameObjectsWithTag(targetTag);
        float minDistance = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject p in players)
        {
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
        // Observacions (El que veu l'agent):
        
        // 1. La seva pròpia posició (X, Y) - 2 valors
        sensor.AddObservation(transform.position.x);
        sensor.AddObservation(transform.position.y);

        // 2. La posició del jugador objectiu (X, Y) - 2 valors
        if (targetPlayer != null)
        {
            sensor.AddObservation(targetPlayer.position.x);
            sensor.AddObservation(targetPlayer.position.y);
        }
        else
        {
            // Si no hi ha target, s'observa a si mateix (posició neutra)
            sensor.AddObservation(transform.position.x);
            sensor.AddObservation(transform.position.y);
        }

        // 3. La seva pròpia velocitat - 2 valors
        Vector2 vel = rb != null ? rb.linearVelocity : Vector2.zero;
        sensor.AddObservation(vel.x);
        sensor.AddObservation(vel.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Accions (El que fa l'agent):
        // Moure's en l'eix X (esquerra/dreta) i en l'eix Y (amunt/avall)
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(moveX, moveY) * moveSpeed;
        }

        // Re-avaluem el target
        FindTargetPlayer();

        if (targetPlayer != null)
        {
            distanceToTarget = Vector2.Distance(transform.position, targetPlayer.position);

            // --- SISTEMA DE RECOMPENSES ---

            // 1. Recompensa per reduir la distància
            if (distanceToTarget < lastDistanceToTarget)
            {
                AddReward(0.1f);
            }
            else
            {
                // Càstig per allunyar-se
                AddReward(-0.1f);
            }

            // 2. Recompensa gran per atrapar al jugador
            if (distanceToTarget < 1.0f)
            {
                SetReward(1.0f);
                // Si estem entrenant, podem finalitzar l'episodi per començar un de nou
                // EndEpisode(); 
            }

            lastDistanceToTarget = distanceToTarget;
        }
        
        // Penalització per temps (molt petita) per incentivar que sigui ràpid
        AddReward(-0.001f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Permet controlar el mini-dino amb el teclat per testejar
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxisRaw("Horizontal");
        continuousActionsOut[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 3. Càstig per xocar contra parets o obstacles
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            AddReward(-0.1f);
        }
    }
}

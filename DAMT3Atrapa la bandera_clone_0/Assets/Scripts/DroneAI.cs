using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Collections.Generic;

public class DroneAI : Agent
{
    public enum DroneState { IDLE, CHASING, RETURNING_DINO, RETURNING_HOME, WAITING }
    
    [Header("Equip")]
    public string teamId; // "A" o "B"
    public DroneState currentState = DroneState.IDLE;
    public float flySpeed = 8f;
    public Transform basePunt; // Punt on deixa el dinosaure
    public GameObject dinoPrefab; // Per tornar a spawnear el dino a la base
    
    [Header("Estat Intern")]
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Player jugadorTarget;
    private GameObject dinoVisual; // El dino que porta el dron
    
    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        initialPosition = transform.position;
        
        // Ja no busquem un jugador fix aquí, ho farem dinàmicament a l'UpdateStateMachine
    }

    public override void OnEpisodeBegin()
    {
        // Al començar un nou entrenament, tornem a casa
        transform.position = initialPosition;
        rb.linearVelocity = Vector2.zero;
        currentState = DroneState.IDLE;
        jugadorTarget = null;
        if (dinoVisual != null) Destroy(dinoVisual);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Només donem dades útils si estem perseguint
        if (currentState == DroneState.CHASING && jugadorTarget != null)
        {
            Vector2 diff = (jugadorTarget.transform.position - transform.position).normalized;
            sensor.AddObservation(diff.x);
            sensor.AddObservation(diff.y);
        }
        else
        {
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
        }

        sensor.AddObservation(rb.linearVelocity.x / flySpeed);
        sensor.AddObservation(rb.linearVelocity.y / flySpeed);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        UpdateStateMachine();

        // Lògica de moviment segons l'estat
        if (currentState == DroneState.CHASING && jugadorTarget != null)
        {
            Vector2 moveDir = new Vector2(actions.ContinuousActions[0], actions.ContinuousActions[1]);
            
            // Instint: Direcció directa cap al jugador
            Vector2 directDir = (jugadorTarget.transform.position - transform.position).normalized;
            
            // Mezclem: 70% IA (per esquivar) + 30% Directe (per agressivitat)
            Vector2 finalDir = Vector2.Lerp(moveDir, directDir, 0.3f).normalized;
            
            // Antiatrapament
            if (rb.linearVelocity.magnitude < 0.5f && moveDir.magnitude > 0.1f)
            {
                finalDir += new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f));
                finalDir = finalDir.normalized;
            }
            
            rb.linearVelocity = finalDir * flySpeed;

            // Recompensa ML-Agents: Arribar al jugador
            Vector2 dirToTarget = (jugadorTarget.transform.position - transform.position).normalized;
            float velocityTowardsTarget = Vector2.Dot(rb.linearVelocity, dirToTarget);
            if (velocityTowardsTarget > 0) AddReward(velocityTowardsTarget * 0.01f);
            
            AddReward(-0.01f); // Penalització per temps
        }
        else if (currentState == DroneState.RETURNING_DINO)
        {
            MoveTowardsTarget(basePunt.position);
            if (Vector3.Distance(transform.position, basePunt.position) < 1f)
            {
                DropDino();
                currentState = DroneState.RETURNING_HOME;
            }
        }
        else if (currentState == DroneState.RETURNING_HOME)
        {
            MoveTowardsTarget(initialPosition);
            if (Vector3.Distance(transform.position, initialPosition) < 0.2f)
            {
                Debug.Log("Misión completada. Reiniciando episodio.");
                EndEpisode(); 
            }
        }
        else // IDLE o WAITING
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, Time.fixedDeltaTime * 5f);
        }

        // Gir visual
        if (rb.linearVelocity.x > 0.1f) sr.flipX = false;
        else if (rb.linearVelocity.x < -0.1f) sr.flipX = true;
    }

    void UpdateStateMachine()
    {
        // Busquem a TODOS els jugadors a la partida
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        Player carrierEnemigo = null;

        foreach (GameObject pGo in allPlayers)
        {
            Player p = pGo.GetComponent<Player>();
            
            // ¿Aquest jugador porta una bandera?
            if (p != null && p.banderaAgafada != null)
            {
                Bandera b = p.banderaAgafada.GetComponent<Bandera>();
                // Si la bandera que porta és la del MEU equip (teamId), ¡a per ell!
                if (b != null && b.equipPropietari == teamId)
                {
                    carrierEnemigo = p;
                    break; 
                }
            }
        }

        // Actualitzem l'estat segons si hem trobat un lladre
        if (carrierEnemigo != null)
        {
            jugadorTarget = carrierEnemigo;
            
            // Si el jugador entra en combat (minijoc), el dron espera fora
            if (!jugadorTarget.potMoure)
            {
                currentState = DroneState.WAITING;
            }
            else if (currentState == DroneState.IDLE || currentState == DroneState.RETURNING_HOME || currentState == DroneState.WAITING)
            {
                currentState = DroneState.CHASING;
            }
        }
        else
        {
            // Si ningú té la nostra bandera, el dron torna a casa si estava perseguint
            if (currentState == DroneState.CHASING || currentState == DroneState.WAITING)
            {
                jugadorTarget = null;
                currentState = DroneState.RETURNING_HOME;
            }
        }
    }

    void MoveTowardsTarget(Vector3 target)
    {
        Vector2 dir = (target - transform.position).normalized;
        rb.linearVelocity = dir * (flySpeed * 1.5f); // Una mica més ràpid al tornar
    }

    void DropDino()
    {
        Debug.Log("[Dron] Intentant lliurar dinosaure...");
        if (dinoVisual != null) Destroy(dinoVisual);
        
        // Obtenim el color de l'equip des del GameManager/MenuManager
        GameObject prefabAUsar = null;
        if (GameManager.Instance != null && MenuManager.Instance != null && MenuManager.Instance.currentRoomData != null)
        {
            string color = (teamId == "A") ? MenuManager.Instance.currentRoomData.teamAColor : MenuManager.Instance.currentRoomData.teamBColor;
            prefabAUsar = GameManager.Instance.GetFlagPrefab(color);
        }
        else
        {
            // Fallback al prefab del inspector si no hi ha xarxa
            prefabAUsar = dinoPrefab;
        }

        if (prefabAUsar != null && basePunt != null)
        {
            Vector3 spawnPos = basePunt.position;
            spawnPos.z = 0; 
            GameObject nouDino = Instantiate(prefabAUsar, spawnPos, Quaternion.identity);
            
            // FORÇAR VISIBILITAT
            nouDino.transform.localScale = new Vector3(4f, 4f, 1f); // Mida estàndard de les banderes
            SpriteRenderer nSR = nouDino.GetComponentInChildren<SpriteRenderer>();
            if (nSR != null) nSR.sortingOrder = 10; 
            
            Bandera b = nouDino.GetComponent<Bandera>();
            if (b != null) b.equipPropietari = teamId;

            Debug.Log($"<color=green>¡DINOSAURIO RECUPERADO!</color> ({teamId}) en la base.");
        }
        else
        {
            Debug.LogError("<color=red>ERROR:</color> No s'ha trobat el prefab del dinosaure per al color de la sala.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentState == DroneState.CHASING && collision.gameObject.CompareTag("Player"))
        {
            Player p = collision.gameObject.GetComponent<Player>();
            if (p != null && p.banderaAgafada != null)
            {
                // Verifiquem que la bandera que porta és realment la nostra (per seguretat extra)
                Bandera b = p.banderaAgafada.GetComponent<Bandera>();
                if (b != null && b.equipPropietari == teamId)
                {
                    Debug.Log("¡Capturat! El dron recupera el dinosaure del seu equip.");
                    AddReward(10.0f);
                    
                    p.DeixarBandera(); 
                    Destroy(b.gameObject);
                    
                    // Efecte visual: El dron "porta" el dino
                    if (dinoVisual == null)
                    {
                        dinoVisual = new GameObject("DinoVisual");
                        dinoVisual.transform.parent = transform;
                        dinoVisual.transform.localPosition = new Vector3(0, -0.5f, 0);
                        SpriteRenderer dSR = dinoVisual.AddComponent<SpriteRenderer>();
                        dSR.sprite = sr.sprite; 
                        dSR.color = (teamId == "A") ? Color.red : Color.blue; 
                    }

                    currentState = DroneState.RETURNING_DINO;
                }
            }
        }
        else if (currentState == DroneState.CHASING && (collision.gameObject.CompareTag("Muro") || collision.gameObject.CompareTag("Suelo")))
        {
            AddReward(-2.0f); // Penalització per xocar
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }
}

using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System.Collections.Generic;

public class CyborgAgent : Agent
{
    public Transform baseInicial;
    public Transform jugadorTarget;
    public List<Transform> dinoSpawnPoints = new List<Transform>();
    public float moveSpeed = 4f;
    public float jumpForce = 12f;
    public float climbSpeed = 4f;
    public bool cyborgTeDino = false;
    
    private Rigidbody2D rb;
    private float defaultGravity;
    private bool isNearLadder = false;
    private bool isClimbing = false;
    private float lastDistanceToTarget;
    private GameObject dinoObject;
    private GameObject baseObject;
    // Variables para suavizar el movimiento de la IA
    private float _pendingMoveX = 0f;
    private int _pendingJump = 0;
    private int _pendingClimb = 0;

    private Player currentTargetPlayer = null;
    private Animator anim;
    private SpriteRenderer sr;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        defaultGravity = rb.gravityScale;
        
        dinoObject = GameObject.FindWithTag("Dinosaurio");
        baseObject = GameObject.FindWithTag("BaseRoja");
    }

    public override void OnEpisodeBegin()
    {
        if (baseInicial != null)
        {
            transform.position = baseInicial.position;
        }
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = defaultGravity;
        cyborgTeDino = false;
        isClimbing = false;

        // Reset captured dino if it was parented
        if (capturedDino != null)
        {
            capturedDino.SetParent(null);
            capturedDino = null;
        }

        currentTargetPlayer = null;
        jugadorTarget = null;
        lastDistanceToTarget = float.MaxValue;
        if (dinoObject != null)
        {
            dinoObject.SetActive(true);
            
            if (dinoSpawnPoints != null && dinoSpawnPoints.Count > 0)
            {
                int randomIndex = Random.Range(0, dinoSpawnPoints.Count);
                dinoObject.transform.position = dinoSpawnPoints[randomIndex].position;
            }
            
            jugadorTarget = dinoObject.transform;
            lastDistanceToTarget = Vector3.Distance(transform.localPosition, jugadorTarget.localPosition);
        }
    }

    private void UpdateTarget()
    {
        currentTargetPlayer = null;
        jugadorTarget = null;

        Player[] allPlayers = FindObjectsByType<Player>(FindObjectsSortMode.None);
        foreach (Player p in allPlayers)
        {
            if (p.banderaAgafada != null)
            {
                currentTargetPlayer = p;
                jugadorTarget = p.transform;
                return;
            }
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        UpdateTarget();

        // 1. ¿Hay ladrón? (1 valor)
        sensor.AddObservation(jugadorTarget != null ? 1.0f : 0.0f);

        // 2. Vector hacia el ladrón (2 valores)
        if (jugadorTarget != null)
        {
            Vector3 diff = jugadorTarget.position - transform.position;
            sensor.AddObservation(diff.x);
            sensor.AddObservation(diff.y);
        }
        else
        {
            sensor.AddObservation(0f);
            sensor.AddObservation(0f);
        }

        // 3. Velocidad actual del Cyborg (2 valores)
        sensor.AddObservation(rb.linearVelocity.x);
        sensor.AddObservation(rb.linearVelocity.y);

        // 4. Está cerca de la escalera / subiendo (2 valores)
        sensor.AddObservation(isNearLadder ? 1.0f : 0.0f);
        sensor.AddObservation(isClimbing ? 1.0f : 0.0f);
        
        // TOTAL SPACE SIZE: 7
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int moveAction = actions.DiscreteActions[0];
        _pendingMoveX = (moveAction == 1) ? -1f : (moveAction == 2) ? 1f : 0f;

        int verticalAction = actions.DiscreteActions[1];
        _pendingClimb = (verticalAction == 1) ? 1 : (verticalAction == 2) ? -1 : 0;

        _pendingJump = (actions.DiscreteActions[2] == 1) ? 1 : 0;

        if (jugadorTarget != null)
        {
            // SI HAY LADRÓN: Dar puntos por acercarse
            float currentDistance = Vector2.Distance(transform.position, jugadorTarget.position);
            if (currentDistance < lastDistanceToTarget)
            {
                AddReward(0.01f); // Recompensa por perseguir bien
            }
            lastDistanceToTarget = currentDistance;
        }
        else
        {
            // SI NO HAY LADRÓN: Dar puntitos por patrullar y no quedarse quieto
            if (Mathf.Abs(_pendingMoveX) > 0)
            {
                AddReward(0.002f);
            }
        }

        AddReward(-0.0005f); // Penalización pequeña para que no pierda tiempo
    }

    private void FixedUpdate()
    {
        if (rb == null || rb.bodyType == RigidbodyType2D.Static) return;

        if (isNearLadder && Mathf.Abs(_pendingClimb) > 0) isClimbing = true;

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(_pendingMoveX * moveSpeed, _pendingClimb * climbSpeed);
        }
        else
        {
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = new Vector2(_pendingMoveX * moveSpeed, rb.linearVelocity.y);
        }

        if (_pendingJump == 1 && !isClimbing && Mathf.Abs(rb.linearVelocity.y) < 0.05f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        _pendingJump = 0; // Consumimos el salto siempre para evitar dobles saltos raros

        // --- ANIMACIONES Y ROTACIÓN VISUAL ---
        if (sr != null)
        {
            if (_pendingMoveX > 0) sr.flipX = false;
            else if (_pendingMoveX < 0) sr.flipX = true;
        }

        if (anim != null)
        {
            anim.SetFloat("yVelocity", rb.linearVelocity.y);
            anim.SetBool("isRunning", Mathf.Abs(_pendingMoveX) > 0.1f);
            anim.SetBool("isGrounded", Mathf.Abs(rb.linearVelocity.y) < 0.05f && !isClimbing);
            anim.SetBool("isClimbing", isClimbing);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = 0; discreteActions[1] = 0; discreteActions[2] = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) discreteActions[0] = 1;
        else if (Input.GetKey(KeyCode.RightArrow)) discreteActions[0] = 2;
        if (Input.GetKey(KeyCode.UpArrow)) discreteActions[1] = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) discreteActions[1] = 2;
        if (Input.GetKey(KeyCode.Space)) discreteActions[2] = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZonaEscalera")) isNearLadder = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con el jugador que tiene el dinosaurio
        if (collision.gameObject.CompareTag("Player"))
        {
            Player p = collision.gameObject.GetComponent<Player>();
            if (p != null && p.banderaAgafada != null)
            {
                Debug.Log("[Cyborg] LADRÓN ATRAPADO!");
                p.PerdreMinijoc(); // Esto le quita el dinosaurio y lo aturde
                AddReward(5.0f); // ¡Premio Gordo!
                EndEpisode(); // Reiniciar episodio
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ZonaEscalera"))
        {
            isNearLadder = false;
            isClimbing = false;
            rb.gravityScale = defaultGravity;
        }
    }
}

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
    private Transform capturedDino;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
        // REACTIVAR DINOSAURIO I ALEATORITZAR POSICIÓ
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

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        if (jugadorTarget != null)
            sensor.AddObservation(jugadorTarget.localPosition);
        else
            sensor.AddObservation(Vector3.zero);

        sensor.AddObservation(cyborgTeDino);
        sensor.AddObservation(rb.linearVelocity);
        sensor.AddObservation(isNearLadder);
        sensor.AddObservation(isClimbing);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int moveAction = actions.DiscreteActions[0];
        float moveX = 0f;
        if (moveAction == 1) moveX = -1f;
        else if (moveAction == 2) moveX = 1f;

        int verticalAction = actions.DiscreteActions[1];
        float moveY = 0f;
        if (verticalAction == 1) moveY = 1f;
        else if (verticalAction == 2) moveY = -1f;

        if (isNearLadder && Mathf.Abs(moveY) > 0.1f) isClimbing = true;

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * climbSpeed);
        }
        else
        {
            rb.gravityScale = defaultGravity;
            rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        }

        if (actions.DiscreteActions[2] == 1 && !isClimbing && Mathf.Abs(rb.linearVelocity.y) < 0.05f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (jugadorTarget != null && jugadorTarget.gameObject.activeInHierarchy)
        {
            float currentDistance = Vector3.Distance(transform.localPosition, jugadorTarget.localPosition);
            if (currentDistance < lastDistanceToTarget) AddReward(0.001f);
            else AddReward(-0.001f);
            lastDistanceToTarget = currentDistance;
        }

        AddReward(-0.0005f);
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

        if (collision.CompareTag("Dinosaurio") && !cyborgTeDino)
        {
            cyborgTeDino = true;
            AddReward(1.0f);
            
            // EFECTE VISUAL: EMPARENTAR DINOSAURIO
            capturedDino = collision.transform;
            capturedDino.SetParent(this.transform);
            capturedDino.localPosition = new Vector3(-0.6f, 0, 0); // Una mica dalt i darrere
            
            if (baseObject != null) 
            {
                jugadorTarget = baseObject.transform;
                lastDistanceToTarget = Vector3.Distance(transform.localPosition, jugadorTarget.localPosition);
            }
        }
        else if (collision.CompareTag("BaseRoja") && cyborgTeDino)
        {
            AddReward(2.0f);
            
            // SOLTAR DINOSAURIO A LA BASE
            if (capturedDino != null)
            {
                capturedDino.SetParent(null);
                capturedDino.gameObject.SetActive(false);
            }
            
            EndEpisode();
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

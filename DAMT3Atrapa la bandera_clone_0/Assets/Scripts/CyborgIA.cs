using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class CyborgIA : Agent
{
    private Transform targetDinosaurio;
    private Transform baseDestino;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    
    private Rigidbody2D rb;
    private Animator anim;
    private bool tieneDino = false;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public override void OnEpisodeBegin()
    {
        targetDinosaurio = TrobarMesProper("Dinosaurio");
        baseDestino = TrobarMesProper("BaseRoja");

        tieneDino = false;
        if (targetDinosaurio != null)
        {
            targetDinosaurio.SetParent(null);
            // Posicionamiento aleatorio local
            targetDinosaurio.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        }
        
        transform.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
    }

    private Transform TrobarMesProper(string tag)
    {
        GameObject[] objectius = GameObject.FindGameObjectsWithTag(tag);
        Transform mesProper = null;
        float distanciaMinima = Mathf.Infinity;
        Vector3 posicioActual = transform.position;

        foreach (GameObject obj in objectius)
        {
            float distancia = Vector2.Distance(obj.transform.position, posicioActual);
            if (distancia < distanciaMinima)
            {
                mesProper = obj.transform;
                distanciaMinima = distancia;
            }
        }

        return mesProper;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if (targetDinosaurio == null || baseDestino == null)
        {
            sensor.AddObservation(Vector3.zero); // Mi posición
            sensor.AddObservation(Vector3.zero); // Posición Dino
            sensor.AddObservation(Vector3.zero); // Posición Base
            sensor.AddObservation(0f);           // Flag tieneDino
            return;
        }

        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetDinosaurio.localPosition);
        sensor.AddObservation(baseDestino.localPosition);
        sensor.AddObservation(tieneDino ? 1f : 0f);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int act = actions.DiscreteActions[0];
        float moveX = 0f;

        if (act == 1) moveX = -1f;
        else if (act == 2) moveX = 1f;

        // Aplicar movimiento horizontal respetando la vertical (gravedad)
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // Lógica de salto (Acción 3)
        if (act == 3 && Mathf.Abs(rb.linearVelocity.y) < 0.05f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            /* if (anim != null)
            {
                anim.SetTrigger("Jump");
            } */
        }

        // Actualizar animaciones
        if (anim != null)
        {
            // anim.SetFloat("Speed", Mathf.Abs(moveX)); // Comentado para evitar error si el parámetro no existe
        }
        
        // Penalización por tiempo
        AddReward(-0.001f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (targetDinosaurio != null && col.transform == targetDinosaurio && !tieneDino)
        {
            tieneDino = true;
            AddReward(0.5f);
            targetDinosaurio.SetParent(transform);
            targetDinosaurio.localPosition = Vector3.zero;
        }
        else if (baseDestino != null && col.transform == baseDestino && tieneDino)
        {
            tieneDino = false;
            if (targetDinosaurio != null)
            {
                targetDinosaurio.SetParent(null);
            }
            AddReward(1f);
            EndEpisode();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Dinosaurio") && !tieneDino)
        {
            tieneDino = true;
            AddReward(0.5f);
            targetDinosaurio.SetParent(transform);
            targetDinosaurio.localPosition = Vector3.zero;
        }
        else if (col.CompareTag("BaseRoja") && tieneDino)
        {
            targetDinosaurio.SetParent(null);
            AddReward(1f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) discreteActions[0] = 1;
        else if (Input.GetKey(KeyCode.RightArrow)) discreteActions[0] = 2;
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) discreteActions[0] = 3;
    }
}

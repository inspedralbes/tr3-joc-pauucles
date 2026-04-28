using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class DroneAI : Agent
{
    public enum DroneState { A_Salvo, Robado, Tirado }
    public string teamId;

    [Header("Referencias")]
    public Transform baseEquipo;
    
    [Header("Configuración")]
    public float flySpeed = 7f;
    public float velocidadCaza = 10f; // Task 1.1
    public float maxAllowedDistance = 50f;

    [Header("Estado Actual (Debug)")]
    public DroneState currentState = DroneState.A_Salvo;
    public Vector2 targetPosition;

    private Rigidbody2D rb;
    private Unity.MLAgents.DecisionRequester decisionRequester;
    private float lastDistanceToTarget;
    private Vector3 initialPosition;
    public bool portantDino = false;
    private Transform dinosaurioTransform;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        decisionRequester = GetComponent<Unity.MLAgents.DecisionRequester>();
        initialPosition = transform.position;

        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }

    private void BuscarDinosaurioEquipo()
    {
        if (dinosaurioTransform != null) return;

        Bandera[] banderas = Object.FindObjectsByType<Bandera>(FindObjectsSortMode.None);
        foreach (var b in banderas)
        {
            if (b.equipPropietari == this.teamId)
            {
                dinosaurioTransform = b.transform;
                break;
            }
        }
    }

    private void DeterminarEstadoActual()
    {
        BuscarDinosaurioEquipo();

        if (dinosaurioTransform == null)
        {
            currentState = DroneState.A_Salvo;
            return;
        }

        // Robado: El dinosaurio tiene un padre que es un jugador (no el dron)
        if (dinosaurioTransform.parent != null && dinosaurioTransform.parent != transform)
        {
            currentState = DroneState.Robado;
        }
        // A_Salvo: El dinosaurio está cerca de la base (distancia < 2m)
        else if (baseEquipo != null && Vector2.Distance(dinosaurioTransform.position, baseEquipo.position) < 2f)
        {
            currentState = DroneState.A_Salvo;
        }
        // Tirado: En el suelo fuera de la base
        else
        {
            currentState = DroneState.Tirado;
        }
    }

    private Vector2 GetTargetPosition()
    {
        // Task 1.2: Redirección dinámica de objetivo para ML-Agents
        if (portantDino)
        {
            return baseEquipo != null ? (Vector2)baseEquipo.position : (Vector2)transform.position;
        }

        DeterminarEstadoActual();

        if (dinosaurioTransform == null) 
            return baseEquipo != null ? (Vector2)baseEquipo.position : (Vector2)transform.position;

        switch (currentState)
        {
            case DroneState.A_Salvo:
                return baseEquipo != null ? (Vector2)baseEquipo.position : (Vector2)transform.position;
            case DroneState.Robado:
                // Si está robado, el objetivo es el padre del dinosaurio (el jugador enemigo)
                return (Vector2)dinosaurioTransform.parent.position;
            case DroneState.Tirado:
                return (Vector2)dinosaurioTransform.position;
            default:
                return (Vector2)transform.position;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // 1. Posición del dron (2 valores)
        sensor.AddObservation(transform.position.x);
        sensor.AddObservation(transform.position.y);

        // 2. Posición de la base (2 valores)
        Vector2 basePos = baseEquipo != null ? (Vector2)baseEquipo.position : (Vector2)initialPosition;
        sensor.AddObservation(basePos.x);
        sensor.AddObservation(basePos.y);

        // 3. Posición del objetivo actual (2 valores) - Actualizado vía GetTargetPosition
        targetPosition = GetTargetPosition();
        sensor.AddObservation(targetPosition.x);
        sensor.AddObservation(targetPosition.y);

        // 4. Velocidad del dron (2 valores)
        Vector2 velocity = rb != null ? rb.linearVelocity : Vector2.zero;
        sensor.AddObservation(velocity.x);
        sensor.AddObservation(velocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Task 1.3: Reposo forzado (Cerebro activo, cuerpo quieto)
        if (!portantDino && currentState == DroneState.A_Salvo)
        {
            if (rb != null) rb.linearVelocity = Vector2.zero;
            return;
        }

        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];

        if (rb != null)
        {
            // Task 1.4: Aplicar velocidad de caza para mayor determinación
            rb.linearVelocity = new Vector2(moveX, moveY) * velocidadCaza;
        }

        targetPosition = GetTargetPosition();
        lastDistanceToTarget = Vector2.Distance(transform.position, targetPosition);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxisRaw("Horizontal");
        continuousActionsOut[1] = Input.GetAxisRaw("Vertical");
    }

    private void Update()
    {
        DeterminarEstadoActual();

        // Task 3.1, 3.2, 3.3: Estabilidad del Dron (Modo Piedra)
        if (currentState == DroneState.A_Salvo && !portantDino && baseEquipo != null)
        {
            // Inmovilidad absoluta
            if (rb != null) rb.linearVelocity = Vector2.zero;
            transform.position = baseEquipo.position;

            // Desactivar IA para ahorrar recursos y evitar jitters
            if (decisionRequester != null) decisionRequester.enabled = false;
            return; 
        }

        // Si no estamos en reposo, aseguramos que la IA esté activa
        if (decisionRequester != null && !decisionRequester.enabled) decisionRequester.enabled = true;

        // Bucle de entrega si transportamos dino
        if (portantDino && baseEquipo != null && dinosaurioTransform != null)
        {
            float distToBase = Vector2.Distance(transform.position, baseEquipo.position);
            if (distToBase < 1.0f)
            {
                Debug.Log("[DRON-IA] ¡Entrega en base conseguida!");
                
                var netSync = dinosaurioTransform.GetComponent<NetworkSync>();
                if (netSync != null) netSync.enabled = true;

                dinosaurioTransform.SetParent(null);
                dinosaurioTransform.position = baseEquipo.position;
                portantDino = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (portantDino) return;

        BuscarDinosaurioEquipo();
        if (dinosaurioTransform == null) return;

        // Caso A: Colisiono con el dinosaurio tirado
        bool esDinoTirado = (other.transform == dinosaurioTransform && dinosaurioTransform.parent == null);
        
        // Caso B: Colisiono con el jugador enemigo que lleva nuestro dinosaurio
        bool esPortadorEnemigo = (other.CompareTag("Player") && dinosaurioTransform.parent == other.transform);

        if (esDinoTirado || esPortadorEnemigo)
        {
            Debug.Log($"[DRON-IA] ¡Objetivo recuperado de {other.name}!");

            // Secuestro de red del dinosaurio (Task 3.1)
            var netSync = dinosaurioTransform.GetComponent<NetworkSync>();
            if (netSync != null) netSync.enabled = false;

            dinosaurioTransform.SetParent(transform);
            dinosaurioTransform.localPosition = Vector3.zero;
            portantDino = true;
        }
    }
}

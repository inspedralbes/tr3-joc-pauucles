using UnityEngine;
using Unity.MLAgents;

/// <summary>
/// Gestiona el entorno de entrenamiento usando puntos de spawn específicos.
/// </summary>
public class DroneTrainingManager : MonoBehaviour
{
    [Header("Referencias")]
    public DroneChaserAgent droneAgent;
    public GameObject playerTarget;
    public BoxCollider2D trainingArea; // <-- Restaurada
    public Transform[] puntosDeSpawn; // Lista de GameObjects Spawn1, Spawn2...
    
    [Header("Configuración de Entrenamiento")]
    public float playerMoveSpeed = 5f;
    public bool isTrainingMode = false;

    private void Start()
    {
        if (Academy.Instance.IsCommunicatorOn)
        {
            isTrainingMode = true;
        }
        
        if (isTrainingMode)
        {
            Debug.Log("[DRONE-TRAINING] Modo entrenamiento ACTIVO con puntos de spawn.");
            
            // Desactivar gravedad del jugador para que no se caiga durante el entreno
            if (playerTarget != null)
            {
                Rigidbody2D rbP = playerTarget.GetComponent<Rigidbody2D>();
                if (rbP != null) rbP.gravityScale = 0;
            }
        }
    }

    private void Update()
    {
        if (isTrainingMode && playerTarget != null)
        {
            MoverJugadorAutomaticamente();
        }
    }

    private void MoverJugadorAutomaticamente()
    {
        float speed = playerMoveSpeed;
        float moveX = Mathf.Sin(Time.time * 0.5f) * speed;
        float moveY = Mathf.Cos(Time.time * 0.3f) * speed;
        
        Vector3 movement = new Vector3(moveX, moveY, 0) * Time.deltaTime;
        playerTarget.transform.Translate(movement);
    }

    /// <summary>
    /// Teletransporta al dron y al jugador a puntos de spawn aleatorios de la lista.
    /// </summary>
    public void ResetEpisode()
    {
        if (puntosDeSpawn == null || puntosDeSpawn.Length < 2)
        {
            Debug.LogWarning("[DRONE-TRAINING] ¡Faltan puntos de spawn en la lista!");
            return;
        }

        // Elegir un punto para el dron
        int idxDron = Random.Range(0, puntosDeSpawn.Length);
        droneAgent.transform.position = puntosDeSpawn[idxDron].position;

        // Elegir un punto para el jugador (que no sea el mismo que el del dron)
        int idxPlayer = Random.Range(0, puntosDeSpawn.Length);
        while (idxPlayer == idxDron) {
            idxPlayer = Random.Range(0, puntosDeSpawn.Length);
        }
        playerTarget.transform.position = puntosDeSpawn[idxPlayer].position;
        
        Debug.Log("[DRONE-TRAINING] Respawn en puntos de spawn completado.");
    }
}

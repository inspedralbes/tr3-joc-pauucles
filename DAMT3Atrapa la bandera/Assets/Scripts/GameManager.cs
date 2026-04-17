using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Player localPlayer;

    void Start()
    {
        if (localPlayer == null)
        {
            localPlayer = UnityEngine.Object.FindFirstObjectByType<Player>();
        }

        if (localPlayer != null)
        {
            AssignarSpawn();
        }
        else
        {
            Debug.LogError("[GameManager] No s'ha trobat el component Player a l'escena.");
        }
    }

    void AssignarSpawn()
    {
        string team = WebSocketClient.Team;
        if (string.IsNullOrEmpty(team))
        {
            Debug.LogWarning("[GameManager] No s'ha detectat equip a WebSocketClient. Usant 'Rojo' per defecte per a proves.");
            team = "Rojo";
        }

        Debug.Log($"[GameManager] Detectat equip de l'usuari: {team}");

        // Mapatge robust segons l'especificació:
        // PuntSpawn_Equip1: 1, A, Rojo, Vermell
        // PuntSpawn_Equip2: 2, B, Azul, Blau
        string tLower = team.ToLower();
        string targetName;

        if (tLower == "1" || tLower == "a" || tLower == "rojo" || tLower == "vermell")
        {
            targetName = "PuntSpawn_Equip1";
        }
        else if (tLower == "2" || tLower == "b" || tLower == "azul" || tLower == "blau")
        {
            targetName = "PuntSpawn_Equip2";
        }
        else
        {
            Debug.LogWarning($"[GameManager] Equip '{team}' no reconegut. Usant PuntSpawn_Equip1 per defecte.");
            targetName = "PuntSpawn_Equip1";
        }
        
        List<Transform> validSpawns = new List<Transform>();
        Transform[] allTransforms = UnityEngine.Object.FindObjectsByType<Transform>(UnityEngine.FindObjectsSortMode.None);

        foreach (Transform t in allTransforms)
        {
            if (t.name == targetName)
            {
                validSpawns.Add(t);
            }
        }

        if (validSpawns.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, validSpawns.Count);
            localPlayer.transform.position = validSpawns[randomIndex].position;
            Debug.Log($"[GameManager] Jugador de l'equip {team} posicionat a {validSpawns[randomIndex].name} (Pos: {validSpawns[randomIndex].position})");
        }
        else
        {
            Debug.LogError($"[GameManager] ERROR CRÍTIC: No s'ha trobat cap objecte a l'escena anomenat: {targetName}");
        }
    }
}

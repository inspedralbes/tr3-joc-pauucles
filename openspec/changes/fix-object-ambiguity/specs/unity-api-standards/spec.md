## MODIFIED Requirements

### Requirement: Ús d'API amb namespaces qualificats
El sistema HA D'utilitzar namespaces explícits per a les classes d'Unity que tinguin noms comuns amb el sistema base de C# per evitar conflictes d'ambigüitat.

#### Scenario: Ús de UnityEngine.Object
- **WHEN** S'ha de cridar a un mètode estàtic de la classe `Object` d'Unity (com `FindFirstObjectByType`).
- **THEN** El sistema HA DE qualificar la crida com `UnityEngine.Object.FindFirstObjectByType<T>()`.

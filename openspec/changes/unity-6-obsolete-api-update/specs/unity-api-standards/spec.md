## MODIFIED Requirements

### Requirement: Ús d'API de cerca moderna
El sistema HA DE fer servir els mètodes de cerca d'objectes més actuals proporcionats per Unity per evitar avisos d'obsolescència i assegurar la compatibilitat amb versions futures del motor.

#### Scenario: Substitució de FindObjectOfType
- **WHEN** S'ha de localitzar un objecte únic a l'escena (com el `Player` o el `MinijocUIManager`).
- **THEN** El sistema HA D'utilitzar `Object.FindFirstObjectByType<T>()` en lloc de `Object.FindObjectOfType<T>()`.

## REMOVED Requirements

### Requirement: Ús de FindObjectOfType (Llegat)
**Reason**: Marcat com a obsolet a Unity 6 per motius de rendiment i claredat d'intencions (distinció entre trobar qualsevol o trobar el primer).
**Migration**: Substituït per `FindFirstObjectByType<T>()`.

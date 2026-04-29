## Context

Actualmente, la sincronización de equipos para jugadores remotos es inexistente o poco fiable, lo que impide que la lógica de captura de la bandera (`Bandera.cs`) identifique correctamente si un jugador es aliado o enemigo. Este diseño propone centralizar la asignación del equipo en el momento en que se instancia o actualiza cualquier jugador (local o remoto) en el `GameManager`.

## Goals / Non-Goals

**Goals:**
- Asegurar que todo objeto con el componente `Player` tenga su variable `equip` correctamente inicializada ("A" o "B").
- Centralizar la obtención de datos de equipo desde la fuente de verdad: `MenuManager.Instance.currentRoomData.players`.
- Simplificar la validación en `Bandera.cs`.

**Non-Goals:**
- No se modificará el sistema de comunicación por WebSockets ni el backend.
- No se cambiará la lógica de movimiento de los jugadores.

## Decisions

- **Variable de Equipo**: Se añadirá `public string equip` a `Player.cs` para actuar como el "estado" de equipo del objeto en el mundo de juego.
- **Asignación en GameManager**: 
    - El `GameManager` es el único responsable de configurar los visuales y el estado de los jugadores al entrar en escena.
    - Se implementará un método auxiliar `GetTeamFromRoomData(string username)` que recorra la lista de jugadores en la sala actual para devolver su equipo ("A" o "B").
- **Jugadores Remotos**: En `UpdateRemotePlayer`, al instanciar el prefab, se le asignará el equipo inmediatamente.
- **Simplificación de Bandera**: Se eliminará el mapeo manual de `idJugador` dentro de `Bandera.cs`, confiando plenamente en la variable `equip` ya sincronizada.

## Risks / Trade-offs

- **[Riesgo] currentRoomData es null** → **[Mitigación]** Añadir comprobaciones nulas y registrar errores claros en la consola si los datos de la sala no están disponibles.
- **[Riesgo] Jugadores sin equipo definido en backend** → **[Mitigación]** Definir un valor por defecto o tratar como equipo neutral para evitar capturas accidentales.

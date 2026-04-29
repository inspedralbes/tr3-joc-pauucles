## Context

Actualmente, los jugadores pueden colisionar físicamente, pero no existe una consecuencia mecánica cuando son enemigos. El script `Player.cs` debe actuar como el disparador del sistema de combate cuando detecta una colisión válida, interactuando con el `MinijocUIManager` ya existente.

## Goals / Non-Goals

**Goals:**
- Detectar colisiones entre jugadores enemigos usando etiquetas y la variable `equip`.
- Prevenir el "spam" de minijuegos si ya hay uno activo.
- Iniciar la UI de combate pasando ambos jugadores como parámetros.

**Non-Goals:**
- No se modificará el sistema de físicas ni los colliders de los prefabs.
- No se implementará la lógica de resolución del combate en este script.

## Decisions

- **Uso de OnCollisionEnter2D**: Se prefiere a `OnTriggerEnter2D` porque los jugadores tienen colliders físicos que provocan rebotes, lo cual es el momento natural para disparar el combate.
- **Validación de Equipos**: Se accederá al componente `Player` del objeto colisionante. Si es un jugador remoto, su variable `equip` ya debería estar sincronizada por el `GameManager`.
- **API de Minijuegos**: Se utilizará `MinijocUIManager.Instance.ShowUI(this, opponent)`, que es el método diseñado para manejar enfrentamientos entre dos instancias de `Player`.
- **Restricción de Estado**: Se verificará `!MinijocUIManager.Instance.minijocActiu` para asegurar que el combate no se interrumpa por colisiones accidentales durante su ejecución.

## Risks / Trade-offs

- **[Riesgo] Doble activación (Red)** → **[Mitigación]** Ambos jugadores detectarán la colisión; la UI está diseñada como Singleton para manejar este escenario, pero se añadirá un log claro para depurar el orden de ejecución.
- **[Riesgo] Componentes faltantes** → **[Mitigación]** Se realizarán comprobaciones `if (opponent != null)` antes de intentar acceder al equipo.

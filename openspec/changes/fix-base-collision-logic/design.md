## Context

El script `Player.cs` gestiona la interacción con las bases mediante triggers. Actualmente, esta lógica es demasiado genérica y no diferencia entre bases aliadas y enemigas, lo que interrumpe el movimiento de los oponentes que simplemente pasan por encima. Es necesario refinar este comportamiento para mejorar la jugabilidad y la precisión de la mecánica de entrega.

## Goals / Non-Goals

**Goals:**
- Permitir que los jugadores crucen bases enemigas sin ser bloqueados ni activar lógicas de entrega.
- Restringir la activación del minijuego de entrega únicamente a la base aliada del jugador.
- Validar que el jugador realmente transporte una bandera enemiga antes de procesar la entrega.

**Non-Goals:**
- No se modificará el sistema de colisiones físicas (CollisionEnter).
- No se cambiará la lógica de respawn asociada a estas bases.

## Decisions

- **Identificación por Nombre**: Se utilizará `other.gameObject.name` para determinar el equipo de la base. "PuntSpawn_Equip1" se mapeará al equipo "A" y cualquier nombre que contenga "Equip2" al equipo "B". Esto aprovecha la nomenclatura existente en la escena sin requerir nuevos componentes.
- **Filtrado Temprano (Early Exit)**: Si el equipo de la base no coincide con el del jugador (`this.equip`), se ejecutará un `return` inmediato. Esto asegura que los enemigos no interactúen con la base ajena.
- **Validación de Bandera**: Se comprobará `transform.GetComponentInChildren<Bandera>()` o la variable `banderaAgafada`. Si el jugador está en su base pero no lleva bandera, no ocurrirá nada.
- **Activación de Minijuego**: Se usará `MinijocUIManager.Instance.ShowUI(this, this)` para abrir la interfaz del desafío, bloqueando previamente el movimiento con `potMoure = false`.

## Risks / Trade-offs

- **[Riesgo] Cambio de nombres en la jerarquía** → **[Mitigación]** El diseño utiliza `.Contains()` y verificaciones robustas de strings para ser menos sensible a cambios menores en el nombre del objeto en el Inspector.
- **[Riesgo] Ausencia de bandera enemiga** → **[Mitigación]** Se añade un log de depuración para confirmar por qué no se dispara la entrega si el jugador está en base (ej: "Estàs a la teva base, però no portes cap bandera").

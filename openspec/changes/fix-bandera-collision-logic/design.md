## Context

El script `Bandera.cs` gestiona la lógica de captura de la bandera en el juego. Actualmente, la detección de colisiones y la validación de equipos pueden ser inconsistentes o carecer de información de depuración suficiente para rastrear problemas en tiempo real.

## Goals / Non-Goals

**Goals:**
- Implementar una detección de colisiones "a prueba de balas" en `OnTriggerEnter2D`.
- Proporcionar logs detallados para cada paso del proceso de captura.
- Asegurar que la bandera solo se enganche a jugadores de equipos contrarios.
- Mantener la funcionalidad de soltar la bandera (`DeixarDeSeguir`).

**Non-Goals:**
- No se modificará la lógica de movimiento de retorno a la base (`Update`).
- No se cambiará el sistema de equipos global, solo cómo `Bandera.cs` interactúa con él.

## Decisions

- **Detección de Tag**: Se usará `collision.CompareTag("Player")` como primer filtro, ya que es el estándar en el proyecto para identificar jugadores.
- **Obtención de Equipo**: Se accederá al componente `Player` del objeto que colisiona. Se usará `idJugador` (1 para Equipo A, 2 para Equipo B) para determinar el equipo del jugador, manteniendo consistencia con el mapeo existente en `Player.cs`.
- **Comparación Segura**: Se implementará una lógica que maneje posibles valores nulos o no inicializados de los equipos antes de proceder con el cambio de jerarquía.
- **Enganche Jerárquico**: Se usará `transform.SetParent(collision.transform)` y se reseteará la `localPosition` a `(-0.5f, 0.5f, 0f)` para que la bandera siga al jugador visualmente de forma precisa.

## Risks / Trade-offs

- **[Riesgo] Componente Player ausente** → **[Mitigación]** Se realizará una comprobación `if (player != null)` antes de intentar acceder a sus propiedades.
- **[Riesgo] Teams no inicializados** → **[Mitigación]** Los logs de depuración mostrarán ambos equipos antes de la comparación para facilitar la identificación de errores de configuración.

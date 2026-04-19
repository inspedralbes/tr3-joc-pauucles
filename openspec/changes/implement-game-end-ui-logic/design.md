## Context

El sistema actual de fin de partida en `GameManager.cs` utiliza GameObjects estáticos ("PantallaVictoria", "PantallaDerrota") que se activan/desactivan. El proyecto está migrando a **UI Toolkit**, por lo que se requiere una implementación más dinámica y centralizada que utilice un único `UIDocument`.

## Goals / Non-Goals

**Goals:**
- Centralizar la UI de fin de partida en un único `UIDocument`.
- Utilizar propiedades de `VisualElement` (`DisplayStyle`) para controlar la visibilidad.
- Automatizar la suscripción de eventos de UI en `Start()`.
- Implementar la lógica de retorno al menú principal incluyendo la desconexión de red.

**Non-Goals:**
- No se rediseñará el archivo `.uxml` ni los estilos `.uss`.
- No se modificará el sistema de combate o de captura de banderas, solo la reacción al fin de partida.

## Decisions

- **Uso de `UIDocument`:** Se prefiere sobre los GameObjects tradicionales para seguir el estándar del proyecto.
- **DisplayStyle.None/Flex:** Se utilizará para mostrar/ocultar el panel sin destruir el objeto, manteniendo el estado de la suscripción al botón.
- **Suscripción en `Start()`:** Se realizará una única vez para evitar múltiples suscripciones si se llamara repetidamente (aunque el fin de partida suele ser único).
- **SceneManager:** Se utilizará para la transición de escenas, asegurando que se invoque la limpieza de la conexión antes de cargar el menú.

## Risks / Trade-offs

- **[Risk]** Error de referencia nula si el `UIDocument` no tiene los elementos "BotoTornar" o "TextResultat".
  - **Mitigation:** Se añadirá una comprobación de nulidad antes de intentar acceder a los elementos o suscribirse.
- **[Risk]** Persistencia de la conexión si `TornarAlMenu` no se invoca correctamente.
  - **Mitigation:** Asegurar que `TornarAlMenu` sea público y esté correctamente vinculado al botón.

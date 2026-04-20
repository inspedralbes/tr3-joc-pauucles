## Context

En Unity, para detectar objetos que no tienen un cuerpo físico sólido (como un área de entrega o un objeto coleccionable cinemático), se utilizan colisionadores configurados como "Trigger". Actualmente, el `CyborgIA` solo detecta colisiones físicas, lo que limita la configuración de los niveles.

## Goals / Non-Goals

**Goals:**
- Añadir el evento `OnTriggerEnter2D` para capturar la entrada en áreas de objetivos.
- Replicar la lógica de negocio existente (recoger dinosaurio, entregar en base).
- Asegurar que el sistema de recompensas de ML-Agents siga funcionando igual que con las colisiones físicas.

**Non-Goals:**
- No se pretende eliminar `OnCollisionEnter2D`, ambos pueden coexistir para dar mayor flexibilidad.
- No se modificará el sistema de búsqueda dinámica de objetivos.

## Decisions

- **Eventos Duales:** Implementar `OnTriggerEnter2D` manteniendo el código de `OnCollisionEnter2D` casi idéntico. Esto permite que el agente funcione tanto si el objetivo es un objeto sólido como si es un sensor (Trigger).
- **Uso de Tags:** Seguir utilizando `CompareTag("Dinosaurio")` y `CompareTag("BaseRoja")` para identificar los objetos que activan el trigger.
- **Acceso a Componentes:** En `OnTriggerEnter2D`, el parámetro es de tipo `Collider2D`, por lo que se accederá a su `transform` para las comparaciones de referencia si es necesario (aunque el tag es el método preferido).

## Risks / Trade-offs

- **[Riesgo] Doble Activación:** Si un objeto tiene colisionadores que disparan ambos eventos (Trigger y Colisión física simultáneamente), el agente podría recibir recompensas dobles.
  - **Mitigación:** La lógica ya comprueba flags como `!tieneDino`, lo que previene la recogida múltiple. Para la entrega en base, el fin del episodio (`EndEpisode`) detiene cualquier procesamiento posterior.
- **[Riesgo] Rendimiento:** Tener ambos métodos activos añade una pequeña carga de procesamiento por cada contacto.
  - **Mitigación:** Es despreciable en un entorno con pocos objetos interactuables.

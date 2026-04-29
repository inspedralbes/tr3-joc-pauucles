## Context

El `DroneAI.cs` fue adaptado recientemente para el modo multijugador, introduciendo una búsqueda dinámica de la bandera del equipo. Durante esta adaptación, se asumió erróneamente que la clase `Bandera` contenía un miembro llamado `teamId`, cuando el nombre correcto es `equipPropietari`.

## Goals / Non-Goals

**Goals:**
- Corregir el error CS1061 en `DroneAI.cs`.
- Asegurar que la lógica de búsqueda dinámica de la bandera funcione según lo previsto.

**Non-Goals:**
- Cambiar nombres de variables en `Bandera.cs`.
- Alterar la lógica funcional de `DroneAI.cs`.

## Decisions

- **Uso de `equipPropietari`**: Se utilizará esta variable de `Bandera.cs` para comparar con el `teamId` del dron en el método `BuscarDinosaurioEquipo`. Es la decisión más directa y segura para restaurar la compilación.

## Risks / Trade-offs

- [Riesgo] → Que existan otras referencias incorrectas.
- [Mitigación] → Revisión exhaustiva del método `BuscarDinosaurioEquipo` y verificación de que `teamId` es el nombre correcto del miembro *dentro* de `DroneAI`.

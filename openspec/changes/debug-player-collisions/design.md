## Context

El sistema de combate PPTLLS se activa mediante colisiones entre jugadores detectadas en `Player.cs`. Actualmente, hay problemas para que este sistema se active de forma consistente. Se necesita visibilidad inmediata de los eventos de colisión en tiempo de ejecución.

## Goals / Non-Goals

**Goals:**
- Proporcionar información detallada (nombre, tag) de cada objeto con el que el jugador colisiona.
- Asegurar que el log se ejecute antes de cualquier lógica de filtrado por tag.

**Non-Goals:**
- Corregir el sistema de colisiones en esta fase (solo diagnóstico).
- Implementar un sistema de logging persistente o avanzado.

## Decisions

- **Logging Síncrono (`Debug.Log`)**: Se utilizará la función estándar de Unity para asegurar que el mensaje aparezca en la consola del editor de forma inmediata.
- **Posicionamiento Estratégico**: El log se insertará en la primera línea de `OnCollisionEnter2D` para capturar todos los eventos, incluso aquellos que no superen el filtro de tag "Player".

## Risks / Trade-offs

- **[Riesgo] Saturación de Consola**: El jugador colisiona constantemente con el suelo u otros elementos decorativos. → **[Mitigación]**: Este cambio es temporal para depuración y debe ser revertido una vez identificado el problema.

## 1. Preparación y Estructura Base

- [x] 1.1 Limpiar `DroneAI.cs` eliminando la lógica antigua y manteniendo la herencia de `Agent`.
- [x] 1.2 Definir los campos necesarios: referencias al dinosaurio, la base, velocidad, y variables para el cálculo de distancia anterior.

## 2. Lógica de Estados y Objetivos

- [x] 2.1 Implementar método para identificar el estado del dinosaurio (`A_Salvo`, `Robado`, `Tirado`).
- [x] 2.2 Implementar lógica para determinar el `targetPosition` dinámicamente según el estado.

## 3. Implementación de ML-Agents

- [x] 3.1 Implementar `CollectObservations` para añadir exactamente las 8 observaciones (posiciones y velocidades x,y).
- [x] 3.2 Implementar `OnActionReceived` para aplicar el movimiento continuo usando `ContinuousActions`, velocidad y `Time.fixedDeltaTime`.
- [x] 3.3 Implementar `Heuristic` para permitir el control manual con las flechas/WASD durante las pruebas.

## 4. Sistema de Recompensas y Refinamiento

- [x] 4.1 Implementar en `FixedUpdate` (o dentro de `OnActionReceived`) la recompensa de `0.01f` si la distancia al objetivo actual disminuye.
- [x] 4.2 Añadir salvaguardas para evitar nulos en las observaciones (fallback a la posición del dron si no hay objetivo).

## 5. Validación

- [x] 5.1 Verificar que el script compila sin errores en el entorno de Unity.
- [x] 5.2 Confirmar que el sensor vectorial está configurado para 8 observaciones en el componente del Inspector.

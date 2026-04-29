## Why

El sistema de colisiones del dron actual presenta fallos en la detección de objetivos durante las pruebas locales, principalmente debido a restricciones estrictas de `teamId` y la falta de un mecanismo de "fail-safe" que asegure que el dron sea premiado al alcanzar la bandera o al portador.

## What Changes

- **Debugging**: Se añade un `Debug.Log` en `OnTriggerEnter2D` para identificar con qué objeto colisiona el dron.
- **Lógica de Colisión Robusta**: Si el objeto colisionado tiene el componente `Bandera` o el tag `Player`, se considerará un éxito.
- **Recompensa Directa**: Se otorgará una recompensa de `1f` (máxima) al dron.
- **Reinicio de Episodio**: Se teletransportará al dinosaurio/ladrón a su punto de origen o spawn aleatorio y se llamará a `EndEpisode()`.
- **Flexibilidad**: Se eliminan las restricciones de equipo (`teamId`) que impiden el funcionamiento correcto en entornos de prueba locales.

## Capabilities

### New Capabilities
- `drone-fail-safe-collision`: Implementación de una lógica de colisión para el dron que prioriza la detección de componentes y tags sobre identificadores de equipo rígidos.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Modificación de la lógica de sensores y triggers.
- Entrenamiento de ML-Agents: Mejora la convergencia del dron al asegurar que las colisiones exitosas sean siempre premiadas.

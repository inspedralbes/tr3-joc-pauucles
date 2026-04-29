## Why

La sincronización actual del dron presenta un retraso visual perceptible ("ghosting") y discrepancias entre lo que ve el Host y los Clientes. Para asegurar una experiencia de juego multijugador competitiva y justa, es imperativo que el dron actúe como un espejo exacto en todas las máquinas, eliminando cualquier procesamiento local en los clientes que pueda causar divergencias físicas o lógicas.

## What Changes

- **Neutralización de Clientes**: Los clientes que no sean Host destruirán componentes de toma de decisiones (`DecisionRequester`), desactivarán el componente de IA principal (`DroneAI`) y pasarán a un modo físico puramente cinemático.
- **Sincronización Agresiva**: Implementación de una interpolación (`Lerp`) con un factor de suavizado de `40f` para una respuesta casi instantánea.
- **Mecanismo de Snap de Seguridad**: Incorporación de una regla de corrección forzada de posición cuando la distancia entre la posición local y la recibida supere las `0.5` unidades.
- **Autoridad Centralizada**: El Host mantendrá la exclusividad en la emisión de datos de movimiento sin procesar actualizaciones entrantes sobre su propia instancia.

## Capabilities

### New Capabilities
- `drone-mirror-sync`: Implementación de una arquitectura de sincronización visual 1:1 de alta fidelidad para agentes IA.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneNetworkSync.cs`: Refactorización crítica de la lógica de inicialización y actualización de red.
- Estabilidad de Escena: Eliminación total de conflictos de colisión e IA en clientes remotos.
- Calidad Visual: Movimiento idéntico en todas las pantallas sin rastro visual.

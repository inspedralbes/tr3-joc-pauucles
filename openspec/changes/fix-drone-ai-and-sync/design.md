## Context

El sistema de drones utiliza ML-Agents para la toma de decisiones en el Host y Socket.IO para replicar esas decisiones (posiciones) en los clientes. Actualmente, la falta de robustez en el sensor de la IA causa errores fatales de ejecución, y la redundancia de sistemas (física+IA) en los clientes impide una visualización fluida de los datos de red.

## Goals / Non-Goals

**Goals:**
- Asegurar que la IA nunca lance una `NullReferenceException` en el sensor.
- Transformar al dron en un objeto visual pasivo en los clientes remotos.
- Garantizar que los mensajes de red se procesen sin interrupciones físicas o lógicas.

**Non-Goals:**
- Cambiar el modelo de entrenamiento de la IA.
- Modificar el sistema de colisiones de los drones para el Host (solo para clientes).

## Decisions

### 1. Observaciones Dinámicas (DroneAI.cs)
Se implementará una búsqueda en cascada en `CollectObservations`:
1. Si existe referencia directa a la bandera y está libre -> Usar posición de la bandera.
2. Si la bandera es nula o está capturada -> Buscar entre los jugadores aquel que tenga la bandera y usar su posición.
3. Fallback -> `Vector3.zero`.
*Rationale*: Esto evita crasheos y permite que el dron siga al portador de la bandera incluso si el objeto físico de la bandera ha sido desactivado/emparentado.

### 2. Estado de "Solo Espectador" (DroneNetworkSync.cs)
En `Start` o `CheckHostStatus`, si el objeto es detectado como remoto:
- `DroneAI.enabled = false`
- `Rigidbody2D.bodyType = RigidbodyType2D.Kinematic`
- `Rigidbody2D.simulated = true` (pero sin fuerzas) o desactivar gravedad si es dinámico.
*Rationale*: Un objeto cinemático no responde a la física de Unity pero permite mover su transform directamente vía `Lerp`, evitando "temblores" por conflicto entre red y gravedad/fuerzas.

### 3. Throttling e Interpolación
- En el Host, se mantiene el envío a 10Hz (0.1s).
- En el Cliente, el `Lerp` usará una velocidad de interpolación de `10f` a `15f` para suavizar el movimiento.

## Risks / Trade-offs

- **[Riesgo] Detección de portador lenta** -> **Mitigación**: Usar `GameManager.Instance.localPlayer` y `remotePlayers` para una búsqueda rápida en lugar de `FindObjectsOfType`.
- **[Riesgo] Dron atraviesa paredes en el cliente** -> **Mitigación**: Al ser puramente visual en el cliente, es aceptable que haya ligeras discrepancias de colisión si el Host garantiza la validez de la posición.

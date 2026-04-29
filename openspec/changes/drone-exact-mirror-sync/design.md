## Context

La sincronización de agentes IA en red suele fallar cuando el cliente intenta predecir o simular localmente lo que el servidor ya ha decidido. Este diseño elimina la simulación en el cliente para transformarlo en un visualizador puro de la autoridad del Host.

## Goals / Non-Goals

**Goals:**
- Lograr una fidelidad visual del 100% entre Host y Cliente.
- Eliminar la latencia percibida mediante interpolación de alta frecuencia.
- Garantizar la integridad física en clientes mediante el uso de Kinematic.

**Non-Goals:**
- Implementar interpolación de red en otros agentes (Jugadores).
- Cambiar la lógica de decisión de `DroneAI.cs` en el Host.

## Decisions

- **Destrucción de DecisionRequester**: Se opta por `Destroy` sobre `enabled = false` para asegurar que ningún código de ML-Agents intente ejecutarse en segundo plano en el cliente remoto.
- **Factor de Lerp 40f**: Se establece un valor agresivo para que el dron no parezca "ir flotando" con retraso, sino que siga el rastro exacto del Host.
- **Snap de 0.5 unidades**: Se elige este umbral porque es lo suficientemente grande como para no ser activado por fluctuaciones normales de red, pero lo suficientemente pequeño como para que un salto de posición no sea visualmente chocante.
- **Kinematic RB en Clientes**: Al ser Kinematic, el dron no reaccionará a colisiones locales (como chocar contra una pared que el Host aún no ha visto), evitando desincronizaciones visuales.

## Risks / Trade-offs

- [Riesgo] → Jitter visual si la red es muy inestable.
- [Mitigación] → El snap de seguridad asegura que, al menos, la posición final sea la correcta, mientras que el Lerp alto suaviza la mayoría de los paquetes.
- [Riesgo] → Diferencia de jerarquías (Dinosaurio emparentado).
- [Mitigación] → El dinosaurio también debe tener una lógica de red similar para que el emparentamiento visual sea coherente.

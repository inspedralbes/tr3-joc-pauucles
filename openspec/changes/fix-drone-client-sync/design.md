## Context

El sistema de sincronización de drones utiliza Socket.IO para enviar la posición desde el Host hacia los Clientes. Actualmente, los clientes experimentan fallos donde los drones desaparecen o no se mueven. Esto se debe a que la interpolación de movimiento fuerza la coordenada Z a 0 (ocultándolos tras el fondo) y a que el registro de los drones en el `GameManager` no siempre es exitoso en el momento del inicio.

## Goals

- **Sincronización Visual Correcta**: Los drones deben mantener su profundidad (Z) para ser visibles.
- **Registro Garantizado**: Asegurar que todos los drones en la escena sean detectables por el `MenuManager` al recibir mensajes de red.
- **Trazabilidad**: Implementar logs que permitan confirmar la recepción y procesamiento de mensajes `DRONE_MOVE`.

## Decisions

### 1. Registro Redundante en GameManager
**Problema**: El registro actual ocurre en `DroneAI.Initialize()`, que puede ejecutarse antes de que `GameManager.Instance` esté disponible.
**Decisión**: Añadir un intento de registro adicional en el `Start()` de `DroneNetworkSync.cs`. Además, en `MenuManager.cs`, si no se encuentra un dron por su `teamId`, se realizará una búsqueda de emergencia en la escena para repoblar la lista del `GameManager`.
**Alternativa considerada**: Usar `Execution Order` en Unity, pero es propenso a errores manuales en el editor.

### 2. Corrección del Lerp y Eje Z
**Problema**: `ReceiveUpdate` sobreescribe el eje Z con 0.
**Decisión**: Capturar el eje Z actual del transform antes de aplicar la nueva `targetPosition`.
```csharp
targetPosition = new Vector3(msg.x, msg.y, transform.position.z);
```
**Rationale**: Los drones operan en un entorno 2D pero requieren una Z específica (-0.15f) para la correcta superposición de capas.

### 3. Sistema de Logs en Cascada
**Decisión**: 
- Nivel 1 (Entrada): `MenuManager.cs` registrará si el JSON de `DRONE_MOVE` ha llegado.
- Nivel 2 (Búsqueda): `MenuManager.cs` registrará si ha encontrado el dron correspondiente en la lista.
- Nivel 3 (Aplicación): `DroneNetworkSync.cs` registrará que ha actualizado su `targetPosition`.
**Mitigación de ruido**: Usar logs condicionales por frames (ej. cada 300 frames) para evitar saturar la consola.

## Risks / Trade-offs

- **[Riesgo] Rendimiento**: Buscar drones en la escena en cada mensaje fallido. -> **Mitigación**: La búsqueda de emergencia solo ocurrirá si la lista está vacía o si el ID no existe, y se cacheará el resultado.
- **[Riesgo] Sprawl de logs**: Demasiada información en consola. -> **Mitigación**: Usar prefijos claros como `[DRONE-SYNC-FIX]` para facilitar el filtrado.

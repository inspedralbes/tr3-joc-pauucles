## Why

El sistema actual de inicio de minijuegos presenta latencias y discrepancias visuales entre clientes debido a que ambos intentan iniciar la lógica de colisión de forma independiente o asíncrona. Para garantizar una experiencia multijugador coherente y fluida, es necesario centralizar la autoridad del inicio de combate en el Host (Master), asegurando que ambos clientes abran la misma interfaz al mismo tiempo mediante una orden de red obligatoria.

## What Changes

- **Autoridad de Detección**: Solo el Host procesará las colisiones entre jugadores en `OnCollisionEnter2D`.
- **Nuevo Mensaje de Red**: Implementación del evento `START_MINIGAME` que transporta los IDs de los participantes y el ID del minijuego seleccionado.
- **Sincronización de UI**: Los clientes dejarán de abrir el minijuego localmente y esperarán exclusivamente la señal de red para mostrar la interfaz y congelar el movimiento.
- **Limpieza de Lógica Local**: Eliminación de funciones de inicio inmediato en `Player.cs` que no pasen por la validación del Host.

## Capabilities

### New Capabilities
- `minigame-host-authority`: Sistema de inicio de minijuegos basado en autoridad absoluta del Host para garantizar sincronización temporal y lógica 1:1.

### Modified Capabilities
- Ninguna.

## Impact

- `Player.cs`: Refactorización de `OnCollisionEnter2D` para delegar al Host.
- `MenuManager.cs` / `GameManager.cs`: Implementación del listener para el evento de red y lógica de apertura síncrona.
- Experiencia de Usuario: Eliminación de desincronizaciones visuales al iniciar combates.

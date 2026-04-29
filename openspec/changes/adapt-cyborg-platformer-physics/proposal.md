## Why

El agente `CyborgIA` requiere un comportamiento más acorde a un juego de plataformas, incluyendo salto y animaciones visuales. Actualmente su movimiento es básico y no aprovecha los recursos artísticos disponibles (Animator). Esta actualización permitirá entrenar al agente en entornos que requieran saltos y proporcionará feedback visual del estado del agente.

## What Changes

- Adaptación de la física de movimiento para respetar la gravedad en un entorno 2D de plataformas.
- Implementación de la capacidad de salto basada en acciones discretas y detección simple de suelo.
- Integración con el componente `Animator` para reflejar el estado de movimiento (Speed) y acciones (Jump).
- Reasignación de acciones en `OnActionReceived` y `Heuristic` para soportar izquierda, derecha y salto.

## Capabilities

### New Capabilities
- `platformer-cyborg-ai`: Capacidad del agente Cyborg para navegar plataformas usando saltos y movimiento lateral, sincronizado con animaciones.

### Modified Capabilities
<!-- No se modifican requisitos de capacidades existentes -->

## Impact

- Script `CyborgIA.cs`.
- Componente `Animator` en el GameObject del Cyborg.
- Configuración de Rigidbody2D (Gravity Scale = 1).

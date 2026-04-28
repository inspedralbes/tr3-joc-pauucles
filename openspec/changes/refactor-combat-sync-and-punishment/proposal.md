## Why

El sistema de combate actual presenta problemas de sincronización en red, permitiendo que una sola colisión dispare múltiples minijuegos o que los castigos por derrota (stun y reducción de vida) no se apliquen de forma coherente entre los clientes. Esta refactorización busca implementar un control de estado riguroso ("candado") y una autoridad de resolución clara para garantizar que la experiencia competitiva sea justa y libre de errores visuales o lógicos.

## What Changes

- **Candado de Colisión (Player.cs)**: Introducción de la bandera `enCombate` para bloquear triggers redundantes durante un enfrentamiento activo o estado de stun.
- **Apertura Sincronizada**: El Host iniciará la UI localmente y emitirá el mensaje de red de forma atómica, asegurando que ambos participantes entren al minijuego simultáneamente.
- **Resolución Estricta de Identidad**: Modificación de todos los minijuegos para que transmitan nombres de usuario exactos a `FinalitzarCombat`.
- **Lógica de Castigo con Autoridad Local**: El `MinijocUIManager` validará el nombre de usuario recibido contra el local antes de ejecutar la derrota o victoria, evitando penalizaciones cruzadas.
- **Animación Hurt**: Integración del trigger de animación "Hurt" en el flujo de derrota para mejorar el feedback visual.
- **Limpieza de Estado**: Implementación de un reset completo de variables de combate en `LimpiarEstadoCombate`.

## Capabilities

### New Capabilities
- `combat-state-locking`: Prevención de múltiples activaciones de combate mediante estados persistentes.
- `guaranteed-punishment-sync`: Sincronización exacta de ganadores y perdedores basada en identificadores únicos en red.
- `combat-visual-feedback`: Mejora de la respuesta visual ante el daño mediante animaciones.

### Modified Capabilities
- Ninguna.

## Impact

- `Player.cs`: Refactorización de la lógica de colisión y estados de combate.
- `MinijocUIManager.cs`: Rediseño del flujo de finalización de combate.
- Scripts de Minijuegos: Ajuste en la devolución de resultados.
- Experiencia de Usuario: Mayor fluidez y precisión en los enfrentamientos multijugador.

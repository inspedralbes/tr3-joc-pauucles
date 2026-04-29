## Why

El sistema de combate actual presenta problemas de sincronización de red y una resolución de minijuegos inconsistente, lo que a menudo resulta en que los jugadores ganadores sufran penalizaciones por error o que la interfaz no aparezca simultáneamente. Esta propuesta busca restaurar y perfeccionar la lógica de combate sincronizado, garantizando una identidad única para el perdedor, una aplicación de stun precisa y un feedback visual claro mediante animaciones.

## What Changes

- **Sincronización de Inicio Host/Cliente**: Solo el Host procesará la colisión inicial y emitirá el mensaje de red, pero ambos clientes abrirán la UI de forma atómica para evitar lag visual.
- **Identidad de Perdedor Garantizada**: Refactorización de las lógicas de todos los minijuegos para asegurar que el mensaje de resultado siempre identifique correctamente al perdedor basado en el nombre de usuario.
- **Filtro de Castigo Local**: El `MinijocUIManager` validará el nombre de usuario antes de aplicar efectos de derrota (vides y stun), asegurando que el ganador nunca sea castigado.
- **Feedback Visual de Daño**: Integración del trigger de animación "Hurt" en el flujo de derrota del jugador.
- **Protección de Reentrancia**: Uso de banderas de estado (`enCombate`, `combatAcabat`) para evitar que una colisión dispare múltiples procesos de minijuego.

## Capabilities

### New Capabilities
- `combat-sync-perfection`: Sistema de combate multijugador con autoridad de Host y replicación síncrona en Clientes.
- `guaranteed-punishment-sync`: Lógica de resolución de minijuegos basada en identidad única de usuario para evitar falsos positivos en los castigos.

### Modified Capabilities
- Ninguna.

## Impact

- `Player.cs`: Refactorización de la lógica de colisión, estados de combate y animaciones.
- `MinijocUIManager.cs`: Rediseño del flujo de finalización de combate con validación de identidad.
- Scripts de Minijuegos (`MinijocPPTLLSLogic`, etc.): Ajuste de la resolución de resultados para incluir perdedores explícitos.

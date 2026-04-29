## ADDED Requirements

### Requirement: Sincronización de Apertura de Minijuego
El sistema SHALL garantizar que tanto el Host como el Cliente abran el minijuego simultáneamente.

#### Scenario: Detección por el Host
- **WHEN** el Host detecta una colisión
- **THEN** el Host abre la UI localmente E inmediatamente envía el mensaje `MINIJOC_START` por red.

### Requirement: Resolución Basada en Identidad
El sistema SHALL aplicar las consecuencias del combate basándose exclusivamente en la coincidencia de nombres de usuario locales con el resultado recibido.

#### Scenario: Procesamiento de resultado local
- **WHEN** se llama a `FinalitzarCombat` con un perdedor específico
- **THEN** el sistema SHALL ejecutar `ProcesarDerrota` solo si el nombre de usuario local coincide con el del perdedor.

### Requirement: Prevención de Doble Resolución
El sistema SHALL proteger el flujo de finalización de combate contra ejecuciones duplicadas del mismo resultado.

#### Scenario: Cierre de combate
- **WHEN** se inicia la función `FinalitzarCombat`
- **THEN** el sistema SHALL utilizar la bandera `combatAcabat = true` para bloquear entradas posteriores.

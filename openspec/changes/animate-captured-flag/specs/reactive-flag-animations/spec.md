## ADDED Requirements

### Requirement: Detección de Movimiento Reactivo
El sistema DEBE detectar si la bandera se está desplazando comparando su posición actual con la del frame anterior.

#### Scenario: Movimiento detectado
- **WHEN** la distancia entre la posición actual y la última posición guardada es superior a 0.001 unidades.
- **THEN** el sistema DEBE marcar el estado de movimiento como verdadero.

#### Scenario: Objeto estático
- **WHEN** la distancia entre la posición actual y la última posición guardada es inferior o igual a 0.001 unidades.
- **THEN** el sistema DEBE marcar el estado de movimiento como falso.

### Requirement: Animación Durante el Transporte
La bandera DEBE activar sus animaciones de movimiento únicamente cuando está siendo transportada por un jugador.

#### Scenario: Bandera siendo portada y moviéndose
- **WHEN** el transform de la bandera tiene un padre asignado Y se detecta movimiento.
- **THEN** el parámetro `isWalking` del `Animator` DEBE establecerse en verdadero.

#### Scenario: Bandera siendo portada pero quieta
- **WHEN** el transform de la bandera tiene un padre asignado Y NO se detecta movimiento.
- **THEN** el parámetro `isWalking` del `Animator` DEBE establecerse en falso.

### Requirement: Persistencia de Posición por Frame
El sistema DEBE actualizar la referencia de "última posición" al final de cada ciclo de actualización.

#### Scenario: Actualización de referencia
- **WHEN** finaliza el procesamiento del método `Update`.
- **THEN** el valor de `ultimaPosicio` DEBE igualarse al valor actual de `transform.position`.

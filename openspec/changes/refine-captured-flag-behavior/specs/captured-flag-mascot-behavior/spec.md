## ADDED Requirements

### Requirement: Detección de Movimiento Reactivo Refinada
La bandera DEBE detectar su movimiento basándose en la distancia recorrida entre frames con un umbral de sensibilidad de 0.002f.

#### Scenario: Movimiento capturado
- **WHEN** la distancia entre la posición actual y la última posición registrada es superior a 0.002f.
- **THEN** el parámetro `isWalking` del animador DEBE activarse.

### Requirement: Sincronización de Orientación (FlipX)
La bandera DEBE reflejar automáticamente la orientación horizontal del jugador que la transporta.

#### Scenario: Sincronización con el jugador
- **WHEN** el `SpriteRenderer` del objeto padre (jugador) cambia su estado `flipX`.
- **THEN** el `SpriteRenderer` de la bandera DEBE igualar ese valor de `flipX`.

### Requirement: Posicionamiento Dinámico como Mascota
La bandera DEBE ajustar su posición local para seguir al jugador desde una posición lateral natural y mantenerse a ras de suelo.

#### Scenario: Posición a la derecha
- **WHEN** el `flipX` de la bandera es verdadero (mirando a la izquierda).
- **THEN** la `localPosition` de la bandera DEBE ser `(0.5f, 0f, 0f)`.

#### Scenario: Posición a la izquierda
- **WHEN** el `flipX` de la bandera es falso (mirando a la derecha).
- **THEN** la `localPosition` de la bandera DEBE ser `(-0.5f, 0f, 0f)`.

### Requirement: Actualización de Referencia de Posición
El sistema DEBE actualizar la última posición conocida al final de cada ciclo de actualización para permitir el cálculo del delta de movimiento.

#### Scenario: Persistencia de posición por frame
- **WHEN** finaliza el procesamiento del bloque de lógica de transporte en `Update`.
- **THEN** el valor de `ultimaPosicio` DEBE igualarse al valor actual de `transform.position`.

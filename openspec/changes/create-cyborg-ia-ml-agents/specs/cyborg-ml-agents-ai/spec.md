## ADDED Requirements

### Requirement: Inicialización del Agente
El script `CyborgIA` DEBE obtener la referencia al `Rigidbody2D` durante la inicialización para gestionar el movimiento basado en físicas.

#### Scenario: Obtención del Rigidbody2D
- **WHEN** se inicia el juego o se instancia el Agente
- **THEN** se busca y almacena el componente `Rigidbody2D` adjunto al objeto.

### Requirement: Reinicio de Episodio
Al inicio de cada episodio, el sistema DEBE resetear el estado de posesión del dinosaurio y posicionar aleatoriamente tanto al Agente como al objetivo.

#### Scenario: Comienzo de nuevo episodio
- **WHEN** comienza un nuevo episodio (llamada a `OnEpisodeBegin`)
- **THEN** se establece `tieneDino` a false, se desvincula el dinosaurio si estaba emparentado, y se mueven el Cyborg y el dinosaurio a posiciones aleatorias locales dentro de un rango predefinido.

### Requirement: Colección de Observaciones
El Agente DEBE recibir información sobre su posición, la posición del dinosaurio, la posición de la base y si posee el dinosaurio.

#### Scenario: Generación de observaciones
- **WHEN** el motor de ML-Agents solicita observaciones
- **THEN** se añaden al sensor las posiciones locales del Cyborg, del dinosaurio objetivo, de la base de destino y el valor flotante (1f o 0f) del flag `tieneDino`.

### Requirement: Gestión de Acciones y Movimiento
El Agente DEBE responder a acciones discretas para moverse en el espacio 2D y recibir una pequeña penalización por cada paso para incentivar la rapidez.

#### Scenario: Ejecución de movimiento
- **WHEN** se recibe un valor en `DiscreteActions[0]` (1: Arriba, 2: Abajo, 3: Izquierda, 4: Derecha)
- **THEN** se aplica la `linearVelocity` correspondiente al `Rigidbody2D` y se añade una recompensa negativa de -0.001f.

### Requirement: Recogida de Dinosaurio
El Agente DEBE detectar el contacto con el dinosaurio y "recogerlo" si no tiene uno ya.

#### Scenario: Colisión con el dinosaurio
- **WHEN** el Cyborg choca con el objeto `targetDinosaurio` y `tieneDino` es false
- **THEN** se establece `tieneDino` a true, se añade una recompensa de 0.5f y se emparenta el dinosaurio al Cyborg centrándolo.

### Requirement: Entrega en Base
El Agente DEBE detectar el contacto con la base de destino mientras transporta al dinosaurio para completar el objetivo.

#### Scenario: Colisión con la base
- **WHEN** el Cyborg choca con `baseDestino` y `tieneDino` es true
- **THEN** se desvincula el dinosaurio, se añade una recompensa de 1f y se finaliza el episodio exitosamente.

### Requirement: Control Heurístico
El sistema DEBE permitir el control manual del Agente mediante el teclado para facilitar las pruebas de depuración.

#### Scenario: Control manual con flechas
- **WHEN** el usuario presiona las flechas del teclado en modo Heurístico
- **THEN** se asignan los valores correspondientes (1 a 4) al búfer de acciones discretas.

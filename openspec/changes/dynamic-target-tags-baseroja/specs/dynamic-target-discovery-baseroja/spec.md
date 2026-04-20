## ADDED Requirements

### Requirement: Descubrimiento dinámico de objetivos por Tag
El sistema DEBE permitir localizar automáticamente los objetos con los Tags "Dinosaurio" y "BaseRoja" al inicio de cada episodio para flexibilizar el entorno de entrenamiento.

#### Scenario: Localización de objetivos al inicio del episodio
- **WHEN** el método `OnEpisodeBegin` se ejecuta
- **THEN** el sistema busca todos los GameObjects con los Tags especificados y asigna el transform del más cercano a las variables privadas.

### Requirement: Criterio del Objetivo Más Cercano
En caso de múltiples instancias de un mismo Tag, el sistema DEBE seleccionar el objeto cuya distancia euclidiana al agente sea la menor.

#### Scenario: Selección por proximidad
- **WHEN** hay varios objetos con el Tag "Dinosaurio" en la escena
- **THEN** el sistema itera calculando las distancias usando `Vector2.Distance` y selecciona el que tenga el valor de distancia mínimo.

### Requirement: Manejo Robusto de Referencias Nulas
El sistema DEBE evitar errores de referencia nula durante la recolección de observaciones en caso de que no se encuentren objetivos en la escena.

#### Scenario: Ausencia de objetivos en observaciones
- **WHEN** no se encuentran objetos con el Tag "Dinosaurio" o "BaseRoja" y se solicita `CollectObservations`
- **THEN** el sistema añade `Vector3.zero` al sensor para las posiciones faltantes y finaliza el método preventivamente.

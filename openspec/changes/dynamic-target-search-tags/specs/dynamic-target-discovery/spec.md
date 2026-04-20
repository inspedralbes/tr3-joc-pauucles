## ADDED Requirements

### Requirement: Búsqueda dinámica de objetivos por Tag
El sistema DEBE permitir localizar automáticamente los objetos con los Tags "Dinosaurio" y "Base" al inicio de cada episodio para dinamizar el entrenamiento.

#### Scenario: Localización exitosa de objetivos
- **WHEN** el método `OnEpisodeBegin` se ejecuta
- **THEN** el sistema busca todos los GameObjects con los Tags especificados y asigna el transform del más cercano a las variables internas.

### Requirement: Priorización por Proximidad
En caso de que existan múltiples instancias con el mismo Tag en la escena, el sistema DEBE seleccionar el objeto que se encuentre a menor distancia física del agente.

#### Scenario: Selección del dinosaurio más cercano
- **WHEN** existen tres objetos con el Tag "Dinosaurio" a diferentes distancias
- **THEN** el sistema calcula las distancias usando `Vector2.Distance` y selecciona el que tenga el valor de distancia más bajo.

### Requirement: Robusticidad ante Ausencia de Objetivos
El sistema DEBE manejar correctamente situaciones donde no se encuentren objetos con los Tags esperados para evitar errores de referencia nula durante la colección de observaciones.

#### Scenario: Manejo de objetivos no encontrados
- **WHEN** no existen objetos con el Tag "Dinosaurio" en la escena y se solicitan observaciones
- **THEN** el sistema añade un `Vector3.zero` al sensor en lugar de intentar acceder a las propiedades del transform nulo.

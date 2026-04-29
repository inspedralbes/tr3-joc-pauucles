## ADDED Requirements

### Requirement: Obtención de colores de sala
El sistema DEBE obtener los colores de los equipos directamente de las propiedades `teamAColor` y `teamBColor` de `MenuManager.Instance.currentRoomData`.

#### Scenario: Lectura de datos de sala
- **WHEN** se inicia el proceso de instanciación de banderas.
- **THEN** el sistema DEBE acceder a los strings de color configurados para ambos equipos.

### Requirement: Mapeo estricto de Prefabs por Color
El sistema DEBE seleccionar el prefab de dinosaurio basándose estrictamente en el string de color recibido, manejando al menos los colores "Groc", "Blau", "Verd" y "Vermell" (o sus equivalentes).

#### Scenario: Selección de color válido
- **WHEN** el color de un equipo es "Azul".
- **THEN** el sistema DEBE seleccionar el `banderaBlava` prefab para instanciar.

#### Scenario: Color no reconocido
- **WHEN** el color recibido no coincide con ninguno de los predefinidos.
- **THEN** el sistema SHALL seleccionar un prefab por defecto para asegurar la continuidad del juego.

### Requirement: Asignación de Equipos Propietarios
Tras la instanciación, el sistema DEBE asignar la variable `equipPropietari` al script `Bandera` correspondiente.

#### Scenario: Inicialización de bandera de equipo A
- **WHEN** se instancia la bandera del equipo A.
- **THEN** el valor "A" DEBE escribirse en el campo `equipPropietari` del script instanciado.

## ADDED Requirements

### Requirement: Instanciació de banderes per color
El `GameManager` SHALL instanciar dues banderes al inici de la partida, una per a cada equip, utilitzant el prefab que coincideixi amb el color assignat.

#### Scenario: Banderes en iniciar combat
- **WHEN** S'inicia la partida (mètode `Start` o inicialització).
- **THEN** El sistema consulta els colors de `teamAColor` i `teamBColor` a través del `MenuManager`.
- **THEN** Instancia la bandera de l'Equip A prop de `PuntSpawn_Equip1` (+2 offset X).
- **THEN** Instancia la bandera de l'Equip B prop de `PuntSpawn_Equip2` (+2 offset X).

### Requirement: Mapatge de noms de color
El sistema SHALL reconèixer els noms de color retornats pel backend per seleccionar el prefab correcte.
- "Blau" -> `banderaBlava`
- "Vermell" / "Rojo" -> `banderaVermella`
- "Groc" / "Amarillo" -> `banderaGroga`
- "Verd" / "Verde" -> `banderaVerda`

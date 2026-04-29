## ADDED Requirements

### Requirement: Local Skin Storage
El sistema SHALL emmagatzemar el nom de la skin equipada a `PlayerPrefs` un cop l'usuari s'ha autenticat correctament.

#### Scenario: Skin saved on login
- **WHEN** l'usuari fa login amb èxit
- **THEN** el valor de `skinEquipada` de la resposta del backend s'ha de desar a `PlayerPrefs` amb la clau "skinEquipada"

### Requirement: Default Skin Fallback
El sistema SHALL utilitzar una skin per defecte ("Woodcutter") si no es troba cap valor desat a `PlayerPrefs`.

#### Scenario: No skin saved
- **WHEN** s'intenta recuperar la skin i la clau no existeix
- **THEN** s'ha de retornar "Woodcutter"

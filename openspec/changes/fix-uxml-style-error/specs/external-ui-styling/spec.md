## ADDED Requirements

### Requirement: Estilització Externa de Desplegables
El sistema HA D'utilitzar fitxers d'estil externs (.uss) per gestionar les propietats visuals complexes dels components de la interfície.

#### Scenario: Aplicació de límit d'alçada a desplegables
- **WHEN** el fitxer `MenuStyles.uss` està vinculat a l'UXML.
- **THEN** tots els contenidors interns de desplegables (.unity-base-dropdown__container-inner) HAN DE tenir una alçada màxima de 200px.

### Requirement: Neteja d'UXML
L'arxiu UXML NO HA DE contenir definicions d'estil textuals directes dins d'etiquetes `<Style>` sense atribut `src`.

#### Scenario: Vinculació correcta d'estils
- **WHEN** s'edita el fitxer `MenuUI.uxml`.
- **THEN** s'ha d'utilitzar l'atribut `src` per referenciar el fitxer `.uss`.

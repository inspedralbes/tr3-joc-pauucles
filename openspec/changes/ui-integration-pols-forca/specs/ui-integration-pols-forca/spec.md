## ADDED Requirements

### Requirement: Vinculació d'Elements de UI
El sistema HA DE ser capaç d'identificar i emmagatzemar referències a elements de l'UI Toolkit (Labels i VisualElements) a partir d'un element arrel.

#### Scenario: Inicialització Exitosa
- **WHEN** `InicialitzarUI(VisualElement root)` és cridat
- **THEN** els elements amb IDs `TextTempsPols` i `BarraJ1Pols` HAN DE ser localitzats i assignats a variables internes.

### Requirement: Actualització Visual en Temps Real
El sistema HA DE reflectir l'estat intern del joc (temps i puntuació) en la interfície d'usuari durant cada frame.

#### Scenario: Feedback del Temporitzador
- **WHEN** el joc està actiu (`jocActiu` és cert)
- **THEN** l'etiqueta de text HA DE mostrar el `tempsRestant` formatat amb un decimal.

#### Scenario: Feedback de la Barra de Progrés
- **WHEN** la `puntuacioJ1` canvia durant el joc
- **THEN** l'estil d'amplada (`width`) de la `barraJ1` HA DE ser actualitzat com un percentatge (`Length.Percent`) equivalent a la puntuació.

### Requirement: Integració al Gestor de UI
El `MinijocUIManager` HA DE coordinar l'activació visual del contenidor del pols de força i la seva lògica.

#### Scenario: Activació des de la Ruleta
- **WHEN** es determina que el minijoc a jugar és el de pols de força
- **THEN** el contenidor `#ContenidorPolsForca` HA DE ser activat i el minijoc HA DE ser inicialitzat visualment i lògicament.

## ADDED Requirements

### Requirement: Connexió robusta amb la UI
El sistema ha de ser capaç de connectar-se amb els elements de la interfície d'usuari (labels i botons) sense dependre exclusivament dels seus noms interns, utilitzant cerques per tipus i índex.

#### Scenario: Inicialització de la UI genèrica
- **WHEN** el minijoc s'inicia
- **THEN** s'obté l'arrel de la UI del component `UIDocument`, es busquen les etiquetes per actualitzar el text i s'assignen els events als dos primers botons trobats.

### Requirement: Gestió de resposta centralitzada
El sistema ha de disposar d'un mètode centralitzat per gestionar la resposta de l'usuari que inclogui notificacions de depuració i tancament de la UI.

#### Scenario: Resposta de l'usuari
- **WHEN** un botó de resposta és clicat
- **THEN** es desactiva el joc, s'emet un log de depuració, es tanca el `GameObject` i es comunica el resultat al jugador local.

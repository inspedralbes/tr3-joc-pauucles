## ADDED Requirements

### Requirement: Tornar al Login des del Lobby
L'usuari HA DE poder tornar a la pantalla de login des del Lobby mitjançant el botó de tancar (X).

#### Scenario: Clic a tancar lobby
- **WHEN** l'usuari clica al botó `btnTancarLobby` des de la pantalla de Lobby
- **THEN** el sistema amaga la `pantallaLobby` i mostra la `pantallaLogin`.

### Requirement: Tancar Login
El botó de tancar de la finestra de login HA DE ser funcional (per tancar la finestra o l'aplicació).

#### Scenario: Clic a tancar login
- **WHEN** l'usuari clica al botó `btnTancar` des de la pantalla de Login
- **THEN** el sistema executa l'acció de tancar (per a proves, pot simplement tornar a mostrar la pantalla inicial o tancar el pop-up de login si n'hi hagués).

### Requirement: Cancel·lar Creació de Sala
L'usuari HA DE poder tancar el pop-up de configuració de sala sense crear-la.

#### Scenario: Clic a botó Cancel·lar
- **WHEN** l'usuari clica al botó `btnConfirmarSala` (que té el text "Cancelar") dins del pop-up de creació
- **THEN** el sistema amaga el `popUpCrearSala` sense fer cap petició al servidor.

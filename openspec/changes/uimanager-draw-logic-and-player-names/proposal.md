## Why

Actualment, els empats en minijocs com Pedra-Paper-Tisores tanquen la interfície, obligant els jugadors a reiniciar el combat des de zero (col·lisionant de nou), cosa que trenca el ritme de joc. A més, els missatges de victòria són massa genèrics ("J1" o "J2"), dificultant la identificació de qui ha guanyat realment en una partida multijugador.

## What Changes

- **Lògica d'Empat Persistent**: En cas d'empat a PPTLLS (i Parells/Senars si s'escau), la UI no es tancarà. Es mostrarà el missatge "Empat! Torneu a triar!", es reiniciaran les variables d'elecció i es permetrà una nova selecció immediata.
- **Identificació per Nom**: Substitució dels identificadors genèrics "J1" i "J2" pel nom real del GameObject del jugador (`jugador1.name`, `jugador2.name`) en els missatges de resultat.

## Capabilities

### New Capabilities
- `uimanager-draw-retry`: Sistema de reintent immediat en cas d'empat en minijocs de selecció.
- `uimanager-player-identification`: Ús de noms d'instància per a un feedback més clar en els resultats.

### Modified Capabilities
- `ui-delayed-feedback`: Actualització dels missatges de resultat per utilitzar noms de jugadors.

## Impact

- **MinijocUIManager.cs**: Modificació de la resolució de PPTLLS i Parells/Senars per gestionar l'estat d'empat i la generació de strings de feedback.
- **Experiència d'usuari**: Millora en la continuïtat del combat i claredat en el guanyador.

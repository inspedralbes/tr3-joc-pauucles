## Why

Actualment la Pantalla de Títol només té l'opció de començar el joc cap al login, però no ofereix una manera neta i directa de tancar l'aplicació per a l'usuari. Afegir un botó de sortir és un estàndard d'usabilitat necessari per a qualsevol aplicació de sobretaula o build nativa.

## What Changes

- **Nou Botó de Sortida**: Addició del botó `btnExitGame` al `MenuManager`.
- **Lògica de Tancament**: Implementació de l'esdeveniment de clic que tanca l'aplicació (`Application.Quit`) i afegeix un log de confirmació.
- **Vincle amb la UI**: Actualització del mètode de vinculació d'elements per incloure aquest nou component.

## Capabilities

### New Capabilities
- `title-screen-exit`: Capacitat de tancar l'aplicació des de la interfície inicial.

### Modified Capabilities
- `foundations`: S'inclou la funcionalitat de sortida dins del flux base del joc.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Inclusió del nou camp de botó i lògica d'esdeveniment.
- Fitxer UXML del menú: Caldrà assegurar-se que existeix un botó anomenat "btnExitGame" dins de la jerarquia de la pantalla de títol.

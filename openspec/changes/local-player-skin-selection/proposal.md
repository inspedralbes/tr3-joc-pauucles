## Why

Actualment, el jugador local s'instancia amb un prefab fix, ignorant la personalització (skin) que l'usuari pot tenir seleccionada al seu perfil de base de dades. Aquesta funcionalitat permetrà que l'aparença del personatge al joc reflecteixi l'elecció de l'usuari, millorant la immersió i la persistència de les preferències del jugador.

## What Changes

- **Persistència local de la skin**: `MenuManager.cs` desarà el nom de la skin equipada (obtingut del backend) en els `PlayerPrefs` en el moment del login.
- **Configuració de skins al GameManager**: `GameManager.cs` inclourà una llista configurable des de l'inspector per mapejar noms de skins amb els seus respectius prefabs.
- **Instanciació dinàmica**: La lògica d'arrencada de la partida llegirà la skin desada i instanciarà el prefab corresponent en lloc del prefab per defecte.
- **Ajust de càmera**: S'assegurarà que el sistema de càmera segueixi el nou objecte instanciat dinàmicament per mantenir la jugabilitat.

## Capabilities

### New Capabilities
- `player-skin-persistence`: Capacitat de desar i recuperar la skin seleccionada entre sessions.
- `dynamic-player-spawning`: Sistema per instanciar diferents prefabs de jugador segons una configuració de mapeig.

### Modified Capabilities
- `foundations`: Actualització de la lògica base d'instanciació del jugador i seguiment de càmera.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Canvi en la gestió de la resposta del login.
- `DAMT3Atrapa la bandera/Assets/Scripts/GameManager.cs`: Ampliació de dades (SkinMapping) i canvi en el mètode d'instanciació.
- Escenes de joc: Caldrà configurar la llista de `skinsDisponibles` al component GameManager de l'escena.

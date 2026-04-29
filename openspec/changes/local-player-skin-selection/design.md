## Context

Actualment, el `MenuManager.cs` obté la skin de l'usuari des del backend però no la persisteix de manera que pugui ser consultada fàcilment pel `GameManager.cs` en una altra escena. El `GameManager.cs` té prefabs de skins hardcoded en camps individuals, cosa que dificulta la cerca dinàmica. Es requereix un sistema de mapeig estructural i persistència mitjançant `PlayerPrefs`.

## Goals / Non-Goals

**Goals:**
- Persistir la skin equipada de l'usuari en el moment del login.
- Centralitzar els prefabs de skins en una llista de `SkinMapping` al `GameManager`.
- Implementar la instanciació dinàmica basada en la skin emmagatzemada.
- Assegurar que la càmera segueix el jugador instanciat.

**Non-Goals:**
- Implementar una botiga de skins (només gestió de l'equipada).
- Canviar el sistema de xarxa per a les skins (es manté la lògica de `NetworkSync` existent).

## Decisions

### 1. Persistència via PlayerPrefs
- **Decisió**: Utilitzar `PlayerPrefs.SetString("skinEquipada", ...)` al `MenuManager`.
- **Racional**: És la forma més senzilla i estàndard de passar dades simples entre escenes en Unity sense dependre de singletons complexos que puguin perdre's en recàrregues.

### 2. Estructura SkinMapping
- **Decisió**: Crear un `struct` serialitzable dins de `GameManager.cs`.
- **Racional**: Permet una configuració neta des de l'Inspector d'Unity, associant un identificador string amb un recurs de prefab.

### 3. Seguiment de Càmera
- **Decisió**: Cercar components `CinemachineVirtualCamera` o `MainCamera` i assignar el `Transform` del nou jugador.
- **Racional**: Garanteix que la jugabilitat no es trenqui en canviar l'objecte físic del jugador a l'escena.

## Risks / Trade-offs

- **[Risc] Skin no trobada** → **Mitigació**: Establir "Woodcutter" com a fallback obligatori tant al `PlayerPrefs` com a la lògica de cerca al `GameManager`.
- **[Risc] Referències de càmera nul·les** → **Mitigació**: Fer servir `GameObject.FindGameObjectWithTag("MainCamera")` o recerca de components si no estan assignats prèviament.

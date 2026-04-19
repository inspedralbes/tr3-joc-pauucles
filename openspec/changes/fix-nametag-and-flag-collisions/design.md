## Context

El joc utilitza un sistema d'equips (A i B) on cada equip té una bandera associada segons el color triat a la sala. Actualment, el `GameManager` instancia les banderes però no els assigna cap propietat d'equip, cosa que fa que `Bandera.cs` no pugui filtrar les col·lisions. D'altra banda, el personatge local s'instancia però el seu component de text (Nametag) no s'actualitza amb el nom d'usuari de la sessió.

## Goals / Non-Goals

**Goals:**
- Assignar `equipPropietari` a les banderes instanciades.
- Ignorar col·lisions entre jugadors i la seva pròpia bandera.
- Mostrar el nom d'usuari local sobre el seu personatge.

**Non-Goals:**
- Canviar el sistema de xarxa per a les banderes (segueixen sent locals per ara).
- Implementar la lògica de "devolució" de bandera (només s'implementa el filtre de col·lisió).

## Decisions

### 1. Propietat d'equip a Bandera.cs
S'afegirà un camp `public string equipPropietari` a l'script `Bandera`.
- **Racional**: Permet una identificació ràpida i directa durant la fase de col·lisió.

### 2. Filtre de col·lisió a Bandera.cs
Dins del mètode de col·lisió de la bandera, es buscarà l'equip del jugador atacant.
- **Racional**: Si l'equip del jugador coincideix amb el de la bandera, la col·lisió es descarta immediatament per evitar interaccions no desitjades.

### 3. Actualització del Nametag Local al GameManager
Es realitzarà una cerca del component `TextMeshPro` (o el text corresponent) dins del `LocalPlayer` instanciat per assignar-li el `username` guardat al `MenuManager`.
- **Racional**: Centralitza la configuració visual del jugador local en el mateix punt on s'instancia.

## Risks / Trade-offs

- **[Risk]** Si el prefab del jugador no té el Nametag amb el nom esperat o en la ruta esperada, la cerca fallarà. -> **Mitigation**: S'utilitzarà `GetComponentInChildren` de forma segura.
- **[Trade-off]** L'ús de strings ("A", "B") per als equips és senzill però propens a errors tipogràfics. -> **Mitigation**: Es farà servir la informació directament de `currentRoomData` per mantenir la coherència.

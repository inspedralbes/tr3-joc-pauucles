## Context

Es restaura la lògica de filtratge de col·lisions d'equip per a les banderes i la sincronització del Nametag local que s'havien perdut.

## Goals / Non-Goals

**Goals:**
- Implementar/Restaurar el filtre de col·lisions a `Bandera.cs`.
- Actualitzar el text del Nametag del jugador local a `GameManager.cs`.

**Non-Goals:**
- Modificar el sistema d'equips o de lobby.
- Canviar els prefabs de les banderes.

## Decisions

### 1. Filtre d'equip a Bandera.cs
S'utilitzarà `OnTriggerEnter2D` a `Bandera.cs` per interceptar el xoc amb el jugador.
- **Racional**: Permet centralitzar el filtratge a l'objecte bandera, que ja coneix el seu `equipPropietari`. Es consultarà l'equip del jugador a través de `MenuManager.Instance.currentRoomData` o directament de l'script del jugador. Atès que `Player.cs` té `idJugador` que es configura segons l'equip, s'usarà una via fiable.

### 2. Nametag via GetComponentInChildren
A `GameManager.cs`, s'utilitzarà `GetComponentInChildren<TMPro.TextMeshPro>()` (o la classe corresponent) per trobar el component de text del Nametag.
- **Racional**: És la forma més robusta de trobar el component de text dins d'un prefab instanciat dinàmicament.

## Risks / Trade-offs

- **[Risk]** Si el component de text del Nametag no està dins dels fills, el codi fallarà amb un `NullReferenceException`. -> **Mitigation**: S'afegirà una comprovació de nul·litat abans d'assignar el text.
- **[Trade-off]** Afegir la lògica de col·lisió a `Bandera.cs` podria duplicar-se amb la de `Player.cs`. S'ha d'assegurar que el `return;` impedeixi la crida al mètode `ComençarASeguir` si és de l'equip aliat.

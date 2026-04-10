## Context

El sistema de minijocs actual té un defecte on la UI es mostra prematurament i els jugadors poden quedar atrapats en un bucle infinit de combats per culpa de la proximitat dels seus colliders. Cal un mecanisme de neteja inicial i un cooldown de combat.

## Goals / Non-Goals

**Goals:**
- Netejar la UI en el `Start()` del Manager.
- Implementar un cooldown de 4 segons a `Player.cs` després de cada combat.
- Desvincular la gestió del moviment del Manager, delegant-la a un mètode de `Player`.

**Non-Goals:**
- Modificar els colliders físics dels jugadors.
- Canviar la durada del combat.

## Decisions

- **Inici Net (`Start`)**: Es cridarà `AmagarTotsElsContenidors()` en el `Start` perquè, encara que a l'editor la UI estigui activa per editar-la, el joc comenci amb tot amagat.
- **Cooldown amb Corrutina**: S'utilitzarà una corrutina `CombatCooldownCoroutine` a `Player.cs` per gestionar l'espera de 4 segons de forma no bloquejant.
- **Mètode FinalitzarCombat**: Aquest mètode centralitzarà la restauració de `potMoure = true` i el disparament del cooldown. Això simplifica el `MinijocUIManager` i fa que el jugador sigui responsable del seu propi estat.
- **Validació de potCombatre**: En `OnCollisionEnter2D`, s'afegirà la condició `opponent.potCombatre` a més de la pròpia per assegurar que cap dels dos jugadors estigui en cooldown.

## Risks / Trade-offs

- **[Risk] Cooldown massa llarg**: 4 segons poden semblar excessius en un joc ràpid. -> **[Mitigation]**: El valor es pot ajustar fàcilment si el feedback de joc ho requereix.
- **[Risk] Referències nul·les en HideUI**: Si el Manager intenta cridar `FinalitzarCombat` en jugadors que ja no existeixen. -> **[Mitigation]**: S'afegiran null-checks abans de la crida.

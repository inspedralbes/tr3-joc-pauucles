## 1. Millores de Gameplay a Player.cs

- [x] 1.1 Modificar `AplicarCastigDerrota()` per posar `Collider2D.isTrigger = true` al perdedor.
- [x] 1.2 Actualitzar la corrutina de càstig per restaurar `isTrigger = false` al finalitzar.
- [x] 1.3 Modificar `RobarBandera()` per forçar `transform.localPosition = Vector3.zero` en l'objecte de la bandera.

## 2. Feedback Visual a MinijocUIManager.cs

- [x] 2.1 Declarar i buscar la referència al Label `TextResultat` en l'arrel de la UI.
- [x] 2.2 Crear la corrutina `MostrarResultatIEsperar(Player guanyador, Player perdedor, string motiu)`.
- [x] 2.3 Refactoritzar `ProcessarResultatCombat()` perquè no tanqui la UI ni doni premis immediatament, sinó que iniciï la corrutina de feedback.
- [x] 2.4 Assegurar que `HideUI()` i el lliurament de premis ocorren després dels 2.5 segons d'espera.

## 3. Implementació Interactiva del Minijoc 3 (AturaBarra)

- [x] 3.1 Declarar referències per a `FonsBarra`, `Fletxa` i `BtnAturar` a `MinijocUIManager.cs`.
- [x] 3.2 Implementar lògica en l'Update per moure la `Fletxa` horitzontalment usant `Mathf.PingPong` entre 0 i 490px quan el minijoc 3 estigui actiu.
- [x] 3.3 Implementar el callback de `BtnAturar` que aturi el moviment i calculi la puntuació segons la proximitat a 250px.
- [x] 3.4 Integrar la resolució del combat d'AturaBarra amb el nou sistema de feedback visual.

## 4. Validació

- [x] 4.1 Verificar que el guanyador pot travessar el perdedor mentre aquest és un fantasma.
- [x] 4.2 Confirmar que la bandera s'enganxa perfectament al guanyador.
- [x] 4.3 Comprovar que el retard de 2.5 segons i el text de resultat funcionen en tots els minijocs.
- [x] 4.4 Validar la interactivitat i el càlcul de puntuació del minijoc AturaBarra.

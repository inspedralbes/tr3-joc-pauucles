## 1. Bloqueig i Gestió de UI

- [x] 1.1 Modificar `Awake()` a `MinijocUIManager.cs` per posar `rootVisualElement.style.display = DisplayStyle.None`.
- [x] 1.2 Actualitzar `ShowUI()` per activar el root visual element (`DisplayStyle.Flex`).
- [x] 1.3 Actualitzar `HideUI()` per tornar a bloquejar el root visual element (`DisplayStyle.None`).

## 2. Noves Mecàniques a Player.cs

- [x] 2.1 Implementar el mètode `public void AplicarCastigDerrota()`.
- [x] 2.2 Dins de `AplicarCastigDerrota()`, assegurar que el jugador queda immòbil i inicia el cooldown de combat.
- [x] 2.3 Implementar el mètode `public void RobarBandera(Player perdedor)`.
- [x] 2.4 Dins de `RobarBandera()`, gestionar el canvi de parent de la bandera i l'actualització de referències.

## 3. Integració de Regles de Combat

- [x] 3.1 Actualitzar la lògica de resolució de combat a `MinijocUIManager.cs`.
- [x] 3.2 Implementar la comprovació de possessió de bandera en acabar el minijoc.
- [x] 3.3 Cridar a `RobarBandera()` si el perdedor portava la bandera.
- [x] 3.4 Cridar a `FinalitzarCombat()` per al guanyador i `AplicarCastigDerrota()` per al perdedor.

## 4. Validació

- [x] 4.1 Verificar que la UI és totalment invisible en iniciar el joc.
- [x] 4.2 Confirmar que el perdedor queda immòbil després d'un combat.
- [x] 4.3 Validar que la bandera passa correctament del perdedor al guanyador.

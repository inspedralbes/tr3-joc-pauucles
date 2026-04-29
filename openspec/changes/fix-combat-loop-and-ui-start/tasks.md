## 1. Millores a MinijocUIManager.cs

- [x] 1.1 Implementar el mètode `Start()` i afegir la crida a `AmagarTotsElsContenidors()`.
- [x] 1.2 Actualitzar el mètode `HideUI()` per cridar a `_jugador1.FinalitzarCombat()` i `_jugador2.FinalitzarCombat()` en lloc de canviar `potMoure` manualment.
- [x] 1.3 Afegir null-checks per als jugadors en `HideUI()` abans de cridar als seus mètodes.

## 2. Millores a Player.cs

- [x] 2.1 Afegir la variable `public bool potCombatre = true;`.
- [x] 2.2 Implementar el mètode `public void FinalitzarCombat()`.
- [x] 2.3 Implementar la corrutina `CombatCooldownCoroutine(float seconds)` per gestionar el retorn de `potCombatre = true` després del temps d'espera.
- [x] 2.4 Modificar `OnCollisionEnter2D` per comprovar `potCombatre` tant del jugador local com de l'oponent abans d'iniciar el minijoc.

## 3. Validació

- [x] 3.1 Verificar que en iniciar el joc la UI no és visible.
- [x] 3.2 Comprovar que després d'un combat els jugadors es poden moure lliurement.
- [x] 3.3 Confirmar que cal esperar 4 segons abans de poder tornar a entrar en combat amb el mateix o un altre jugador.

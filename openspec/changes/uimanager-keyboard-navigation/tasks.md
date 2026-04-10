## 1. Preparació de Referències

- [x] 1.1 Declarar les llistes de botons `List<Button> _buttonsPPTLLS` i `List<Button> _buttonsParellsSenars` a `MinijocUIManager.cs`.
- [x] 1.2 Inicialitzar les lllistes de botons dins de `SetupPPTLLSButtons()` i `SetupParellsSenarsButtons()`.
- [x] 1.3 Declarar la variable `_currentButtonIndex` i reiniciar-la a 0 en cada crida a `ShowUI()`.

## 2. Lògica de Navegació i Focus

- [x] 2.1 Implementar el mètode `ActualitzarFocusVisual()` que canviï el color de fons del botó seleccionat.
- [x] 2.2 Implementar el mètode `GestionarNavegacioTeclat()` per detectar W/S i tecles de fletxa.
- [x] 2.3 Afegir la crida a `GestionarNavegacioTeclat()` dins del mètode `Update()`.

## 3. Confirmació i Interacció

- [x] 3.1 Afegir la detecció de les tecles Espai i Enter dins de `GestionarNavegacioTeclat()`.
- [x] 3.2 Implementar el mètode per simular el clic del botó actiu (`InvokeClick`) quan es confirma la selecció.

## 4. Validació

- [x] 4.1 Verificar que es pot navegar pel menú PPTLLS usant les fletxes del teclat.
- [x] 4.2 Confirmar que el color del botó canvia segons la selecció.
- [x] 4.3 Comprovar que prémer Enter/Espai sobre una opció resol el combat correctament.
- [x] 4.4 Validar que la navegació funciona igualment per al minijoc de Parells o Senars.

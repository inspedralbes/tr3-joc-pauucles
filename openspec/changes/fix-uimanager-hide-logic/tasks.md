## 1. Refactorització de HideUI

- [x] 1.1 Localitzar el mètode `HideUI()` a `MinijocUIManager.cs`.
- [x] 1.2 Eliminar les línies `_uiDocument.enabled = false;` o similars que desactiven el component o l'objecte.
- [x] 1.3 Assegurar que `HideUI()` només crida a `AmagarTotsElsContenidors()`.

## 2. Robustesa de la Visibilitat

- [x] 2.1 Verificar el mètode `AmagarTotsElsContenidors()`.
- [x] 2.2 Assegurar que s'inclou el fons o l'arrel de la UI si és necessari per evitar interferències visuals o d'inputs.
- [x] 2.3 Afegir comprovacions de seguretat perquè l'arrel es mantingui activa (`DisplayStyle.Flex` només quan calgui mostrar un joc).

## 3. Validació

- [x] 3.1 Comprovar que en acabar un minijoc, la UI desapareix però el component `UIDocument` a l'inspector de Unity segueix marcat com a actiu.
- [x] 3.2 Iniciar un segon combat i confirmar que només es veu el menú seleccionat per la ruleta, sense barreges.
- [x] 3.3 Verificar que les referències als contenidors es mantenen vàlides durant tota la sessió.

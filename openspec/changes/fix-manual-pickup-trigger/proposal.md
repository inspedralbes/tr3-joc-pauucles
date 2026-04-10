## Why

La recollida manual de la bandera a `Player.cs` necessita un ajust definitiu per ser robusta, especialment ara que l'objecte bandera utilitza un `Collider2D` en mode Trigger. Actualment, poden haver-hi inconsistències si no es gestionen correctament els esdeveniments de trigger i es necessita una comprovació de seguretat (null check) per evitar errors en temps d'execució.

## What Changes

- **Sincronització de Triggers**: S'implementaran `OnTriggerEnter2D` i `OnTriggerExit2D` amb la mateixa lògica de proximitat que els `OnCollision`, assegurant que la bandera es detecti encara que sigui un trigger.
- **Protecció de Recollida**: S'afegirà una validació `if (banderaPropera == null) return;` a la funció de recollida manual per evitar "null reference exceptions".
- **Gestió d'Estat de Bandera**: En recollir la bandera, s'aturarà el seu estat "fugitiu" (`fugint = false`) i es desactivarà el seu collider per evitar interaccions físiques mentre es transporta.
- **Jerarquia i Posicionament**: Es fixarà el `SetParent`, la `localPosition` a `(-0.8f, 0, 0)` i es resetajarà el flag de proximitat.

## Capabilities

### New Capabilities
- `manual-pickup-robustness`: Lògica millorada i segura per a la recollida manual d'objectes mitjançant triggers.

### Modified Capabilities
- `manual-flag-pickup`: S'actualitza el mètode de detecció per suportar triggers i s'afegeixen guardes de seguretat.

## Impact

- **Player.cs**: Modificació dels mètodes de col·lisió/trigger i de la funció de recollida manual.
- **Interacció**: Millora la fiabilitat de la recollida de la bandera per part dels jugadors.

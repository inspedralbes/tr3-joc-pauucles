## 1. Neteja de Codi Obsolet en Player.cs

- [x] 1.1 Eliminar les variables `aPropDeBandera` i `banderaPropera` del script `Player.cs`.
- [x] 1.2 Eliminar la lògica de detecció de tecles (E / RightControl) dins de la funció `Update`.
- [x] 1.3 Eliminar la funció completa `RecollirBanderaManualment`.

## 2. Implementació de la Recollida Automàtica

- [x] 2.1 Modificar `OnTriggerEnter2D` per agafar la bandera immediatament si el tag és "Bandera" (reparenting, localPosition a -0.8, disable collider, `scriptB.fugint = false`).
- [x] 2.2 Modificar `OnCollisionEnter2D` per fer el memo que al trigger però usant `collision.gameObject`.
- [x] 2.3 Eliminar els missatges de `Debug.Log` relacionats amb la proximitat o demanar prémer botons per recollir.

## 3. Neteja de Gestors de Sortida i Triggers

- [x] 3.1 Eliminar la lògica de "T'has allunyat de la bandera" a `OnTriggerExit2D`.
- [x] 3.2 Eliminar la lògica de "T'has allunyat de la bandera" a `OnCollisionExit2D`.

## 4. Verificació

- [x] 4.1 Verificar que la bandera es recull instantàniament al entrar en contacte amb el Trigger.
- [x] 4.2 Verificar que la bandera es recull instantàniament al col·lidir físicament (Collision).
- [x] 4.3 Verificar que no queden rastres de variables o missatges de recollida manual.

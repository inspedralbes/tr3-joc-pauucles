## 1. Ajust d'Escala i Combat en Player.cs

- [x] 1.1 Modificar `AgafarBandera` (o `AgafarBanderaAutomàticament`) per afegir `objBandera.transform.localScale = new Vector3(3f, 3f, 1f);` just després de `SetParent`.
- [x] 1.2 Verificar que a `OnCollisionEnter2D`, la crida a `MinijocUIManager.Instance.ShowUI` es realitzi directament al detectar el tag "Player", sense condicions de tecles.

## 2. Implementació de l'Efecte AFK

- [x] 2.1 Declarar la variable privada `float tempsInactiu = 0f;` a `Player.cs`.
- [x] 2.2 A l'`Update`, gestionar l'increment de `tempsInactiu` si l'input horitzontal és `0`.
- [x] 2.3 Implementar la lògica de parpelleig de l'alpha del `SpriteRenderer` si `tempsInactiu > 3f` usant `Mathf.PingPong`.
- [x] 2.4 Implementar le reset de `tempsInactiu` i de l'alpha si es detecta input horitzontal.

## 3. Verificació

- [x] 3.1 Comprovar visualment que la bandera no s'encongeix en ser recollida.
- [x] 3.2 Confirmar que le combat s'inicia a l'instant de la col·lisió.
- [x] 3.3 Verificar que le personatge parpelleja després de 3 segons d'estar quiet i que le parpelleig s'atura al moure's.

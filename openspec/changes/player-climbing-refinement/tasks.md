## 1. Refactorització de Variables

- [x] 1.1 Renomenar `tocantEscala` per `isNearLadder`.
- [x] 1.2 Renomenar `escalant` per `isClimbing`.
- [x] 1.3 Renomenar `originalGravity` per `defaultGravity`.

## 2. Implementació de la Lògica de Detecció (Triggers)

- [x] 2.1 Actualitzar `OnTriggerEnter2D` per marcar `isNearLadder = true` quan detecti el tag "ZonaEscalera".
- [x] 2.2 Actualitzar `OnTriggerExit2D` per marcar `isNearLadder = false` i `isClimbing = false` quan surti de "ZonaEscalera".

## 3. Gestió de l'Input i Física d'Escalada

- [x] 3.1 Capturar `verticalInput = Input.GetAxisRaw("Vertical")` a l'Update.
- [x] 3.2 Activar `isClimbing = true` si `isNearLadder` és true i hi ha input vertical.
- [x] 3.3 Ajustar `FixedUpdate` per posar `gravityScale = 0f` i aplicar velocitat vertical si `isClimbing` és true.
- [x] 3.4 Restaurar `gravityScale = defaultGravity` si no està escalant.

## 4. Integració amb l'Animator

- [x] 4.1 Actualitzar el paràmetre `isClimbing` de l'Animator a l'Update: `if (anim != null) anim.SetBool("isClimbing", isClimbing);`.

## 5. Verificació

- [x] 5.1 Comprovar que l'escalada funciona correctament i les animacions s'activen.
- [x] 5.2 Verificar que el salt no es veu afectat.

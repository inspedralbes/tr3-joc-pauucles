## 1. Declaració i Inicialització de l'Animator

- [x] 1.1 Afegir la variable privada `private Animator anim;` a la classe `Player`.
- [x] 1.2 Inicialitzar la variable `anim` en el mètode `Start()` mitjançant `anim = GetComponent<Animator>();`.

## 2. Actualització de Paràmetres d'Animació

- [x] 2.1 Afegir la lògica d'actualització de l'Animator al final del mètode `Update()`.
- [x] 2.2 Verificar que el check `if (anim != null)` estigui present abans d'actualitzar els paràmetres.
- [x] 2.3 Assignar el valor de `rb.linearVelocity.y` al paràmetre `yVelocity`.
- [x] 2.4 Calcular si el personatge s'està movent horitzontalment (`Mathf.Abs(rb.linearVelocity.x) > 0.1f`) i assignar-ho a `isRunning`.
- [x] 2.5 Assignar el valor de la variable `isGrounded` al paràmetre `isGrounded`.

## 3. Verificació i Neteja

- [x] 3.1 Comprovar que no hi hagi errors de compilació.
- [x] 3.2 Assegurar que la lògica AFK i de moviment existent segueixi funcionant correctament.

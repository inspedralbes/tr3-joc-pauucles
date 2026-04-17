## 1. Actualització de Variables a Bandera.cs

- [ ] 1.1 Afegir la variable pública `velocitatLevitacio = 3f;`.
- [ ] 1.2 Declarar una variable interna per controlar l'estat de levitació (ex: `bool estaLevitant`).

## 2. Lògica de Navegació Híbrida

- [ ] 2.1 Modificar el mètode `Update` a `Bandera.cs` per calcular la distància vertical (`Mathf.Abs(targetSeguiment.position.y - transform.position.y)`).
- [ ] 2.2 Implementar la condició de levitació: Si la diferència d'altura és > 2f O si un Raycast frontal detecta un mur bloquejant.
- [ ] 2.3 Implementar el mode Levitació:
  - Establir `rb.gravityScale = 0`.
  - Moure la mascota cap a la posició del jugador usant `Vector2.MoveTowards(transform.position, targetSeguiment.position, velocitatLevitacio * Time.deltaTime)`.
- [ ] 2.4 Implementar el retorn a Caminar:
  - Comprovar si el Dino està a prop del jugador (`Vector2.Distance < distanciaMinima`).
  - Comprovar si hi ha terra ferm a sota (`CheckGrounded()`).
  - Si es compleixen ambdues, restablir `rb.gravityScale = 1`.

## 3. Refinament de Salts i Animacions

- [ ] 3.1 Actualitzar la lògica de salts per saltar només davant d'obstacles petits (esglaons) detectats pel Raycast.
- [ ] 3.2 Assegurar que l'animació `isRunning` es manté activa durant la levitació si hi ha moviment horitzontal significatiu.

## 4. Verificació

- [ ] 4.1 Comprovar que la mascota levita cap al jugador quan aquest puja a una plataforma alta.
- [ ] 4.2 Verificar que la mascota torna a caminar normalment en arribar al terra a prop del jugador.

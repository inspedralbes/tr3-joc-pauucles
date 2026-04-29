## 1. Implementación de OnTriggerEnter2D

- [ ] 1.1 Añadir el método privado `OnTriggerEnter2D(Collider2D col)` en el script `CyborgIA.cs`.
- [ ] 1.2 Implementar la detección de dinosaurio en `OnTriggerEnter2D` usando `col.CompareTag("Dinosaurio")` y el flag `!tieneDino`.
- [ ] 1.3 Implementar la detección de la base en `OnTriggerEnter2D` usando `col.CompareTag("BaseRoja")` y el flag `tieneDino`.

## 2. Lógica de Posesión y Recompensas

- [ ] 2.1 Al detectar el dinosaurio en el Trigger: establecer `tieneDino = true`, sumar recompensa de 0.5f y emparentarlo centrado.
- [ ] 2.2 Al detectar la base en el Trigger: soltar al dinosaurio, sumar recompensa de 1f y llamar a `EndEpisode()`.

## 3. Verificación y Pruebas

- [ ] 3.1 Verificar que la lógica de `OnTriggerEnter2D` sea coherente con la de `OnCollisionEnter2D`.
- [ ] 3.2 Compilar el proyecto en Unity para asegurar que no hay errores de sintaxis en el nuevo método.

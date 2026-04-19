## 1. Preparación de Variables y Componentes

- [x] 1.1 Declarar variables privadas en `Bandera.cs`: `private Animator anim;` y `private Vector3 ultimaPosicio;`.
- [x] 1.2 Inicializar `anim = GetComponent<Animator>();` en el método `Start()`.
- [x] 1.3 Inicializar `ultimaPosicio = transform.position;` en el método `Start()`.

## 2. Implementación de Lógica Reactiva

- [x] 2.1 Identificar o crear el bloque de código en `Update()` para cuando la bandera es portada (`if (transform.parent != null)`).
- [x] 2.2 Calcular la variable bool `sestaMovent` comparando la distancia entre `transform.position` y `ultimaPosicio` (umbral > 0.001f).
- [x] 2.3 Actualizar el parámetro del animador: `if (anim != null) anim.SetBool("isWalking", sestaMovent);`.
- [x] 2.4 Guardar la posición actual para el siguiente frame al final del método `Update()`: `ultimaPosicio = transform.position;`.

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Validar que la bandera mueve las piernas al ser transportada por el jugador.
- [ ] 3.3 Validar que la animación se detiene cuando el jugador deja de moverse.

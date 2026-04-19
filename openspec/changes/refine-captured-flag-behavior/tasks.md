## 1. Preparación de Componentes y Variables

- [x] 1.1 Declarar `private SpriteRenderer mySprite;` en `Bandera.cs`.
- [x] 1.2 Inicializar `mySprite = GetComponent<SpriteRenderer>();` en el método `Start()`.
- [x] 1.3 Asegurar que `anim` y `ultimaPosicio` estén correctamente declaradas e inicializadas.

## 2. Implementación de Lógica de Mascota Reactiva

- [x] 2.1 En `Update()`, dentro del bloque `if (transform.parent != null)`, actualizar el umbral de movimiento a `0.002f` para calcular `sestaMovent`.
- [x] 2.2 Sincronizar el `flipX`: obtener `parentSprite` del padre e igualar `mySprite.flipX = parentSprite.flipX;`.
- [x] 2.3 Implementar el posicionamiento lateral: calcular `offsetX` usando el operador ternario sobre `mySprite.flipX` (0.5f si es true, -0.5f si es false).
- [x] 2.4 Aplicar la nueva posición: `transform.localPosition = new Vector3(offsetX, 0f, 0f);`.
- [x] 2.5 Asegurar que `ultimaPosicio = transform.position;` se ejecute al final del bloque de transporte.

## 3. Verificación y Pruebas

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Validar que la bandera cambia de lado (derecha/izquierda) al girar el jugador.
- [ ] 3.3 Validar que la bandera toca el suelo visualmente (`Y = 0`).
- [ ] 3.4 Confirmar que las animaciones de caminar se activan y desactivan correctamente según el movimiento.

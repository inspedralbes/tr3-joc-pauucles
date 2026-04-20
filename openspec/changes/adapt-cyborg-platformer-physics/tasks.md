## 1. Setup y Variables

- [x] 1.1 Añadir la variable pública `jumpForce = 7f` en `CyborgIA.cs`.
- [x] 1.2 Añadir la variable privada `anim` para el componente `Animator`.
- [x] 1.3 Capturar el componente `Animator` en el método `Initialize()`.

## 2. Movimiento Lateral y Salto

- [x] 2.1 Actualizar `OnActionReceived()` para leer las acciones: 1=Izquierda, 2=Derecha, 3=Saltar.
- [x] 2.2 Calcular el valor de `moveX` basado en la acción (1 o 2).
- [x] 2.3 Aplicar la velocidad horizontal preservando la vertical: `rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);`.
- [x] 2.4 Implementar la lógica de salto con `AddForce` y `ForceMode2D.Impulse` si se pulsa 3 y el agente está "tocando tierra" (velocidad Y cercana a cero).

## 3. Integración con Animator

- [x] 3.1 Actualizar el parámetro "Speed" del Animator con el valor absoluto de `moveX`.
- [x] 3.2 Activar el trigger "Jump" en el Animator cuando el agente realiza un salto exitoso.

## 4. Control Heurístico y Pruebas

- [x] 4.1 Actualizar `Heuristic()` para mapear fletxas Esquerra/Dreta (1 y 2) y Espai/Flecha Amunt (3).
- [x] 4.2 Verificar la integración en Unity y depurar el comportamiento de salto.

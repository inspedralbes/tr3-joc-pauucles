## 1. Preparación y Debugging

- [x] 1.1 Localizar el método `OnTriggerEnter2D` en `Bandera.cs`.
- [x] 1.2 Añadir log inicial de detección de colisión: `Debug.Log($"[Bandera] Xoc detectat amb: {collision.gameObject.name}, Tag: {collision.tag}");`.

## 2. Lógica de Captura

- [x] 2.1 Implementar filtro `if (collision.CompareTag("Player"))`.
- [x] 2.2 Obtener el componente `Player` y extraer el equipo de forma segura (mapeo `idJugador`).
- [x] 2.3 Añadir log de comparación: `Debug.Log($"[Bandera] Equip Jugador: {equipJugador} vs Equip Bandera: {equipPropietari}");`.
- [x] 2.4 Implementar la condición de captura: si los equipos son diferentes (y no nulos/vacíos).
- [x] 2.5 Ejecutar el enganche: `transform.SetParent(collision.transform);` y `transform.localPosition = new Vector3(-0.5f, 0.5f, 0f);`.
- [x] 2.6 Añadir log final: `Debug.Log("[Bandera] CAPTURADA!");`.

## 3. Verificación y Limpieza

- [x] 3.1 Confirmar que el método `DeixarDeSeguir()` permanece intacto.
- [x] 3.2 Eliminar o comentar lógica antigua redundante dentro de `OnTriggerEnter2D` (como la desactivación de física que será manejada en el enganche).
- [x] 3.3 Verificar que el script compila sin errores.
- [ ] 3.4 Validar el comportamiento en juego: la bandera debe engancharse solo a enemigos.

## 1. Modificaciones en Player.cs

- [x] 1.1 Localizar el método `OnTriggerEnter2D` y la sección que gestiona la entrada en la base propia con bandera.
- [x] 1.2 Reemplazar la llamada a `MinijocUIManager.Instance.ShowUI(this, this)` por `GameManager.Instance.FinalitzarPartida(true)`.
- [x] 1.3 Eliminar el bloqueo individual `potMoure = false` (el GameManager se encargará de ello globalmente).

## 2. Implementación en GameManager.cs

- [x] 2.1 Crear el método `public void FinalitzarPartida(bool victoria)`.
- [x] 2.2 Dentro de `FinalitzarPartida`, buscar todos los componentes `Player` en la escena y establecer `potMoure = false`.
- [x] 2.3 Implementar lógica para buscar y activar `PantallaVictoria` o `PantallaDerrota` según el parámetro `victoria`.
- [x] 2.4 Añadir comentario TODO sobre el envío del evento `GAME_OVER` por WebSockets.

## 3. Verificación

- [ ] 3.1 Verificar en Unity que al entregar la bandera enemiga en la base propia, se activa la pantalla de victoria.
- [ ] 3.2 Confirmar que los jugadores ya no pueden moverse tras el fin de la partida.

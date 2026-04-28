## Context

El sistema multijugador actual experimenta desincronizaciones visuales y lógicas durante la fase de combate. La falta de una autoridad clara sobre quién recibe el daño (stun/vides) y la capacidad de los temporizadores de reiniciarse ante la latencia de red degradan la jugabilidad. Además, los drones IA consumen recursos y generan ruido visual al intentar moverse cuando no tienen un objetivo legítimo.

## Goals / Non-Goals

**Goals:**
- Garantizar que solo un jugador sufra los efectos de la derrota por combate.
- Evitar bucles de procesamiento de fin de combate.
- Estabilizar el flujo temporal de los minijuegos.
- Anclar a los drones en reposo total cuando el dinosaurio está a salvo.

**Non-Goals:**
- Rediseñar el sistema de comunicación Socket.io.
- Cambiar la lógica de IA del dron fuera del estado de reposo.

## Decisions

- **Bandera de Conclusión en UI Manager**: Se añadirá un booleano `isConcluding` en `MinijocUIManager.cs`. Al entrar en `FinalitzarCombat`, si es `true`, se aborta. Si es `false`, se establece a `true` inmediatamente.
- **Filtro Estricto de Identidad**: En `FinalitzarCombat`, se comparará el nombre de usuario local con el nombre del perdedor resuelto. Solo si coinciden se activará `ProcesarDerrota()`. El ganador simplemente desbloqueará su movimiento.
- **Supresión de Reinicios de Temporizador**: Se revisarán los métodos `RebreActualitzacioXarxa` en los scripts de lógica de minijuegos para eliminar cualquier asignación que sobrescriba `_tempsRestant` con valores recibidos, dejando que el tiempo local fluya de forma independiente o sea dictado por el Host mediante mensajes de fin explícitos.
- **Drones Piedra en DroneAI**: En el `Update()` del dron, se añadirá una comprobación: `if (currentState == DroneState.A_Salvo)`. Si se cumple, se forzará `rb.linearVelocity = Vector2.zero` y se desactivará el `DecisionRequester`.
- **Limpieza de Cooldowns**: Se llamará a una función estática de limpieza en `Player.cs` que reinicie `ultimXoc` y limpie estados de stun residuales al cerrar la interfaz del minijuego.

## Risks / Trade-offs

- [Risk] → El dron puede tardar en reaccionar si el cambio de estado de `A_Salvo` a `Robado` tiene lag.
- [Mitigación] → La comprobación de estado en el dron seguirá siendo reactiva a los cambios de la bandera.
- [Risk] → Si la red falla críticamente, un jugador podría quedarse bloqueado si `isConcluding` falla.
- [Mitigación] → Implementar un timeout de seguridad que limpie la bandera `isConcluding` tras 5 segundos.

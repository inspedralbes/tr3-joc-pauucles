## 1. Refactorización del Sistema de Tiempo

- [x] 1.1 Eliminar las llamadas de reinicio del temporizador en todos los minijuegos.
- [x] 1.2 Asegurar que el Host inicie el temporizador global al activar el minijuego.
- [x] 1.3 Implementar la resolución por "Tiempo Agotado" como fallback en el Host.

## 2. Implementación de Resolución Instantánea

- [x] 2.1 Modificar la lógica de "Error" del jugador para enviar el resultado inmediatamente al Host.
- [x] 2.2 Modificar la lógica de "Objetivo Alcanzado" para enviar el éxito inmediatamente.
- [x] 2.3 Implementar la prioridad por orden de llegada en el Host (autoridad del primer mensaje).

## 3. Segmentación de Castigos (Stun)

- [x] 3.1 Actualizar el mensaje de red de resultado para incluir los IDs de ganador y perdedor.
- [x] 3.2 Refactorizar el manejador de stuns para validar el ID antes de aplicar el efecto.

## 4. Limpieza de Interfaz (UI)

- [x] 4.1 Implementar el cierre inmediato de la UI del minijuego en cuanto se reciba el mensaje de resultado.
- [x] 4.2 Añadir una transición rápida (0.2s - 0.5s) antes de ocultar la UI para evitar parpadeos visuales bruscos.

## 5. Validación

- [x] 5.1 Probar la resolución por error en ambos clientes.
- [x] 5.2 Probar la resolución por objetivo alcanzado.
- [x] 5.3 Verificar que el ganador nunca reciba el stun.

## Context

El proyecto es un juego multijugador desarrollado en Unity. Actualmente, los jugadores pueden colisionar en el mapa, lo que debería desencadenar un enfrentamiento rápido mediante el minijuego PPTLLS. Se requiere una interfaz visual para que los jugadores interactúen, sin detener el tiempo global del motor de juego para no afectar a otros participantes.

## Goals / Non-Goals

**Goals:**
- Implementar `MinijocUIManager.cs` para gestionar el flujo de la UI del minijuego.
- Inmovilizar localmente a los jugadores implicados mediante la propiedad `potMoure`.
- Vincular dinámicamente los botones de la UI ("BtnPedra", "BtnPaper", "BtnTisora", "BtnLlangardaix", "BtnSpock") con la lógica de `MinijocPPTLLS.cs`.
- Cerrar la UI y restaurar el movimiento tras la resolución del combate.

**Non-Goals:**
- Implementar animaciones complejas en la interfaz (se prioriza funcionalidad).
- Modificar el sistema de red o de detección de colisiones existente.
- Añadir sonidos o efectos visuales adicionales fuera de la interfaz base.

## Decisions

- **Uso de UI Toolkit (`UIDocument`)**: Se elige UI Toolkit sobre UGUI por su mejor manejo de layouts flexibles y su integración moderna con Unity.
- **Identificación de Botones por Nombre**: Se utilizará `Query<Button>("BtnNombre")` para obtener las referencias de los 5 botones, lo que facilita la vinculación si el asset `.uxml` cambia de estructura pero mantiene los nombres.
- **Control de Movimiento Desacoplado**: En lugar de pausar el juego (`Time.timeScale = 0`), se manipulará la variable `potMoure` de los scripts de `Player`. Esto permite que el resto del mundo siga funcionando normalmente.
- **Fondo Semitransparente**: Se utilizará un panel de fondo con color negro y opacidad reducida para centrar la atención del jugador en el minijuego sin perder de vista el entorno.

## Risks / Trade-offs

- **[Riesgo] Estado `potMoure` bloqueado**: Si el minijuego falla o se cierra inesperadamente, el jugador podría quedarse inmovilizado para siempre. → **[Mitigación]**: Implementar bloques `try-finally` o asegurar que la restauración de `potMoure = true` sea parte de la lógica de salida crítica de la UI.
- **[Riesgo] Colisión múltiple**: ¿Qué pasa si un tercer jugador choca con uno en combate? → **[Mitigación]**: El diseño actual asume un flujo 1v1 iniciado por la colisión original. Se asume que el sistema de colisiones ignora a jugadores con `potMoure = false` o que el estado de combate impide nuevas interacciones.

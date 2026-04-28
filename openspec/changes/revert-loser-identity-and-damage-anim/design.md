## Context

Se ha identificado que la lógica de resolución forzada de perdedores y la adición de animaciones de daño en el último paso han introducido inconsistencias o no han resuelto el problema de base de la forma esperada. El sistema anteriormente tenía una apertura de ventanas sincronizada que funcionaba correctamente.

## Goals / Non-Goals

**Goals:**
- Restaurar el código de `Player.cs` y los minijuegos al estado anterior a la última sesión.
- Eliminar la dependencia de la variable `loser` y el manejo de "Empat" en los mensajes de red.
- Eliminar el trigger "Hurt" del flujo de daño.

**Non-Goals:**
- Corregir el problema del stun en esta fase (se abordará en el futuro con un enfoque diferente).
- Modificar el inicio de los minijuegos (se mantiene la lógica de autoridad del Host).

## Decisions

- **Eliminación Quirúrgica**: Se localizarán y eliminarán las líneas específicas añadidas en la última sesión para evitar una reversión total de archivos que pueda afectar a otros cambios estables.
- **Simplificación de Mensajes**: Los mensajes `MINIJOC_RESULT` volverán a usar el formato donde el perdedor es opcional o se deriva de la lógica de UI básica.

## Risks / Trade-offs

- [Risk] → Reintroducir el problema donde el ganador recibe un stun por error.
- [Mitigación] → Este riesgo es aceptado temporalmente para recuperar la estabilidad del flujo principal de red.

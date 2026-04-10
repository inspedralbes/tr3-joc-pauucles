## Context

La variable `banderaAgafada` de `Player.cs` es actualmente privada, lo que impide que el `MinijocUIManager` la consulte para identificar al defensor. Esto causa un error de compilación CS0122.

## Goals / Non-Goals

**Goals:**
- Hacer pública la variable `banderaAgafada`.
- Permitir que `MinijocUIManager` identifique al jugador defensor correctamente.

**Non-Goals:**
- Cambiar la lógica de recolección de banderas.

## Decisions

- **Modificador Público**: Se cambia `private` a `public` directamente en la declaración de la variable en `Player.cs`. Es la solución más directa y compatible con el estilo actual del código del proyecto.

## Risks / Trade-offs

- **[Risk]** Acceso externo accidental. → **Mitigación**: El uso esperado es solo de lectura por parte de la UI.

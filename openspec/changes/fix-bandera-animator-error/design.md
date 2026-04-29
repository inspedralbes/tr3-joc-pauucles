## Context

En Unity, si un componente `Animator` intenta ejecutar métodos como `SetBool` o `Play` sin tener un `AnimatorController` asignado en el campo `Runtime Animator Controller`, se genera un error de consola recurrente: "Animator is not playing an AnimatorController". El script `Bandera.cs` actualmente solo comprueba que la referencia `anim` no sea nula, lo cual es insuficiente.

## Goals / Non-Goals

**Goals:**
- Eliminar el error de consola recurrente mediante programación defensiva.
- Asegurar que la lógica de animación sea robusta frente a configuraciones incompletas del Inspector.

**Non-Goals:**
- No se creará ni asignará automáticamente un AnimatorController si falta.
- No se modificará el AnimatorController existente.

## Decisions

- **Validación Combinada**: Se utilizará la expresión `if (anim != null && anim.runtimeAnimatorController != null)` en el método `Update` antes de cada llamada a `SetBool`.
- **Enfoque de "Silencio si Falla"**: Si falta el controlador, la bandera simplemente no se animará, pero el juego continuará ejecutándose sin errores de consola, lo cual es preferible en un entorno de desarrollo con múltiples prefabs.

## Risks / Trade-offs

- **[Riesgo] Falta de feedback visual** → **[Mitigación]** El desarrollador notará que la bandera no se mueve, lo cual es un indicador suficiente de que falta el controlador, sin necesidad de inundar la consola con errores.
- **[Riesgo] Rendimiento por comprobación en Update** → **[Mitigación]** El acceso a `runtimeAnimatorController` es una operación de bajo coste comparado con el coste de procesar y registrar una excepción/error en la consola de Unity.

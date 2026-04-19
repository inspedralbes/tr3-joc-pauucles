## Context

El script `MenuManager.cs` maneja la interfaz de usuario y las peticiones de red para la autenticación de usuarios. Actualmente, la captura de datos de los campos de texto (`TextField`) se realiza sin validación previa, lo que expone al sistema a errores por entradas de usuario imprevistas.

## Goals / Non-Goals

**Goals:**
- Asegurar que los datos enviados al servidor estén limpios y validados.
- Proporcionar visibilidad total sobre los datos salientes mediante logs.
- Mantener la compatibilidad con el esquema JSON actual del servidor.

**Non-Goals:**
- No se modificará el backend.
- No se implementará validación de complejidad de contraseña en esta fase.

## Decisions

- **Uso de String.Trim()**: Se aplicará a todas las lecturas de credenciales para eliminar ruido en los datos.
- **Validación Preventiva**: Se utilizará `string.IsNullOrEmpty()` tras el trimado para abortar la operación si faltan datos esenciales, evitando peticiones innecesarias.
- **Logging con Debug.LogWarning**: Se utiliza el nivel de advertencia para asegurar que el log sea visible incluso con filtros de log básicos activos, facilitando la depuración rápida.
- **Refactorización Quirúrgica**: Se modificarán los métodos `RegistrarUsuari` y `FerLogin` para centralizar la validación antes de la serialización JSON.

## Risks / Trade-offs

- **[Riesgo] Pérdida de espacios intencionales** → **[Mitigación]** En nombres de usuario y contraseñas, los espacios al inicio y al final suelen ser errores de entrada; el trimado es una práctica estándar de seguridad y limpieza.
- **[Riesgo] Exposición de contraseñas en logs** → **[Mitigación]** Estos logs están limitados al entorno de desarrollo (Unity Console) y son fundamentales para depurar el flujo de datos. En una versión final de producción, estos logs deberían eliminarse o anonimizarse.

## Why

Actualmente, las funciones de Login y Registro en `MenuManager.cs` leen directamente los valores de los campos de texto sin validación ni limpieza. Esto puede provocar errores de autenticación por espacios en blanco accidentales o payloads mal formados. Además, la falta de visibilidad sobre el JSON enviado dificulta la depuración de problemas de comunicación con el backend. Este cambio introduce robustez y transparencia en el proceso de autenticación.

## What Changes

- Aplicación de `.Trim()` a los valores de `username` y `password` leídos de la UI.
- Implementación de comprobaciones de nulidad y cadenas vacías antes de intentar la petición.
- Verificación del objeto `AuthData` para asegurar que las claves JSON coincidan con las esperadas por el servidor.
- Adición de un log de advertencia obligatorio (`Debug.LogWarning`) que imprima el JSON exacto antes de ser enviado.

## Capabilities

### New Capabilities
- `robust-auth-data-handling`: Validación, limpieza y depuración de datos de autenticación antes de la transmisión HTTP.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `MenuManager.cs`.
- Flujo de autenticación (Login y Registro).
- Logs de consola para depuración de red.

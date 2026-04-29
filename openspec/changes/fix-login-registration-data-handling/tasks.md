## 1. Validación y Limpieza

- [x] 1.1 Localizar el método `RegistrarUsuari` en `MenuManager.cs`.
- [x] 1.2 Aplicar `.Trim()` a los parámetros `usuari` y `password` al inicio del método.
- [x] 1.3 Añadir comprobación `if (string.IsNullOrEmpty(usuari) || string.IsNullOrEmpty(password))` para abortar si están vacíos.
- [x] 1.4 Repetir los pasos 1.1 a 1.3 para el método `FerLogin`.

## 2. Logging de Payload

- [x] 2.1 En `RegistrarUsuari`, añadir `Debug.LogWarning($"[MenuManager] Intentant enviar al servidor (Registre): {json}");` antes de llamar a `EnviarPeticio`.
- [x] 2.2 En `FerLogin`, añadir `Debug.LogWarning($"[MenuManager] Intentant enviar al servidor (Login): {json}");` antes de llamar a `EnviarPeticio`.

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [ ] 3.2 Probar un registro con espacios en blanco y confirmar que el log muestra los datos limpios.
- [ ] 3.3 Probar un login fallido por campos vacíos y confirmar que no se realiza la petición de red.

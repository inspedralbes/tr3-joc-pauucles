## 1. Modificación de Player.cs (Auto-inicio Host)

- [x] 1.1 Localizar el método `OnCollisionEnter2D` en `Player.cs`.
- [x] 1.2 Añadir una llamada a `MinijocUIManager.Instance.IniciarMinijoc` para que el Host la ejecute inmediatamente después de enviar el mensaje de red.

## 2. Ajustes en MenuManager.cs (Prevención de Duplicados)

- [x] 2.1 Localizar el listener de mensajes en `MenuManager.cs` que procesa el tipo `MINIJOC_START`.
- [x] 2.2 Envolver la lógica de apertura de UI en una comprobación que valide si `MinijocUIManager.Instance.minijocActiu` es falso.

## 3. Validación

- [x] 3.1 Verificar en una sesión con dos clientes que el Host abre la interfaz de inmediato al chocar.
- [x] 3.2 Comprobar que el Host no intenta abrir una segunda ventana si recibe su propio mensaje de vuelta.

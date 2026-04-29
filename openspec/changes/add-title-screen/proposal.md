## Why

L'experiència d'usuari actual és massa directa, portant el jugador a la pantalla de login immediatament en obrir el joc. Una pantalla de títol inicial proporciona una benvinguda més professional, permet mostrar el logotip del joc i crea una transició suau abans de demanar les credencials d'accés.

## What Changes

- **Nova Pantalla de Títol**: Addició d'un element visual `pantallaTitol` al `MenuManager`.
- **Botó d'Inici**: Implementació del botó `btnStartGame` que actua com a disparador per passar al login.
- **Flux de Navegació**: Modificació de la lògica de visibilitat inicial per prioritzar la pantalla de títol sobre la de login si no hi ha una sessió activa.
- **Vincle amb la UI**: Recerca i subscripció d'esdeveniments per als nous elements d'UI Toolkit.

## Capabilities

### New Capabilities
- `title-screen-navigation`: Capacitat de gestionar l'estat inicial del joc mitjançant una pantalla de benvinguda.

### Modified Capabilities
- `foundations`: Actualització del flux d'arrencada de la interfície d'usuari.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Inclusió de nous camps i lògica de subscripció.
- Fitxer UXML del menú: Caldrà assegurar-se que existeix un element anomenat "PantallaTitol" i un botó "btnStartGame".

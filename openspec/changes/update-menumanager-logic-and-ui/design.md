## Context

El sistema actual de `MenuManager` no persisteix la identitat de l'usuari i la interfície té botons amb IDs i textos incongruents (específicament al pop-up de creació de sala).

## Goals / Non-Goals

**Goals:**
- Persistir el `userId` obtingut de l'API de login.
- Corregir el flux de navegació (tornar enrere, tancar).
- Normalitzar els IDs de botons al pop-up de creació de sala.

**Non-Goals:**
- Implementar la lògica de "Logout" al servidor (només canvi de pantalla al client).
- Redissenyar visualment les finestres.

## Decisions

- **Estructura de Dades**: S'afegirà una classe `LoginResponse` per parsejar el JSON de resposta del login, que inclou el camp `id`.
- **Modificació de `CreateGameData`**: S'afegirà el camp `public string host` per complir amb els requeriments del backend.
- **Normalització de IDs a UXML**:
  - `btnConfirmarSala` (text "Cancelar") -> `btnCancelarSala`
  - `btnTancarPopUp` (text "Crear") -> `btnConfirmarSala`
  - Això farà que el codi sigui molt més llegible i coherent amb el que l'usuari veu a pantalla.
- **Vinculació d'Esdeveniments**: S'utilitzaran expressions lambda al `OnEnable` per a les accions simples de navegació (`DisplayStyle.None`, `DisplayStyle.Flex`).

## Risks / Trade-offs

- **[Risc] Canvi de IDs a UXML**: Si es canvien els IDs al fitxer `.uxml`, cal assegurar-se que el mètode `root.Q<Button>("nom")` al C# també s'actualitzi.
  - **Mitigació**: Es faran ambdós canvis en la mateixa sessió de tasques.
- **[Risc] Format del JSON**: El backend podria retornar `_id` en comptes de `id`.
  - **Mitigació**: Es verificarà el model del backend. (Revisant `backend/src/models/User.js` si cal, però el controlador sol retornar el que el client espera).

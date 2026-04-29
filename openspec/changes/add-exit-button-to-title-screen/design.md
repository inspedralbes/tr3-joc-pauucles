## Context

El projecte ha afegit recentment una Pantalla de Títol inicial a `MenuManager.cs`. Actualment, aquesta pantalla només permet iniciar el joc cap al login. Per millorar l'experiència d'usuari, es requereix un botó de sortida funcional que tanqui l'aplicació en builds natives.

## Goals / Non-Goals

**Goals:**
- Implementar la lògica de tancament per al botó `btnExitGame`.
- Assegurar que el botó es vincula correctament amb la UI Toolkit.
- Proporcionar feedback visual a la consola en prémer el botó.

**Non-Goals:**
- Afegir animacions de tancament complexes.
- Modificar el disseny visual de l'UXML (es pressuposa que el botó ja existeix o s'afegirà manualment).

## Decisions

### 1. Ús d' `Application.Quit()`
- **Decisió**: Utilitzar la funció estàndard d'Unity per tancar l'aplicació.
- **Racional**: És la forma més compatible i segura de finalitzar el procés en plataformes com Windows, macOS, Linux i Android. Nota: en WebGL aquesta funció no fa res, però es manté per a builds natives.

### 2. Vinculació a `VincularEsdevenimentsUI`
- **Decisió**: Afegir la recerca de `btnExitGame` i la subscripció al clic dins d'aquest mètode existent.
- **Racional**: Manté la consistència amb com es gestionen els altres botons (login, registre, creació de sala) al `MenuManager`.

## Risks / Trade-offs

- **[Risc] Botó no trobat** → **Mitigació**: Utilitzar un null-check (`if (btnExitGame != null)`) abans de subscriure's a l'esdeveniment de clic per evitar errors de referència nula si el botó s'elimina o canvia de nom a l'UXML.
- **[Risc] WebGL Compatibility** → **Mitigació**: Afegir un log (`Debug.Log`) perquè en WebGL, on `Quit` no funciona, el desenvolupador pugui veure que l'acció s'ha disparat correctament.

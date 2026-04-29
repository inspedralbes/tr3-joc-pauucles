## Context

L'estructura actual de la interfície d'usuari a `MenuPrincipal` es divideix en diversos `VisualElement` que representen pantalles (Login, Lobby, SalaEspera, etc.). El canvi proposat afegeix una capa superior de presentació que ha de ser la primera a aparèixer en obrir l'escena.

## Goals / Non-Goals

**Goals:**
- Implementar una pantalla de títol reactiva.
- Centralitzar el canvi d'estat visual en mètodes existents del `MenuManager`.
- Mantenir la compatibilitat amb el sistema de sessió persistent actual.

**Non-Goals:**
- Canviar el disseny visual (UXML/USS) directament; ens centrem en la lògica de codi.
- Implementar animacions complexes en aquesta fase.

## Decisions

### 1. Element Visual Principal
- **Decisió**: Afegir `private VisualElement pantallaTitol` i `private Button btnStartGame`.
- **Racional**: Segueix el patró ja establert per a les altres pantalles del sistema.

### 2. Flux d'Interacció
- **Decisió**: El botó d'inici simplement alterna la visibilitat cap a la pantalla de login.
- **Racional**: És la implementació més neta i amb menys risc de trencar la lògica d'autenticació existent.

### 3. Integració amb `ActualitzarVisibilitatSegonsSessio`
- **Decisió**: Modificar aquest mètode per incloure la `pantallaTitol` en la lògica de "reset" i selecció inicial.
- **Racional**: Aquest mètode és el punt central de control de la visibilitat de la UI al `MenuManager`.

## Risks / Trade-offs

- **[Risc] Elements no trobats a l'UXML** → **Mitigació**: Utilitzar `Debug.LogWarning` i comprovacions de nul·litat per evitar errors en temps d'execució si el dissenyador encara no ha actualitzat el fitxer `.uxml`.
- **[Risc] Superposició de pantalles** → **Mitigació**: Assegurar que en el mètode de reset inicial, totes les pantalles s'amaguen (`DisplayStyle.None`) abans de mostrar la que toca.

## Context

El projecte ha evolucionat cap a un sistema de skins on la identitat del personatge és independent del seu equip. Actualment, el `GameManager.cs` manté variables heretades que causen confusió.

## Goals / Non-Goals

**Goals:**
- Netejar el codi de `GameManager.cs`.
- Implementar la llista completa de skins com a variables públiques.
- Sincronitzar el mètode `GetPrefabPerSkin` amb les noves variables.

**Non-Goals:**
- Modificar el sistema de banderes.
- Canviar el sistema de persistència al backend.

## Decisions

### 1. Variables individuals vs Diccionari
S'utilitzaran variables públiques individuals per a cada skin (`prefabBiker`, `prefabCyborg`, etc.).
- **Racional:** Facilita l'assignació directa des de l'inspector d'Unity sense haver de configurar estructures de dades complexes (com diccionaris o llistes de parelles) per a un nombre petit i fix de skins.

### 2. Nomenclatura de variables
Les variables seguiran el format `prefab[NomSkin]`.
- **Racional:** Manté la consistència amb l'estil de codi existent i és auto-explicatiu.

## Risks / Trade-offs

- **[Risk]** En eliminar les variables antigues, s'haurà de reconfigurar l'objecte `GameManager` a l'editor d'Unity per assignar els nous prefabs. -> **Mitigation:** S'avisarà d'aquest requeriment manual en el moment de la implementació.
- **[Trade-off]** El codi és menys flexible si s'afegeixen 100 skins més. -> **Mitigation:** Per als requeriments del TR3 (6 skins), és la solució més neta i eficient.

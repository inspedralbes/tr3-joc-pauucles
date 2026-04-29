## Context

El projecte presenta dos problemes menors d'integració a Unity: les banderes són "cegues" a l'equip que intenta capturar-les, i el Nametag local no està vinculat a la identitat de l'usuari.

## Goals / Non-Goals

**Goals:**
- Implementar un filtre de col·lisió basat en l'equip a `Bandera.cs`.
- Assegurar l'assignació del nom d'usuari al component visual `TMPro` del jugador local.

**Non-Goals:**
- Canviar el sistema de col·lisions d'Unity.
- Modificar el sistema de prefabs.

## Decisions

### 1. Filtre d'equip a Bandera.cs
S'obtindrà l'equip del jugador col·lisionant mitjançant una cerca de component o accés a `MenuManager`.
- **Racional**: L'script `Bandera` ja té `equipPropietari`. Comparar-lo directament és la forma més eficient de decidir si s'ha de processar la col·lisió.

### 2. Nametag via GetComponentInChildren
S'utilitzarà el mètode genèric `GetComponentInChildren<TMPro.TextMeshPro>()` (o la variant UGUI).
- **Racional**: Permet trobar el component de text independentment de l'estructura jeràrquica interna del prefab del jugador.

## Risks / Trade-offs

- **[Risk]** Si el component `TMPro` no s'importa correctament o s'utilitza una versió incompatible, l'assignació fallarà. -> **Mitigation**: S'afegirà una comprovació de nul·litat i un log d'avís.

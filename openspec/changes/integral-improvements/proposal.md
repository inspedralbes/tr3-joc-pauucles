## Why

Aquest canvi té com a objectiu millorar significativament l'experiència de joc (Quality of Life) i el feedback visual per als jugadors. Actualment, els jugadors derrotats bloquegen físicament el pas i el robatori de bandera pot ser visualment incoherent. A més, la UI es tanca massa ràpid sense donar temps al jugador a pair el resultat, i el tercer minijoc (AturaBarra) necessita una implementació funcional completa.

## What Changes

- **Quality of Life (Player.cs)**:
    - Implementació de l'estat "Fantasma": El collider del jugador passa a `isTrigger = true` durant el càstig de derrota.
    - Implementació de l'estat "Imant": La bandera robada s'assigna al guanyador i es posiciona exactament a `Vector3.zero`.
- **Feedback Visual (MinijocUIManager.cs)**:
    - Ús del Label `TextResultat` per mostrar informació detallada sobre el guanyador i el motiu.
    - Introducció d'un retard de 2.5 segons mitjançant una corrutina abans de tancar la UI i aplicar les conseqüències del combat.
- **Minijoc 3: AturaBarra (MinijocUIManager.cs)**:
    - Implementació del moviment continu de la fletxa usant `Mathf.PingPong`.
    - Lògica de càlcul de puntuació basada en la proximitat al centre (250px).
    - Generació de puntuació pel rival i resolució del combat amb feedback visual.

## Capabilities

### New Capabilities
- `ghost-effect`: Estat de trigger temporal per a jugadors derrotats.
- `ui-delayed-feedback`: Mostra de resultats de combat amb retard abans del tancament.
- `minijoc-atura-barra-logic`: Moviment de fletxa i càlcul de proximitat per al minijoc 3.

### Modified Capabilities
- `flag-theft`: Millora en la magnetització de la bandera robada.
- `defeat-penalty`: Integració de l'estat fantasma en el càstig.

## Impact

- **Player.cs**: Modificació de `AplicarCastigDerrota` i `RobarBandera`.
- **MinijocUIManager.cs**: Nous membres per a la fletxa i la barra, actualització de l'Update per al moviment, i nova corrutina de resolució amb feedback.
- **Game Flow**: Millora en la claredat dels resultats i en la fluïdesa del moviment post-combat.

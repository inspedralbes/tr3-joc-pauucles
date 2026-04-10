## Context

L'objecte bandera ha passat de ser un objecte físic a ser un trigger per facilitar el moviment i la detecció. Això requereix que `Player.cs` s'adapti per detectar la proximitat mitjançant esdeveniments de trigger (`OnTriggerEnter2D`/`Exit2D`) a més dels de col·lisió. A més, la funció de recollida manual ha de ser prou robusta per no fallar si les referències s'han perdut.

## Goals / Non-Goals

**Goals:**
- Garantir que la bandera es detecti tant si és un collider físic com un trigger.
- Implementar una guarda de seguretat en la recollida manual.
- Normalitzar el procés de recollida (aturar fugida, desactivar collider, re-posicionar).

**Non-Goals:**
- Canviar el sistema d'input ja implementat.
- Modificar el comportament de la bandera quan no s'està recollint.

## Decisions

- **Sincronització Enter/Exit**: S'implementaran els mètodes `OnTriggerEnter2D` i `OnTriggerExit2D` duplicant la lògica de detecció per tag "Bandera". Això dóna flexibilitat total davant canvis en el prefab de la bandera.
- **Guardia de Nullitat**: S'utilitzarà `if (banderaPropera == null) return;` com a primera línia de la funció de recollida. És una mesura defensiva essencial en sistemes asíncrons basats en esdeveniments de Unity.
- **Desactivació de Collider del Fill**: Un cop la bandera és filla, el seu collider s'ha de desactivar per evitar que generi nous esdeveniments de trigger amb el mateix jugador o amb rivals (evitant robatoris accidentals).
- **Control d'Estat Extern**: S'accedirà al component `Bandera` per posar `fugint = false`, assegurant que el moviment de retorn s'aturi immediatament.

## Risks / Trade-offs

- **[Risk] Rendiment de GetComponent**: Cridar `GetComponent` en el moment de la recollida.
    - **Mitigation**: La recollida és un esdeveniment puntual desencadenat per l'usuari, l'impacte en el rendiment és negligible.
- **[Risk] Ordre d'execució**: Que el collider s'activi/desactivi en moments inesperats.
    - **Mitigation**: El disseny segueix un flux atòmic dins de la funció de recollida.

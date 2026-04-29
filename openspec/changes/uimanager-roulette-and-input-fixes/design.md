## Context

El projecte es troba en una fase on cal consolidar els minijocs ja implementats (PPTLLS, Parells/Senars i AturaBarra). S'han detectat problemes on la ruleta tria IDs de minijocs buits, i es vol millorar la interacció amb el teclat per a AturaBarra per sobre de l'ús exclusiu del ratolí. També s'ha reportat que la zona objectiu a vegades s'amaga per errors de posicionament vertical.

## Goals / Non-Goals

**Goals:**
- Restringir la selecció aleatòria als minijocs 1, 2 i 3.
- Mapar la tecla Espai a la lògica d'aturar la barra.
- Garantir la visibilitat vertical de la `ZonaObjectiu`.

**Non-Goals:**
- Implementar els minijocs 4, 5 i 6.
- Canviar el disseny dels elements de la UI.

## Decisions

- **Random.Range(1, 4)**: S'utilitzarà aquest rang per assegurar que només surten els 3 primers minijocs. A Unity, el límit superior és exclusiu per a integers, per tant `Random.Range(1, 4)` retornarà 1, 2 o 3.
- **Refactorització de Input a Update**: Per suportar l'espai, s'afegirà un check `Input.GetKeyDown(KeyCode.Space)` a l'Update del `MinijocUIManager` que només s'executarà si `_aturaBarraActiu` és cert. Això cridarà al mètode `HandleAturaBarraClick()` directament.
- **Estil Forçat (top: 0)**: Forçar la propietat `top` a 0 assegura que l'element s'alinea amb la part superior del seu contenidor pare (`FonsBarra`), evitant que quedi desplaçat cap avall o fora de la vista per marges o paddings residuals del fitxer UXML.

## Risks / Trade-offs

- **[Risk] Usuari prement Espai en altres minijocs**: Si no es neteja bé l'estat, el jugador podria aturar la barra accidentalment quan no toca. -> **[Mitigation]**: El flag `_aturaBarraActiu` ja s'encarrega de protegir aquesta entrada, i s'assegurarà que es posa a `false` en qualsevol mètode de neteja o canvi de minijoc.

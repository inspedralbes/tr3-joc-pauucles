## Context

Fins ara, la interacció amb els menús de combat (PPTLLS i Parells/Senars) s'ha limitat al ratolí. Aquest disseny introdueix un sistema de navegació basat en el teclat per permetre als jugadors moure's entre les opcions de joc i confirmar la seva tria mitjançant tecles estàndard (WASD, Fletxes, Espai, Enter).

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de navegació per llistes de botons dinàmiques segons el contenidor actiu.
- Proporcionar feedback visual clar del focus actual.
- Suportar confirmació de selecció via teclat.
- Reiniciar l'estat de navegació en obrir nous minijocs.

**Non-Goals:**
- Implementar navegació horitzontal complexa (només vertical/llista).
- Modificar el sistema de xarxa.

## Decisions

- **Llistes de Botons (`List<Button>`)**: Es crearan llistes internes per a cada minijoc (`_buttonsPPTLLS`, `_buttonsParellsSenars`) per facilitar l'accés per índex (`0` a `N-1`). Això evita fer queries repetitives en l'Update.
- **Índex de Selecció Centralitzat**: Un únic sencer `_currentButtonIndex` gestionarà el focus. En obrir un minijoc, es determinarà quina llista s'està usant i es posarà l'índex a 0.
- **Feedback Visual via style.backgroundColor**: Es modificarà directament el color de fons del botó seleccionat. S'utilitzarà un `StyleColor` per garantir la compatibilitat amb UI Toolkit.
- **Modularitat a l'Update**: Es crearà un mètode `GestionarNavegacioTeclat()` que es cridarà a l'Update només quan la UI estigui activa i no sigui el minijoc AturaBarra (que ja té la seva pròpia lògica d'input).

## Risks / Trade-offs

- **[Risk] Conflicte amb clics de ratolí**: Un usuari podria tenir un botó seleccionat amb el teclat i clicar-ne un altre amb el ratolí. -> **[Mitigation]**: El clic de ratolí sempre tindrà prioritat i tancarà la UI, de manera que la selecció de teclat queda invalidada a l'instant.
- **[Risk] Colors hardcoded**: Si es canvia el tema de la UI, els colors definits per codi podrien no encaixar. -> **[Mitigation]**: S'usarà un color gris clar neutre que sigui visible sobre el fons fosc actual.

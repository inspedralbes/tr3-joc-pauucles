## Context

Les pantalles de Login (`#pantallaLogin`) i Lobby (`#pantallaLobby`) utilitzen actualment contenidors de tipus "finestra" amb imatges de fons i layouts basats en Flexbox estàndard. Això fa que el posicionament dels elements interns (botons, camps de text) sigui dependent del contingut i dels marges, cosa que volem canviar per un control absolut sobre coordenades fixes.

## Goals / Non-Goals

**Goals:**
- Implementar la mateixa estructura de "centratge + capsa de dibuix fixa" usada a la pantalla de títol.
- Separar el contenidor d'estat (pantalla completa) del contenidor de visualització (capsa de mida fixa).
- Assegurar que tots els botons tinguin un estil transparent i posicionament absolut per permetre la futura superposició sobre art personalitzat.

**Non-Goals:**
- Modificar la lògica de login o de gestió de partides del lobby.
- Refactoritzar la `pantallaSalaEspera` o `pantallaInventari` en aquest canvi.
- Canviar els fitxers USS (els estils s'aplicaran directament via atributs style en l'UXML segons la petició).

## Decisions

1. **Estructura de Pantalla Completa (Full-screen wrappers)**:
   - **Decisió**: Configurar `#pantallaLogin` i `#pantallaLobby` amb `width: 100%`, `height: 100%`, `justify-content: center` i `align-items: center`.
   - **Raó**: Actuen com a telons de fons que centren les interfícies reals.

2. **Introducció de `#CapsaDibuixLogin` (500x700px)**:
   - **Decisió**: Crear aquest element com a fill directe de `#pantallaLogin` i moure-hi el contingut de `finestraLogin`.
   - **Raó**: El Login requereix un format més vertical per als camps de text i botons de registre.

3. **Introducció de `#CapsaDibuixLobby` (800x600px)**:
   - **Decisió**: Crear aquest element com a fill directe de `#pantallaLobby` i moure-hi el contingut de `finestraLobby`.
   - **Raó**: Manté la consistència amb la pantalla de títol (`#CapsaMaquina`).

4. **Posicionament Absolut Generalitzat**:
   - **Decisió**: Tots els fills interactius (Buttons, TextFields, ListView) dins de les capses de dibuix tindran `position: absolute`.
   - **Raó**: Permet situar els botons exactament on l'art de fons (que es posarà a la capsa de dibuix) ho requereixi.

## Risks / Trade-offs

- **[Risc] Resolució i retallat** → Com en el cas de la pantalla de títol, una resolució inferior a 800x600 retallarà el lobby. *Mitigació*: Es confia en l'escalat de panell d'Unity.
- **[Risc] Accessibilitat de tabulació** → El posicionament absolut no afecta l'ordre de tabulació (index), però pot ser confús visualment si no s'ordenen bé en l'UXML. *Mitigació*: Es mantindrà l'ordre lògic de dalt a baix en el fitxer.

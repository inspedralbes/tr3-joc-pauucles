## Context

Actualment, `MenuUI.uxml` utilitza una barreja de posicionament relatiu i absolut que depèn de la jerarquia de contenidors i marges percentuals (ex: `margin-top: 15%` al Label). Això fa que el disseny sigui impredictible en diferents resolucions si el que es busca és una interfície d'estil "arcade" amb elements en posicions fixes respecte a un marc.

## Goals / Non-Goals

**Goals:**
- Implementar una estructura de "capsa fixa" (Fixed Box) per a la pantalla de títol.
- Assegurar que el títol i els botons estiguin posicionats de forma absoluta dins d'un contenidor de 800x600px.
- Eliminar estils heretats que interfereixin amb el nou disseny (com imatges de fons a `#PantallaTitol`).

**Non-Goals:**
- Refactoritzar altres pantalles com `pantallaLogin` o `pantallaLobby` (aquestes mantindran la seva estructura actual).
- Canviar la funcionalitat dels botons (només es canvia el seu estil i posició).
- Afegir noves funcionalitats o scripts.

## Decisions

1. **Contenidor Pare (`#PantallaTitol`) com a Flex Centered**:
   - **Decisió**: Configurar `#PantallaTitol` amb `justify-content: center` i `align-items: center`.
   - **Raó**: Això garanteix que la "capsa de la màquina" de 800x600px estigui sempre perfectament centrada a la pantalla, independentment de la resolució.
   - **Alternativa**: Usar posicionament absolut per a la capsa, però el centratge amb Flexbox és més robust i net en UI Toolkit.

2. **Contenidor de Referència (`#CapsaMaquina`) amb Posicionament Relatiu**:
   - **Decisió**: Assignar `position: relative` a `#CapsaMaquina`.
   - **Raó**: En UI Toolkit/CSS, un element amb `position: absolute` es posiciona respecte al primer ancestre que tingui una posició definida (com `relative`). Això ens permet posar el títol i els botons a coordenades (X, Y) fixes dins de la capsa de 800x600.

3. **Eliminació de `#GrupBotons`**:
   - **Decisió**: Moure els botons directament a `#CapsaMaquina` i eliminar el contenidor intermedi `#GrupBotons`.
   - **Raó**: Simplifica la jerarquia. Amb posicionament absolut, cada botó pot ser gestionat de forma independent o coordinada sense necessitat d'un grup que apliqui un layout addicional.

4. **Estils de Botons "Nus"**:
   - **Decisió**: Treure fons i vores als botons.
   - **Raó**: Segons la petició, els botons han de ser transparents. Això suggereix que el disseny visual podria estar integrat en una imatge de fons de la pròpia `#CapsaMaquina` o simplement es vol un look minimalista.

## Risks / Trade-offs

- **[Risc] Desbordament en pantalles petites** → Si la pantalla és més petita de 800x600, la capsa podria quedar tallada. *Mitigació*: Es mantindrà `width: 800px` i `height: 600px` segons la petició, assumint que la resolució objectiu és superior o que s'usarà escalat de panell.
- **[Risc] Pèrdua de marges visuals** → En posar marges a 0 i posició absoluta, els elements podrien superposar-se si no es defineixen bé les coordenades `top`/`left`. *Mitigació*: S'ajustaran les posicions per mantenir l'estètica actual o la demanada.

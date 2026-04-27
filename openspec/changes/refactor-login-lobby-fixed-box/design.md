## Context

L'estructura actual del menú utilitza centratge automàtic però manté algunes dependències de jerarquia Flexbox per als elements interns. Per permetre una superposició perfecta amb arts de fons de tipus "panell arcade", cal que cada pantalla (`Login` i `Lobby`) tingui una "capsa de dibuix" central amb coordenades fixes (X, Y) per a tots els seus components.

## Goals / Non-Goals

**Goals:**
- Implementar `#CapsaDibuixLogin` (500x700px) i `#CapsaDibuixLobby` (900x500px).
- Eliminar imatges de fons dels contenidors pare per deixar-les "netes".
- Assegurar que tots els `TextField`, `Label`, `Button` i `ListView` dins d'aquestes capses usin `position: absolute`.
- Establir marges a 0 per evitar desplaçaments no desitjats per herència.

**Non-Goals:**
- Refactoritzar `pantallaSalaEspera` o `pantallaInventari` (es farà en canvis posteriors si cal).
- Canviar la lògica C# associada als botons.

## Decisions

1. **Centratge de Capses via Flexbox**:
   - **Decisió**: Usar `justify-content: center` i `align-items: center` als contenidors pare.
   - **Raó**: És el mètode més robust per mantenir la "capsa fixa" sempre al centre de la pantalla física, independentment de la relació d'aspecte.

2. **Posicionament Absolut Generalitzat**:
   - **Decisió**: Forçar `position: absolute` a tots els elements interns de les capses de dibuix.
   - **Raó**: Permet situar els camps d'usuari i els botons en llocs molt específics (ex: sobre una ranura o un panell del dibuix de fons).

3. **Mides Específiques**:
   - **Decisió**: Lobby a 900x500 i Login a 500x700.
   - **Raó**: Segons requeriments de disseny per encabir millor la llista de partides horitzontalment i el login verticalment.

## Risks / Trade-offs

- **[Risc] Resolució petita** → Si la finestra és menor que la capsa (ex: menor de 900px d'ample), s'haurà d'usar l'escalat de panell d'Unity per evitar retalls. *Mitigació*: Es manté el layout fix i es delega el reescalat a la configuració del `PanelSettings`.
- **[Risc] Pèrdua de layout automàtic** → En moure elements a posició absoluta, cal definir manualment les coordenades `top` i `left`. *Mitigació*: S'ajustaran els valors inicials per mantenir una visibilitat funcional.

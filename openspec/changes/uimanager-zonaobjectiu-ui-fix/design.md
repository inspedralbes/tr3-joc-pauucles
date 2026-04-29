## Context

S'ha reportat que la `ZonaObjectiu` del minijoc AturaBarra no es veu per pantalla a Unity. Això pot ser degut a mides zero per defecte, colors transparents o problemes de profunditat/posicionament en el layout de UI Toolkit.

## Goals / Non-Goals

**Goals:**
- Forçar la visibilitat visual de la `ZonaObjectiu` mitjançant sobreescriptura d'estils per codi.
- Assegurar que les mides i el color de l'element siguin els adequats per al gameplay.

**Non-Goals:**
- Implementar animacions a la zona objectiu.
- Canviar la lògica de col·lisió (només el fix d'UI).

## Decisions

- **Sobreescriptura d'Estils per Codi**: Tot i que l'ideal és gestionar-ho via USS/UXML, forçar-ho per codi en el moment de la inicialització garanteix que l'element es renderitza correctament independentment de l'estat del fitxer d'assets.
- **Color Groc**: S'ha triat el color groc (`Color.yellow`) per a una alta visibilitat sobre el fons de la barra.
- **Posicionament Absolut**: Establir `Position.Absolute` i `top = 0` assegura que l'element s'alinea a la part superior del seu pare (`FonsBarra`) i no es veu afectat per la disposició `Flex` automàtica d'altres elements fills.

## Risks / Trade-offs

- **[Risk] Mida fixa**: Si la barra canvia de mida en diferents resolucions, 80px podria ser massa gran o petit. -> **[Mitigation]**: Es mantindrà com una constant per ara fins que es requereixi un disseny responsiu més complex.

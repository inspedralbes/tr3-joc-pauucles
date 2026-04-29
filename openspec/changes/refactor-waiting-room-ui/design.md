## Context

Després d'implementar la navegació bàsica a la Sala d'Espera, el següent pas és dotar-la de contingut útil (la llista de jugadors) i assegurar-se que la transició de tornada al Lobby sigui robusta. Hi ha un retard conegut on el Lobby pot intentar refrescar-se abans que el backend hagi processat completament la sortida del jugador de la sala.

## Goals / Non-Goals

**Goals:**
- Implementar un `ListView` dinàmic per a la Sala d'Espera.
- Solucionar la condició de carrera en refrescar el Lobby introduint un petit retard controlat.
- Estabilitzar la visualització de jugadors a la sala.

**Non-Goals:**
- No s'implementarà la sincronització en temps real (via WebSocket) de la llista de jugadors en aquesta fase; la llista es carregarà en el moment d'entrar a la sala.

## Decisions

- **Uso de Corrutina per al Retard**: S'utilitza `WaitForSeconds(0.5f)` per donar temps al backend a actualitzar l'estat de les sales abans de tornar a demanar la llista de partides del Lobby.
- **Configuració del ListView**: S'assignaran programàticament els mètodes `makeItem` i `bindItem` del `llistaJugadorsSala` per evitar dependències excessives en l'Editor de Unity. Es forçarà el color del text a blanc per garantir llegibilitat.

## Risks / Trade-offs

- **[Risk] Temps de retard insuficient** → **Mitigation**: El retard de 0.5s sol ser suficient per a operacions locals o en xarxes amb latència normal. Si el problema persisteix, es podria augmentar el temps o utilitzar un mecanisme de resposta explícit del servidor.
- **[Trade-off] Llista Estàtica** → **Mitigation**: Tot i que la llista només es carrega un cop (en entrar), és una millora significativa respecte a no tenir llista.

## Migration Plan

1. Definir la variable `llistaJugadorsSala` a `MenuManager.cs`.
2. Implementar `RefrescarLobbyAmbRetard`.
3. Implementar `OmplirLlistaJugadors`.
4. Actualitzar els esdeveniments de UI existents per cridar a les noves funcions.

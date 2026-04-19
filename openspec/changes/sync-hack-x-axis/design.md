## Context

Actualment, el sistema de sincronització entre jugadors només transmet les coordenades X i Y. Per notificar que un jugador ha guanyat un minijoc de forma ràpida (sense dependre de missatges Socket.io addicionals que podrien patir retard), es proposa utilitzar una posició fora dels límits del mapa com a senyal binari. L'eix Z no és viable perquè es descarta en la serialització de xarxa 2D.

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de senyalització robust usant coordenades X extremes.
- Garantir que el jugador local torna a la seva posició original sense que l'usuari percebi el teletransport.
- Detectar el senyal del rival i finalitzar el minijoc localment amb derrota.

**Non-Goals:**
- No es pretén crear un sistema de missatgeria genèric; és un hack específic per a la sincronització de victòries en minijocs.

## Decisions

- **Coordenada de Senyalització**: S'ha triat `X = 9999f` i `Y = 9999f`. Aquesta posició és prou llunyana per no interferir amb cap element del joc i és fàcil de detectar amb una comparació `>= 9000f`.
- **Restauració via Corrutina**: S'utilitzarà `IEnumerator TornarPosicio()` amb un `yield return new WaitForSeconds(0.2f)`. Aquest temps és suficient perquè el sistema de xarxa capti la posició extrema i la transmeti.
- **Detecció en GameManager**: La comprovació es realitzarà al mètode `UpdateRemotePlayer` (o equivalent que rebi posicions de xarxa). Si la X rebuda és `>= 9000f`, s'executarà la lògica de derrota local i es farà un `return` per evitar que el `RemotePlayer` es mogui visualment a la posició de senyal.

## Risks / Trade-offs

- **[Risk]** El sistema de xarxa podria perdre el paquet de la posició extrema. → **[Mitigation]** El temps de 0.2 segons garanteix que s'enviïn múltiples paquets de posició abans de restaurar.
- **[Risk]** Conflicte si un jugador realment arriba a X=9999. → **[Mitigation]** El mapa del joc està delimitat i és impossible arribar a aquestes coordenades de forma natural.

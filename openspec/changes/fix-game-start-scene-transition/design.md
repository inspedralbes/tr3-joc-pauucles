## Context

El flux d'inici de partida requereix una coordinació precisa entre el backend i el frontend. El servidor ha de decidir quan la partida està a punt per començar i notificar-ho als clients amb la informació de sessió que necessitaran a la nova escena.

## Goals / Non-Goals

**Goals:**
- Sincronitzar el canvi d'escena entre tots els jugadors d'una sala.
- Proveir a cada client la seva identitat de joc (equip i color).
- Garantir una càrrega d'escena segura des del fil principal de Unity.

**Non-Goals:**
- No es modificarà el comportament del jugador un cop dins de l'escena 'Bosque'.
- No es tractarà la lògica de combat en aquest canvi.

## Decisions

- **Estratègia de Broadcast Personalitzat**: El backend podria fer un broadcast massiu d'un array de dades, però per simplificar la lògica del client i augmentar la seguretat, s'enviarà un missatge individualitzat a cada socket connectat a la sala amb les seves dades específiques.
- **Estructura del JSON**: El missatge `PARTIDA_INICIADA` contindrà `username`, `team` i `color`. El color es calcularà al backend basant-se en l'equip assignat (A o B) i els colors configurats per a la sala (`teamAColor` / `teamBColor`).
- **Fil d'Execució a Unity**: Les operacions de `SceneManager.LoadScene` només són vàlides al fil principal. S'utilitzarà el flag `shouldStartGame` dins de `WebSocketClient` per realitzar la transició al mètode `Update`.

## Risks / Trade-offs

- **[Risc] Sincronització de color** → Si el servidor envia un nom de color que Unity no reconeix. → **[Mitigació]** El script `Nametag.cs` ja té una funció de traducció de colors; s'assegurarà que els strings enviats coincideixin amb els `case` d'aquesta funció.
- **[Risc] Pèrdua de missatges** → Si un client perd la connexió just en el moment del broadcast. → **[Mitigació]** S'ha d'implementar un mecanisme de reconnexió o timeout en el futur (fora d'aquest abast).

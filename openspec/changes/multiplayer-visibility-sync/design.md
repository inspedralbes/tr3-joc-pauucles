## Context

El joc necessita passar d'una experiència local a una multijugador. Això implica sincronitzar el moviment (posició i animacions) i assegurar que els elements visuals (Nametags) funcionen correctament en xarxa.

## Goals / Non-Goals

**Goals:**
- Sincronitzar posició, orientació i animacions entre clients.
- Corregir el Nametag invertit a Unity.
- Instanciar representacions visuals dels altres jugadors.

**Non-Goals:**
- Implementar interpolació avançada o predicció de moviment (per ara es farà actualització directa).
- Gestió de col·lisions en xarxa (es mantenen col·lisions locals).

## Decisions

### 1. Rotació via SpriteRenderer.flipX
S'abandonarà l'ús de `transform.localScale = -1` per girar el personatge.
- **Racional:** `localScale` afecta a tots els fills, inclòs el Canvas del Nametag, fent que el text es vegi del revés. `flipX` només afecta al renderitzat de la imatge de l'sprite.

### 2. Protocol de Moviment a 10Hz
El client Unity enviarà la seva posició cada 0.1 segons (10 cops per segon) si hi ha hagut canvis.
- **Racional:** És un equilibri entre fluïdesa i càrrega de xarxa/servidor per a un prototip d'aquest estil.

### 3. Broadcast Global amb Filtre en Client
El backend farà broadcast de `PLAYER_MOVE` a tots els clients. Els clients filtraran si el missatge pertany a la seva sala i si és d'un jugador diferent a ells mateixos.
- **Racional:** Atès que el servidor actual no manté un mapeig estricte de "sockets a sales" per a broadcasts parcials, el broadcast global és la solució més ràpida i fiable pel prototip actual.

### 4. Gestió de Jugadors Remots
El `GameManager` (o un `RemotePlayerManager`) mantindrà un diccionari de `username -> GameObject` per actualitzar els jugadors remots sense haver de buscar-los a cada frame.

## Risks / Trade-offs

- **[Risk]** El moviment dels jugadors remots pot semblar a trompicons (*jitter*) per la manca d'interpolació. -> **Mitigation:** S'accepta per a la fase actual del projecte; s'afegirà `Vector2.Lerp` si és necessari més endavant.
- **[Trade-off]** Broadcast global de moviment consumeix més ample de banda. -> **Mitigation:** Amb pocs jugadors i missatges petits (JSON simple), el servidor pot gestionar-ho sense problemes.

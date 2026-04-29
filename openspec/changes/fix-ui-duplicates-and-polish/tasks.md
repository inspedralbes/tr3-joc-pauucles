## 1. Backend (Sincronització de Sales)

- [x] 1.1 Modificar el listener d'esdeveniments de WebSocket a `server.js` (o controller) per detectar quan un usuari abandona una sala (`leave_room`).
- [x] 1.2 Implementar el broadcast `ROOM_UPDATED` immediatament després que un jugador hagi marxat d'una sala que encara conté participants.

## 2. Frontend (Consistència de Llistes)

- [x] 2.1 Modificar la funció d'actualització de llista de sales a `MenuManager.cs` per assegurar la neteja de la font de dades (`itemsSource = null`) i el refresc del component.
- [x] 2.2 Modificar la funció d'actualització de la llista de jugadors a la sala d'espera per buidar el contenidor (`.Clear()`) abans d'afegir els noms actualitzats.

## 3. UI/UX (Poliment Visual)

- [x] 3.1 Revisar `MenuUI.uxml` i ajustar les classes dels contenidors principals per permetre el centrat Flexbox.
- [x] 3.2 Actualitzar el fitxer `.uss` per aplicar `justify-content: center` i `align-items: center` als contenidors arrel i seccions de menú.
- [x] 3.3 Ajustar els marges i padding dels botons per evitar el col·lapse visual.
- [x] 3.4 Eliminar imatges de fons innecessàries i ajustar colors de fons i textos per a una estètica professional.

## 4. Verificació

- [ ] 4.1 Provar el flux de "Join -> Leave -> Join" i confirmar que no apareixen duplicats a la sala d'espera.
- [ ] 4.2 Validar que la UI es manté centrada i llegible en diferents mides de finestra del Game View de Unity.

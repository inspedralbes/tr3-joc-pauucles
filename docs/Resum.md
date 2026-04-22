# Resum del Projecte TR3 - Atrapa la Bandera Multijugador

**Curs:** 2DAM 2025-2026
**Nom del Projecte:** Atrapa la Bandera Cyberpunk
**Integrants:** Pau Uclés

### Objectiu del Projecte
El projecte consisteix en un videojoc 2D multijugador desenvolupat amb Unity que implementa una mecànica de "Atrapa la Bandera" en un entorn Cyberpunk. Els jugadors poden identificar-se, personalitzar el seu personatge amb skins, crear o unir-se a sales de joc i competir en temps real.

### Arquitectura i Tecnologies
L'aplicació segueix una arquitectura client-servidor amb les següents característiques:

- **Frontend (Unity)**: Desenvolupat en C#, utilitza `UnityWebRequest` per a l'API REST i `WebSockets` (ws) per a la sincronització de la partida en temps real. Inclou integració amb ML-Agents per a comportaments autònoms.
- **Backend (Node.js)**: Implementat amb **microserveis** per separar la gestió d'usuaris (Identity Service) de la lògica de joc i WebSockets (Game Service).
- **Persistència (MongoDB)**: S'utilitza el patró **Repository** per desacoblar la lògica de negoci de la base de dades. Els serveis utilitzen `Mongoose` per a la comunicació amb un cluster de MongoDB Atlas.
- **Desplegament (Producció)**: El backend es troba desplegat en un servidor Ubuntu amb **Nginx** com a proxy invers i **PM2** per a la gestió de processos. La seguretat està reforçada amb **fail2ban**.

**Vídeo Demo:** [Enllaç al vídeo de Canva](https://www.canva.com/design/...) (Nota: Substituir per l'enllaç final)

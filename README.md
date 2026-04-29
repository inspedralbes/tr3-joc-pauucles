# Atrapa el Dinosaure

Projecte transversal de 2DAM curs 2025-2026.

## Integrants
* **Pau Uclés**

## Descripció del Projecte
**Atrapa el Dinosaure** (també conegut com Atrapa la Bandera Cyberpunk) és un videojoc 2D multijugador desenvolupat amb **Unity** i **Node.js**. El joc implementa una mecànica clàssica de "Atrapa la Bandera" en un entorn amb estètica Cyberpunk. Els jugadors poden competir en temps real, gestionar el seu perfil i personalitzar el seu personatge.

### Característiques Principals
* **Multijugador en temps real**: Sincronització de moviments i accions mitjançant WebSockets.
* **Microserveis**: Arquitectura de backend escalable separant la identitat de la lògica de joc.
* **Patró Repository**: Capa de persistència desacoblada que suporta MongoDB i memòria volàtil.
* **IA amb ML-Agents**: Enemics i personatges autònoms amb comportaments complexos.

## Gestió del Projecte
* **Taiga**: [Projecte Atrapa el Dinosaure](https://tree.taiga.io/project/atrapa-el-dinosaure)

## Documentació
* [Manual d'Instal·lació](MANUAL_INSTALACIO.md)
* [Patró Repository](PATTERN_REPOSITORY.md)
* [Disseny de Microserveis](openspec/changes/refactor-to-microservices/design.md)

# Foundations: Minijoc Llangardaix-Spock

## 1. Context
Aquest minijoc forma part de l'EPIC 2 (Desenvolupament guiat per IA / OpenSpec) per al projecte TR3. S'utilitzarà per resoldre enfrontaments ràpids entre dos jugadors quan col·lideixen al mapa lluitant per la bandera.

## 2. Objectius
* Implementar la lògica de victòria de "Pedra, Paper, Tisora, Llangardaix, Spock".
* Demostrar l'ús de la metodologia Spec-Driven Development (SDD) controlant l'agent d'IA.
* Tenir una funcionalitat acotada, testejable i amb 10 combinacions possibles d'èxit.

## 3. Restriccions
* Tota la lògica s'ha d'executar 100% en local al client d'Unity (C#). No es pot modificar el servidor de cap manera per a aquest minijoc.
* El codi ha de ser modular i independent del `MonoBehaviour` perquè sigui fàcil de testejar.
* La documentació i el codi han d'estar alineats amb el disseny original.
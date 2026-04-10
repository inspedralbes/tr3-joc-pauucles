# Pla d'Implementació: Minijoc Llangardaix-Spock

## 1. Estructura de Dades
- Crear un `enum OpcioMinijoc { Pedra, Paper, Tisora, Llangardaix, Spock }`.
- Crear un `enum ResultatMinijoc { GuanyaJugador1, GuanyaJugador2, Empat }`.

## 2. Classe Principal
- Crear un script C# anomenat `MinijocSpockLogic`.
- Aquest script NO ha de ser un `MonoBehaviour` (no necessita anar lligat a un objecte d'Unity), només ha de contenir la lògica matemàtica pura per poder ser cridat des del script `Player`.

## 3. Funció Principal
- Implementar un mètode públic i estàtic: 
  `public static ResultatMinijoc AvaluarGuanyador(OpcioMinijoc j1, OpcioMinijoc j2)`
- Utilitzar un bloc `switch` o una sèrie de `if/else` que implementi les 10 regles definides al document `spec.md`.
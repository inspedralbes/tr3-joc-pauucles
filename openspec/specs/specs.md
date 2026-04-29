# Especificació: Lògica de Victòria (Llangardaix-Spock)

## 1. Descripció del Comportament
El sistema ha de rebre dues eleccions (Jugador 1 i Jugador 2) i determinar el guanyador de la ronda basant-se estrictament en les 10 regles estàndard del joc "Pedra, Paper, Tisora, Llangardaix, Spock". La lògica s'ha d'executar completament al client.

## 2. Opcions Vàlides
Les úniques opcions possibles (enumeració recomanada) són: `Pedra`, `Paper`, `Tisora`, `Llangardaix`, `Spock`.

## 3. Matriu de Resultats (Regles de Negoci)
El codi ha d'avaluar les següents condicions per declarar la victòria d'un jugador sobre l'altre:
1. **Tisora** talla *Paper*.
2. **Paper** cobreix *Pedra*.
3. **Pedra** esclafa *Llangardaix*.
4. **Llangardaix** enverina *Spock*.
5. **Spock** trenca *Tisora*.
6. **Tisora** decapita *Llangardaix*.
7. **Llangardaix** es menja *Paper*.
8. **Paper** desmenteix *Spock*.
9. **Spock** vaporitza *Pedra*.
10. **Pedra** esclafa *Tisora*.

## 4. Empat
Si el Jugador 1 i el Jugador 2 trien exactament la mateixa opció, el resultat ha de retornar `Empat` de forma automàtica, sense avaluar les regles anteriors.
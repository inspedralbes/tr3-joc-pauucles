## 1. Gestió d'Empats a PPTLLS i Parells/Senars

- [x] 1.1 Localitzar la lògica de resolució d'empat a `HandlePPTLLSClick()` i `HandleParellsSenarsClick()`.
- [x] 1.2 Modificar el comportament per actualitzar `_textResultat.text` amb "Empat! Torneu a triar!".
- [x] 1.3 Assegurar que les variables d'elecció (`_eleccioPPTLLS_J1`, etc.) es posen a `null`.
- [x] 1.4 Verificar que NO es crida a `MostrarResultatIEsperar()` en cas d'empat.

## 2. Identificació de Jugadors per Nom

- [x] 2.1 Actualitzar els missatges de victòria a `HandlePPTLLSClick()` per utilitzar `_jugador1.name` o `_jugador2.name`.
- [x] 2.2 Actualitzar els missatges de victòria a `HandleParellsSenarsClick()` per utilitzar els noms dels jugadors.
- [x] 2.3 Actualitzar el missatge de l'AturaBarra per incloure el nom del guanyador.
- [x] 2.4 Revisar la corrutina `MostrarResultatIEsperar()` per assegurar que el missatge final és coherent.

## 3. Validació

- [x] 3.1 Provocar un empat a PPTLLS i confirmar que la UI permet tornar a triar sense tancar-se.
- [x] 3.2 Guanyar un combat i verificar que el text mostra el nom real de l'objecte (ex: "Square ha guanyat!").
- [x] 3.3 Confirmar que la bandera es roba correctament després del missatge personalitzat.

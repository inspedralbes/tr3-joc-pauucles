## 1. Correcció de la Lògica AFK a Player.cs

- [x] 1.1 Localitzar el mètode `Update()` a `DAMT3Atrapa la bandera/Assets/Scripts/Player.cs`.
- [x] 1.2 Implementar una secció de reseteig al principi del mètode que s'activi si `!potMoure`.
- [x] 1.3 Afegir el reseteig de `tempsInactiu = 0f` i la restauració de l'alpha a `1f` en entrar en un estat immòbil.
- [x] 1.4 Modificar el bloc de \"GESTIÓ AFK\" per assegurar que l'increment de temps i el parpelleig només es realitzin quan el jugador és lliure de moure's.

## 2. Verificació

- [x] 2.1 Confirmar que el personatge no parpelleja mentre està en combat.
- [x] 2.2 Verificar que el parpelleig s'atura immediatament si el jugador rep un impacte que el deixa estabornit (`potMoure = false`).
- [x] 2.3 Validar que el comportament AFK normal continua funcionant quan el jugador està actiu però quiet.

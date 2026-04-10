## 1. Modificacions a Player.cs (Variables i Proximitat)

- [x] 1.1 Afegir les variables `bool aPropDeBandera = false;` i `GameObject banderaPropera = null;` a la classe `Player`.
- [x] 1.2 Actualitzar `OnCollisionEnter2D` (o `OnTriggerEnter2D`) per detectar el tag "Bandera" i activar la proximitat sense recollir l'objecte.
- [x] 1.3 Implementar `OnCollisionExit2D` (o `OnTriggerExit2D`) per netejar les variables de proximitat quan el jugador s'allunya.

## 2. Modificacions a Player.cs (Input i Recollida)

- [x] 2.1 Afegir la comprovació d'input al mètode `Update`.
- [x] 2.2 Diferenciar l'input per `idJugador`: J1 (E), J2 (Ctrl Dreta).
- [x] 2.3 Implementar la lògica de recollida dins de la comprovació d'input:
    - Fes `SetParent(this.transform)`.
    - Desactiva l'estat fugitiu: `banderaPropera.GetComponent<Bandera>().fugint = false;`.
    - Desactiva el collider de la bandera.
    - Reinicia `aPropDeBandera = false`.

## 3. Validació

- [x] 3.1 Comprovar que la bandera ja no es recull automàticament en tocar-la.
- [x] 3.2 Verificar que la tecla 'E' funciona per al Jugador 1 quan està a prop.
- [x] 3.3 Verificar que la tecla 'Ctrl Dreta' funciona per al Jugador 2 quan està a prop.
- [x] 3.4 Confirmar que allunyar-se de la bandera sense recollir-la permet que un altre la pugui agafar.

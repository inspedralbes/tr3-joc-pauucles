## 1. Refactorització de Codi

- [x] 1.1 Revisar `Player.cs` i cercar totes les ocurrències de `isKinematic`.
- [x] 1.2 Substituir `isKinematic = true` per `bodyType = RigidbodyType2D.Kinematic`.
- [x] 1.3 Substituir `isKinematic = false` per `bodyType = RigidbodyType2D.Dynamic`.
- [x] 1.4 Revisar `MinijocUIManager.cs` i altres scripts per assegurar que no queden ocurrències obsoletes.

## 2. Validació

- [x] 2.1 Verificar que el projecte compila sense avisos CS0618 a la consola.
- [x] 2.2 Confirmar que el moviment del jugador i el transport de la bandera segueixen funcionant correctament a Unity.

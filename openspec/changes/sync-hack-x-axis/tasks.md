## 1. Modificacions a Player.cs

- [x] 1.1 Declarar la variable privada `private Vector3 posAbansDeGuanyar;`.
- [x] 1.2 Modificar el mètode `GuanyarMinijoc()` per desar la posició actual i teletransportar el jugador a `(9999f, 9999f, 0)`.
- [x] 1.3 Assegurar que `potMoure = true` es crida en `GuanyarMinijoc()`.
- [x] 1.4 Implementar la corrutina `TornarPosicio()` que espera 0.2 segons i restaura la posició.
- [x] 1.5 Cridar `StartCoroutine(TornarPosicio())` des de `GuanyarMinijoc()`.

## 2. Modificacions a GameManager.cs

- [x] 2.1 Localitzar el mètode que processa els missatges de posició remota (ex: `UpdateRemotePlayer`).
- [x] 2.2 Afegir una comprovació al principi del mètode per verificar si la `x` del missatge rebut és `>= 9000f`.
- [x] 2.3 Si es detecta el senyal: tancar la UI de minijocs (usant `MinijocUIManager.Instance.gameObject.SetActive(false)` o similar).
- [x] 2.4 Si es detecta el senyal: buscar el jugador local (etiqueta "Player") i cridar-li `PerdreMinijoc()`.
- [x] 2.5 Si es detecta el senyal: fer un `return;` immediat per evitar processar el moviment del `RemotePlayer`.

## 3. Verificació

- [x] 3.1 Comprovar que el jugador local torna a la seva posició original després de guanyar.
- [x] 3.2 Verificar que el sistema de xarxa no transmet l'eix Z (confirmar la necessitat d'aquest canvi).
- [x] 3.3 Validar que el rival rep el senyal de derrota correctament.

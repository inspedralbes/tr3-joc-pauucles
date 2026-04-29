## 1. Flag Acquisition in Player.cs

- [x] 1.1 Update `OnCollisionEnter2D` in `Player.cs` to check for collision with tag "Bandera".
- [x] 1.2 Implement reparenting: `collision.gameObject.transform.SetParent(this.transform)`.
- [x] 1.3 Set local offset: `collision.gameObject.transform.localPosition = new Vector3(-0.8f, 0, 0)`.

## 2. Flag Theft in MinijocUIManager.cs

- [x] 2.1 Find flag object in `ProcessarResultatCombat` using `GameObject.FindGameObjectWithTag("Bandera")`.
- [x] 2.2 Verify if the flag's parent is the loser player.
- [x] 2.3 Implement theft: Transfer parent from loser to winner.
- [x] 2.4 Set local offset for winner: `localPosition = new Vector3(-0.8f, 0, 0)`.

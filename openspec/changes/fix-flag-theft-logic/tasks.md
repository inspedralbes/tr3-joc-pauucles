## 1. Modificacions a MinijocUIManager.cs

- [x] 1.1 Localitzar el mètode `ProcessarResultatCombat` (o on es gestioni el robatori) a `MinijocUIManager.cs`.
- [x] 1.2 Implementar la verificació de possessió usant `bandera.transform.IsChildOf(perdedor.transform)`.
- [x] 1.3 Si es confirma la possessió, invocar el robatori fent:
    - `bandera.transform.SetParent(guanyador.transform)`.
    - `bandera.transform.localPosition = new Vector3(-0.8f, 0, 0)`.
    - `bandera.transform.localScale = Vector3.one`.
- [x] 1.4 Afegir el log: `Debug.Log($"ROBATORI EFECTUAT: {guanyador.name} ha robat la bandera a {perdedor.name}");`.

## 2. Modificacions a Player.cs

- [x] 2.1 Al mètode `OnTriggerEnter2D` (quan xoca amb la "Bandera" al terra), assegurar que s'executa `other.transform.SetParent(this.transform)` per garantir la jerarquia.
- [x] 2.2 Replicar el posicionament correcte (`-0.8, 0, 0`) en la recollida normal per consistència visual.

## 3. Validació

- [x] 3.1 Comprovar a Unity que el robatori només es produeix si el perdedor realment porta la bandera.
- [x] 3.2 Confirmar que la bandera es posiciona lateralment a `-0.8` tant en robatori com en recollida normal.
- [x] 3.3 Verificar els logs de robatori a la consola.

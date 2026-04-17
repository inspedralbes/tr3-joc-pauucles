## 1. Modificació de Player.cs

- [x] 1.1 Localitzar el mètode `AgafarBanderaAutomàticament` a `Player.cs`.
- [x] 1.2 Substituir COMPLETAMENT el mètode pel següent codi:
  ```csharp
  private void AgafarBanderaAutomàticament(GameObject objBandera) { 
      Collider2D colB = objBandera.GetComponent<Collider2D>(); 
      if (colB != null) { 
          Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colB, true); 
      } 
      AgafarBandera(objBandera.transform); 
  }
  ```
- [x] 1.3 Assegurar-se que no quedi cap referència a `colB.enabled = false` o similars en aquest mètode.

## 2. Verificació

- [x] 2.1 Confirmar que al recollir la bandera, aquesta no es desactivarà físicament.
- [x] 2.2 Verificar que el jugador i la bandera ignoren les col·lisions entre ells correctament.
- [x] 2.3 Confirmar que la bandera manté la seva posició sobre el terra en ser recollida.

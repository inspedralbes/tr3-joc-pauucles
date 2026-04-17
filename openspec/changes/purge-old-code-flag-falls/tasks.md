## 1. Purga a Player.cs

- [x] 1.1 Reescriure el mètode `AgafarBandera(Transform bandera)` a `Player.cs` exactament així:
  ```csharp
  public void AgafarBandera(Transform bandera) { 
      banderaAgafada = bandera; 
      bandera.SetParent(null); 
      Collider2D meuCol = GetComponent<Collider2D>(); 
      Collider2D[] dinoCols = bandera.GetComponentsInChildren<Collider2D>(); 
      foreach(Collider2D c in dinoCols) { 
          if(c != null && meuCol != null) Physics2D.IgnoreCollision(meuCol, c, true); 
      } 
      Bandera scriptB = bandera.GetComponent<Bandera>(); 
      if(scriptB != null) scriptB.ComençarASeguir(this.transform); 
  }
  ```

## 2. Purga a Bandera.cs

- [x] 2.1 Reescriure o afegir el mètode `ComençarASeguir(Transform target)` a `Bandera.cs` exactament així:
  ```csharp
  public void ComençarASeguir(Transform target) { 
      targetSeguiment = target; 
      Rigidbody2D rb = GetComponent<Rigidbody2D>(); 
      if(rb != null) rb.bodyType = RigidbodyType2D.Dynamic; 
      Collider2D col = GetComponent<Collider2D>(); 
      if(col != null) col.enabled = true; 
  }
  ```

## 3. Verificació

- [x] 3.1 Confirmar que la bandera manté la seva física dinàmica després de ser recollida.
- [x] 3.2 Verificar que el collider local del Dino s'habilita correctament al començar el seguiment.

## 1. Modificacions a Bandera.cs

- [x] 1.1 Implementar el mètode `DeixarDeSeguir()` a `Bandera.cs`:
  ```csharp
  public void DeixarDeSeguir() { 
      targetSeguiment = null; 
      Rigidbody2D rb = GetComponent<Rigidbody2D>(); 
      if (rb != null) { 
          rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); 
      } 
  }
  ```

## 2. Modificacions a Player.cs

- [x] 2.1 Implementar el mètode `DeixarBandera()` a `Player.cs`:
  ```csharp
  public void DeixarBandera() { 
      if (banderaAgafada != null) { 
          Bandera scriptB = banderaAgafada.GetComponent<Bandera>(); 
          if (scriptB != null) { 
              scriptB.DeixarDeSeguir(); 
          } 
          banderaAgafada = null; 
      } 
  }
  ```

## 3. Verificació

- [x] 3.1 Confirmar que l'error CS1061 ha desaparegut.
- [x] 3.2 Verificar que el jugador pot alliberar la bandera i la mascota s'atura.

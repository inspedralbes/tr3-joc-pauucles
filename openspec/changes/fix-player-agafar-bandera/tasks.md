## 1. Modificació de Player.cs

- [x] 1.1 Localitzar el mètode `AgafarBandera(Transform bandera)` a `Player.cs`.
- [x] 1.2 Substituir el contingut del mètode pel codi especificat:
  ```csharp
  public void AgafarBandera(Transform bandera) { 
      banderaAgafada = bandera; 
      banderaAgafada.SetParent(null); 
      Rigidbody2D rbBandera = banderaAgafada.GetComponent<Rigidbody2D>(); 
      if (rbBandera != null) { 
          rbBandera.bodyType = RigidbodyType2D.Dynamic; 
      } 
      Bandera scriptB = bandera.GetComponent<Bandera>(); 
      if (scriptB != null) { 
          scriptB.ComençarASeguir(this.transform); 
      } 
  }
  ```

## 2. Verificació

- [x] 2.1 Confirmar que la bandera manté la seva física independent en ser recollida.
- [x] 2.2 Verificar que s'inicia el seguiment de la mascota correctament.

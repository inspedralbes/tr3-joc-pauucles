## 1. Purga de Codi Mort

- [x] 1.1 Eliminar la declaració de la variable `banderaPortant` i qualsevol assignació (`banderaPortant = ...`) a `Player.cs`.
- [x] 1.2 Eliminar qualsevol comprovació del tag "Bandera" a `OnCollisionEnter2D`.
- [x] 1.3 Eliminar sencer el mètode `AgafarBandera(Transform bandera)`.
- [x] 1.4 Eliminar sencer el mètode `AgafarBanderaAutomàticament(GameObject objBandera)`.

## 2. Consolidació de Recollida

- [x] 2.1 Reescriure o substituir el mètode `OnTriggerEnter2D` per la versió consolidada:
  ```csharp
  private void OnTriggerEnter2D(Collider2D collision) { 
      if (collision.CompareTag("Bandera") && banderaAgafada == null) { 
          Bandera scriptB = collision.GetComponentInParent<Bandera>(); 
          if (scriptB != null) { 
              banderaAgafada = scriptB.transform; 
              Collider2D meuCol = GetComponent<Collider2D>(); 
              Collider2D[] dinoCols = scriptB.GetComponentsInChildren<Collider2D>(); 
              foreach (Collider2D c in dinoCols) { 
                  if (c != null && meuCol != null) { 
                      Physics2D.IgnoreCollision(meuCol, c, true); 
                  } 
              } 
              scriptB.ComençarASeguir(this.transform); 
          } 
      } 
  }
  ```
- [x] 2.2 Assegurar que es manté la resta de la lògica de `OnTriggerEnter2D` (Bases, Escaleres, etc.) integrada amb el nou codi.

## 3. Verificació

- [x] 3.1 Comprovar que ja no hi ha advertències de compilació CS0414.
- [x] 3.2 Verificar que la bandera es recull correctament en entrar en contacte amb el Trigger.
- [x] 3.3 Confirmar que no hi ha conflictes de col·lisió física entre el jugador i la mascota.

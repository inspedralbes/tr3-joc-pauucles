## Context

El mètode `AgafarBanderaAutomàticament` a `Player.cs` és el punt d'entrada quan un jugador recull la bandera. Si aquest mètode desactiva el collider, la bandera perd la seva capacitat de recolzar-se en plataformes i cau a través d'elles.

## Goals / Non-Goals

**Goals:**
- Substituir la desactivació del collider per una excepció de col·lisió específica entre el jugador i la bandera.
- Mantenir el collider de la bandera habilitat per permetre la interacció amb el terra.

**Non-Goals:**
- No es modificarà el mètode `AgafarBandera` (només la versió automàtica que el crida).

## Decisions

- **Substitució completa del mètode**: S'utilitzarà el codi exacte proporcionat per l'usuari per evitar errors de lògica:
  ```csharp
  private void AgafarBanderaAutomàticament(GameObject objBandera) { 
      Collider2D colB = objBandera.GetComponent<Collider2D>(); 
      if (colB != null) { 
          Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colB, true); 
      } 
      AgafarBandera(objBandera.transform); 
  }
  ```

## Risks / Trade-offs

- **[Risc] Ignorar col·lisions múltiples** → **Mitigació**: L'ús del tercer paràmetre `true` a `IgnoreCollision` assegura que la col·lisió s'ignora de manera persistent fins que es digui el contrari.

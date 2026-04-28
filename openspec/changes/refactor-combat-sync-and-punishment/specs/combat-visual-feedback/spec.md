## ADDED Requirements

### Requirement: Animación de Daño Crítico
El sistema SHALL proporcionar feedback visual inmediato cuando un jugador pierde un combate.

#### Scenario: Aplicación de derrota
- **WHEN** un jugador entra en el flujo de `ProcesarDerrota`
- **THEN** el sistema SHALL disparar el trigger "Hurt" en el componente `Animator` antes de aplicar el knockback.

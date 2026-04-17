## ADDED Requirements

### Requirement: Alçada Màxima per al Desplegable
Els components DropdownField HAURIEN de tenir una alçada màxima definida per als seus contenidors per evitar que es tallin quan hi ha moltes opcions.

#### Scenario: Aplicació de l'estil al contenidor inner
- **WHEN** un component DropdownField es desplega al MenuUI.
- **THEN** el seu contenidor `unity-base-dropdown__container-inner` HA DE tenir un `max-height` de `200px`.

## Why

Actualmente, `CyborgIA` utiliza `OnCollisionEnter2D`, lo que requiere colisiones físicas sólidas para detectar al dinosaurio y la base. Para permitir el uso de objetos cinemáticos o con colisionadores de tipo Trigger (que no bloquean el movimiento pero sí disparan eventos), es necesario implementar `OnTriggerEnter2D`.

## What Changes

- Implementación del método `OnTriggerEnter2D(Collider2D col)`.
- Replicación de la lógica de recolección de dinosaurio y entrega en base dentro de los eventos de Trigger.
- Mantenimiento de la compatibilidad con el flujo de trabajo de ML-Agents (recompensas y fin de episodio).

## Capabilities

### New Capabilities
- `cyborg-trigger-detection`: Capacidad del agente para interactuar con objetivos y bases utilizando colisionadores de tipo Trigger.

### Modified Capabilities
<!-- No se modifican requisitos de capacidades existentes -->

## Impact

- Script `CyborgIA.cs`.
- Flexibilidad en la configuración de los prefabs de dinosaurio y base en Unity (pueden ser Triggers).

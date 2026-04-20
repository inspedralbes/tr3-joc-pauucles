## Context

El agente CyborgIA debe interactuar con dinosaurios y una base roja ("BaseRoja"). El uso de referencias estáticas no es escalable para escenas de entrenamiento dinámicas. Se implementará una búsqueda por tags en cada inicio de episodio.

## Goals / Non-Goals

**Goals:**
- Implementar búsqueda dinámica usando tags "Dinosaurio" y "BaseRoja".
- Asegurar que el agente siempre seleccione el objetivo más cercano.
- Prevenir errores de referencia nula en la colección de observaciones.

**Non-Goals:**
- No se optimizará la búsqueda para cientos de objetos en tiempo real (solo al inicio del episodio).
- No se cambiarán las recompensas de colisión.

## Decisions

- **Búsqueda por Tag:** Se utilizará `GameObject.FindGameObjectsWithTag` para "Dinosaurio" y "BaseRoja".
- **Criterio de Proximidad:** Se iterará sobre los objetos encontrados comparando las distancias calculadas con `Vector2.Distance`.
- **Visibilidad:** Mantener `targetDinosaurio` y `baseDestino` como `private` para forzar el uso del sistema de descubrimiento dinámico.
- **Manejo de Nulos:** En `CollectObservations`, si alguna referencia es nula, se añadirá `Vector3.zero` y se detendrá la ejecución del método para mantener la consistencia del sensor sin errores.

## Risks / Trade-offs

- **[Riesgo] Tags inexistentes:** Si los tags "Dinosaurio" o "BaseRoja" no están definidos en Unity, el script lanzará un error.
  - **Mitigación:** Asegurarse de que los tags estén creados en el editor de Unity antes de ejecutar la escena.
- **[Riesgo] Ausencia de objetivos:** Si no hay objetos con esos tags, el agente no recibirá observaciones útiles.
  - **Mitigación:** La comprobación de nulidad en las observaciones previene el crash, pero el agente no aprenderá correctamente.

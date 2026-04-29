## 1. Actualización de Variables

- [x] 1.1 Añadir `public Transform[] spawnPoints` a `DroneAI.cs`.
- [x] 1.2 Añadir una referencia `public Transform jugadorObjetivo` para poder teletransportarlo si no existe ya una clara (usar la que ya tiene el script si es posible).

## 2. Refactorización de OnEpisodeBegin

- [x] 2.1 Implementar la selección de un `spawnPoint` aleatorio del array.
- [x] 2.2 Implementar la generación del número aleatorio (0 o 1) para decidir el estado inicial.
- [x] 2.3 Implementar la lógica para el caso 0 (Simular 'Robado'): teletransportar jugador y vincular dinosaurio.
- [x] 2.4 Implementar la lógica para el caso 1 (Simular 'Tirado'): desvincular dinosaurio y teletransportar solo dinosaurio.
- [x] 2.5 Asegurar que el Rigidbody del dinosaurio y del jugador tengan velocidad cero tras el teletransporte para evitar inestabilidad.
- [x] 2.6 Forzar el reseteo de la posición del dron a su base original (`initialPosition`).

## 3. Validación

- [x] 3.1 Verificar en el Inspector de Unity que el array `spawnPoints` aparece y permite asignar Transforms.
- [x] 3.2 Probar en modo Heurístico o Play que al inicio de cada episodio el dinosaurio aparece en lugares distintos y en estados distintos.

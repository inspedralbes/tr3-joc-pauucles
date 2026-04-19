## 1. Simplificació del Spawn al GameManager (Unity)

- [x] 1.1 Crear el mètode `private IEnumerator SpawnAmbRetard()`.
- [x] 1.2 Implementar l'espera de 0.5 segons i el log d'intent d'instanciació.
- [x] 1.3 Substituir l'inici de la corrutina `EsperarDadesISpawn` per `SpawnAmbRetard` al mètode `Start()`.

## 2. Correcció d'Escala de Banderes (Unity)

- [x] 2.1 Modificar `InstanciarBanderes()` per assignar `localScale = new Vector3(4f, 4f, 1f)` a cada dinosaure instanciat.

## 3. Sincronització del Nametag (Unity)

- [x] 3.1 Actualitzar `ConfigurarLocalPlayerVisuals()` per buscar el component `UnityEngine.UI.Text` als fills del `localPlayer`.
- [x] 3.2 Assignar `MenuManager.Instance.userId` al text del Nametag trobat.
- [x] 3.3 Afegir un `Debug.LogWarning` si el component de text no es troba.

## 4. Verificació

- [x] 4.1 Comprovar que les banderes apareixen sempre i amb la mida correcta (4x).
- [x] 4.2 Verificar que el nom d'usuari correcte es mostra al Nametag del propi jugador.

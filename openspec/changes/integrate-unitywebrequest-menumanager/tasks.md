## 1. Environment Setup

- [x] 1.1 Add `using UnityEngine.Networking;` to `MenuManager.cs`
- [x] 1.2 Define private `baseUrl` field in `MenuManager.cs`

## 2. Data Structures

- [x] 2.1 Define serializable `AuthData` class within `MenuManager.cs`

## 3. Core Implementation

- [x] 3.1 Implement `RegistrarUsuari` method using `AuthData` and `JsonUtility`
- [x] 3.2 Implement `FerLogin` method using `AuthData` and `JsonUtility`
- [x] 3.3 Create `EnviarPeticio` coroutine using `UnityWebRequest` and `UploadHandlerRaw`
- [x] 3.4 Add success and error feedback through `Debug.Log` and `Debug.LogError`

## 1. Cleanup and Namespaces

- [x] 1.1 Add `using UnityEngine.UIElements;` to `MenuManager.cs`
- [x] 1.2 Remove `using TMPro;` and all `TMP_InputField` references

## 2. Initialization Refactor

- [x] 2.1 Implement `void OnEnable()` method
- [x] 2.2 Get root visual element: `var root = GetComponent<UIDocument>().rootVisualElement;`

## 3. Element Retrieval and Binding

- [x] 3.1 Query `inputNomJugador` and `inputPassword` text fields
- [x] 3.2 Query `btnRegistre` and `btnLogin` buttons
- [x] 3.3 Bind `btnRegistre.clicked` to `RegistrarUsuari` with lambda
- [x] 3.4 Bind `btnLogin.clicked` to `FerLogin` with lambda

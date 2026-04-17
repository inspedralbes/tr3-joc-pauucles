## 1. UI Reference Setup

- [x] 1.1 Declare private `VisualElement pantallaLogin;` and `pantallaLobby;` in `MenuManager` class
- [x] 1.2 Query and assign `pantallaLogin` and `pantallaLobby` in `OnEnable()`

## 2. Transition Logic Implementation

- [x] 2.1 Modify `EnviarPeticio` to include a check for `endpoint == "/login"` on success
- [x] 2.2 Add code to set `pantallaLogin.style.display = DisplayStyle.None;`
- [x] 2.3 Add code to set `pantallaLobby.style.display = DisplayStyle.Flex;`

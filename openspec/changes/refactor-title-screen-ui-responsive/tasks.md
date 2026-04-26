## 1. Structural Refactor in MenuUI.uxml

- [x] 1.1 Update `#PantallaTitol` style to use `width: 100%; height: 100%; justify-content: center; align-items: center;`.
- [x] 1.2 Create `#CapsaMaquina` VisualElement inside `#PantallaTitol` with attributes `name="CapsaMaquina"` and style `width: 800px; height: 600px; align-items: center; -unity-background-scale-mode: scale-to-fit;`.
- [x] 1.3 Move the existing title Label into `#CapsaMaquina`.
- [x] 1.4 Create `#GrupBotons` VisualElement inside `#CapsaMaquina` with style `align-items: center; margin-top: 25%;`.
- [x] 1.5 Move `btnStartGame` and `btnExitGame` inside `#GrupBotons`.

## 2. Styling and Cleanup

- [x] 2.1 Remove `position: absolute`, `bottom`, `top`, `left`, `right` from Title Label.
- [x] 2.2 Update Title Label style with `margin-top: 15%;` and `-unity-text-align: middle-center;`.
- [x] 2.3 Remove `position: absolute`, `top`, `left` and other coordinate-based styles from `btnStartGame` and `btnExitGame`.
- [x] 2.4 Update button styles to include `background-color: transparent; border-width: 0px;`.
- [x] 2.5 Ensure the background image previously on `#PantallaTitol` is handled correctly (either kept there or moved if visually appropriate).

## 3. Verification

- [x] 3.1 Verify the layout centers correctly when resizing the Game view in Unity.
- [x] 3.2 Confirm `#CapsaMaquina` maintains its 800x600 logical size during scaling.
- [x] 3.3 Check that other UI screens (Login, Lobby) in the same UXML remain unaffected.

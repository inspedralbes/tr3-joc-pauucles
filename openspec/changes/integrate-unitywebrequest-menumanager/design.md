## Context

The Unity game client needs a way to register and authenticate users by communicating with a Node.js/Express backend. Currently, the `MenuManager` handles UI transitions but lacks networking capabilities. This design introduces `UnityWebRequest` to handle asynchronous communication with the backend.

## Goals / Non-Goals

**Goals:**
- Implement `UnityWebRequest` for POST requests in `MenuManager.cs`.
- Define a serializable data structure for authentication payloads.
- Provide clear console feedback for the result of network operations.

**Non-Goals:**
- Implementation of a persistent session token management (JWT) in this phase.
- UI error messages displayed to the player (this phase focuses on developer logs).

## Decisions

- **AuthData Class**: A simple `[System.Serializable]` class will be used to ensure `JsonUtility.ToJson` correctly formats the payload for the backend.
- **Coroutine-based Networking**: `IEnumerator EnviarPeticio` will be used to avoid blocking the main Unity thread during network operations.
- **JSON Serialization**: `JsonUtility` is chosen for its simplicity and built-in support in Unity, as the payload structure is straightforward.

## Risks / Trade-offs

- **Security Risk**: Sending passwords in plain text over HTTP (localhost). **Mitigation**: This is acceptable for local development; HTTPS should be used for production.
- **Single Point of Failure**: All auth logic is currently tied to `MenuManager`. **Mitigation**: If auth logic grows, it should be moved to a dedicated `AuthService` or `NetworkManager`.

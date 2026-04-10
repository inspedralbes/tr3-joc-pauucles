## Context

The `Player` script manages flag-related interactions. Currently, the `banderaAgafada` transform is marked as `private`, preventing external access and visibility in the Unity Inspector unless using Debug mode.

## Goals / Non-Goals

**Goals:**
- Change the visibility of `banderaAgafada` from `private` to `public`.
- Ensure the variable is accessible from other scripts.

**Non-Goals:**
- Do not modify any logic related to how the flag is picked up or dropped.
- Do not change any other variables or methods in `Player.cs`.

## Decisions

- **Direct Visibility Change**: The simplest and most direct way to satisfy the requirement is to change the access modifier to `public`.

## Risks / Trade-offs

- **Risk**: The variable can now be modified by any script, which might lead to unexpected behavior if not handled carefully.
- **Mitigation**: Documentation of its intended use and keeping logic centralized in `Player.cs` where possible.

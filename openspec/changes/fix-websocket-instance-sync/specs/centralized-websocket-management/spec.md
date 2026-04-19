## ADDED Requirements

### Requirement: Persistència del MenuManager
El `MenuManager` SHALL persistir a través dels canvis d'escena per mantenir la connexió WebSocket activa.

#### Scenario: Canvi d'escena al Bosque
- **WHEN** El joc carrega l'escena "Bosque" des de l'escena inicial.
- **THEN** L'objecte que conté el `MenuManager` NO s'ha de destruir.
- **THEN** La connexió WebSocket SHALL romandre oberta i funcional.

### Requirement: Accés Global al WebSocket
El `MenuManager` SHALL proporcionar un punt d'accés global (Singleton) al seu objecte `WebSocket`.

#### Scenario: Accés des d'altres scripts
- **WHEN** Un script extern (ex: `NetworkSync`) necessita enviar dades.
- **THEN** Pot utilitzar `MenuManager.Instance.websocket.SendText()` per realitzar l'operació.

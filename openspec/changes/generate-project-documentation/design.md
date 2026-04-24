## Context

El projecte ha evolucionat cap a una arquitectura de microserveis i utilitza el patró Repository per a la capa de dades. No obstant, aquesta estructura no està documentada formalment per als usuaris finals o nous col·laboradors. Es requereix una estructura de fitxers Markdown clara a l'arrel del projecte per complir amb els estàndards de lliurament.

## Goals / Non-Goals

**Goals:**
- Proporcionar una documentació accessible i estructurada en català.
- Explicar clarament com posar en marxa el sistema des de zero.
- Documentar el patró Repository amb exemples de codi concrets del projecte.

**Non-Goals:**
- Crear una wiki externa o documentació en format HTML/PDF (es mantindrà en Markdown).
- Documentar tota la lògica de negoci del frontend (Unity).
- Canviar el codi font durant aquest procés de documentació.

## Decisions

### 1. Ubicació de la Documentació
- **Decisió**: Els fitxers principals (`README.md`, `MANUAL_INSTALACIO.md`, `PATTERN_REPOSITORY.md`) se situaran a l'arrel del projecte.
- **Racional**: És la ubicació estàndard que els desenvolupadors esperen trobar en clonar un repositori.

### 2. Estructura del Manual d'Instal·lació
- **Decisió**: Dividir el manual per components (Base de dades, Backend, Proxy).
- **Racional**: Facilita el diagnòstic de problemes durant la instal·lació.

### 3. Documentació del Patró Repository
- **Decisió**: Utilitzar `UserRepositoryMongo` i `UserRepositoryInMemory` com a exemples principals.
- **Racional**: Són els repositoris més senzills d'entendre i mostren clarament la substitució d'implementacions.

## Risks / Trade-offs

- **[Risc] Desactualització de la documentació** → **Mitigació**: Vincular els exemples de codi a rutes reals del repositori.
- **[Risc] Ambigüitat en la configuració d'Nginx** → **Mitigació**: Proporcionar fragments del fitxer `nginx_default.conf` real utilitzat al projecte.

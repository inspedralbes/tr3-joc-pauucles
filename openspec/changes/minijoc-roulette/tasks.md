## 1. Actualització de MinijocUIManager.cs

- [x] 1.1 Modificar el mètode `ShowUI` per rebre l'ID del minijoc o fer la selecció aleatòria directament.
- [x] 1.2 Implementar la selecció aleatòria d'un sencer entre 1 i 6 mitjançant `Random.Range(1, 7)`.
- [x] 1.3 Crear una estructura `switch` basada en l'ID seleccionat per gestionar el flux del combat.
- [x] 1.4 Refactoritzar la inicialització de PPTLLS perquè només s'activi si ha sortit el cas 1.

## 2. Implementació de Fallback per a altres minijocs

- [x] 2.1 Afegir una llista o diccionari amb els noms dels minijocs per als logs de depuració (PPTLLS, AturaBarra, CablePelat, ParellsSenars, PolsimForca, AcaparamentMirades).
- [x] 2.2 En els casos 2-6 del switch, implementar un `Debug.Log` amb el nom del minijoc.
- [x] 2.3 Per als casos 2-6, cridar a la lògica de tancament de la UI i restaurar `potMoure = true` immediatament, considerant el resultat com a `Empat`.

## 3. Validació

- [x] 3.1 Provar les col·lisions vàries vegades i verificar que els logs de la consola mostren minijocs aleatoris.
- [x] 3.2 Confirmar que quan surt PPTLLS (ID 1), la UI de botons és interactiva i funcional com abans.
- [x] 3.3 Verificar que quan surten els altres IDs (2-6), la UI es tanca correctament i els jugadors poden tornar a moure's sense bloquejos.

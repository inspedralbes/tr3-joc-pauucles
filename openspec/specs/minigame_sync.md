# Especificació: Sincronització de Minijocs en Temps Real

## 1. Descripció del Comportament
El sistema ha de garantir que quan dos jugadors col·lisionen, s'iniciï exactament el mateix minijoc en ambdós clients i que les accions realitzades dins del minijoc es reflecteixin en temps real en l'altre client mitjançant WebSockets. El minijoc "Cable Pelat" ha de ser exclòs de la rotació.

## 2. Flux de Sincronització
1. **Detecció de Col·lisió**: El jugador local detecta col·lisió amb un enemic.
2. **Senyal d'Inici**: S'envia un missatge `MINIJOC_START` al servidor amb:
   - `gameIndex`: Índex aleatori del joc (1-6, excloent 4).
   - `p1`, `p2`: Noms dels usuaris implicats.
3. **Broadcasting**: El servidor retransmet el missatge a tots els clients de la sala.
4. **Activació del Minijoc**: Els clients implicats activen la UI del minijoc corresponent.
5. **Comunicació Durant el Joc**: S'utilitzen missatges `MINIJOC_UPDATE` per a pituacions i accions.
6. **Resultat Final**: S'envia `MINIJOC_RESULT` per indicar qui ha guanyat.

## 3. Minijocs Inclòs i Accions de Sincronització
- **PPTLLS (ID 1)**: Sincronitza l'elecció (`CHOICE:X`).
- **Parells o Senars (ID 2)**: Sincronitza els números generats inicialment pel client que inicia la col·lisió.
- **Atura la Barra (ID 3)**: Sincronitza la posició de la zona segura generada inicialment.
- **Polsim de Força (ID 5)**: Sincronitza cada clic realitzat (`CLICK`).
- **Acaparament de Mirades (ID 6)**: Sincronitza la direcció triada.

## 4. Restriccions
- El minijoc ID 4 (Cable Pelat) NO ha de ser seleccionat.
- Els jugadors han de quedar bloquejats (`potMoure = false`) durant el minijoc.
- El resultat del minijoc ha d'aplicar un stun al perdedor i invulnerabilitat temporal al guanyador.

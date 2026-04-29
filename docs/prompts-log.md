# Registre de Prompts - IA x Desenvolupar (OpenSpec)
**Feature escollida:** Minijoc "Pedra, Paper, Tisora, Llangardaix, Spock".

## Iteració 1: Definició dels Fonaments i Especificació (opsx:propose)
**Objectiu:** Generar els documents `foundations.md` i `spec.md` per delimitar el context i les regles matemàtiques del minijoc.

**Prompt enviat a la IA:**
> /opsx:propose 
> Necessito crear l'especificació d'OpenSpec per a un minijoc 2D a Unity.
> - Nom: Pedra, Paper, Tisora, Llangardaix, Spock.
> - Objectiu: Resoldre un empat quan dos jugadors xoquen.
> - Regles: Hi ha 10 regles de victòria clàssiques.
> Genera els fitxers foundations.md i spec.md en català tenint en compte que no puc modificar el servidor.

**Resultat obtingut:** La IA ha generat els fitxers amb el context i la matriu de resultats exacta. Cap desviació detectada.

## Iteració 2: Definició del Pla (opsx:propose plan)
**Objectiu:** Generar el document `plan.md` per estructurar com es programarà en C#.

**Prompt enviat a la IA:**
> /opsx:propose plan
> Basant-te en el spec.md de Llangardaix-Spock, genera el plan.md. 
> Fes que la lògica estigui en un script C# separat anomenat `MinijocSpockLogic` utilitzant `enums` per a les opcions i resultats, sense que sigui un MonoBehaviour. Així ho podrem cridar fàcilment.

**Resultat obtingut:** La IA ha creat correctament el `plan.md` establint els enums i l'estructura del mètode estàtic `AvaluarGuanyador`.

## Iteració 3: Implementació del codi (opsx:apply)
**Objectiu:** Generar l'script final `MinijocPPTLLS.cs` basant-nos en el pla.

**Prompt enviat a la IA:**
> /opsx:apply
> Executa el plan.md i crea l'script MinijocPPTLLS.cs. Assegura't de cobrir totes les regles del spec.md amb un switch/case eficient.

**Resultat obtingut:** La IA ha generat el codi correctament pel que fa a l'estructura (Enums i mètode estàtic).
**ERROR DETECTAT:** En revisar el codi generat, detecto una desviació respecte a l'especificació. Al `case OpcioMinijoc.Llangardaix:`, la IA ha programat que guanya contra `Tisora` i `Spock`. Això incompleix la Regla 6 (Tisora decapita Llangardaix) i la Regla 7 (Llangardaix es menja Paper). Ha confós el Paper amb la Tisora.

## Iteració 4: Correcció de l'error lògic (Refinament)
**Objectiu:** Corregir la condició de victòria del Llangardaix perquè compleixi amb el document `spec.md`.

**Prompt enviat a la IA:**
> T'has equivocat al `case OpcioMinijoc.Llangardaix:`. Has posat que guanya a `Tisora`, però segons la regla 6 i 7 del document d'especificació, el Llangardaix perd contra la Tisora i guanya al Paper. Corregeix el switch perquè el Llangardaix guanyi només a `Paper` i `Spock`.

**Resultat obtingut:** La IA ha reconegut l'error de lectura de les regles i ha proporcionat la línia de codi corregida: `if (j2 == OpcioMinijoc.Paper || j2 == OpcioMinijoc.Spock) return ResultatMinijoc.GuanyaJugador1;`. Codi validat i acceptat.

## Iteració 5: Disseny i Especificació de la resta de minijocs (opsx:propose)
**Objectiu:** Generar l'arquitectura i les regles formals per als 5 minijocs restants utilitzant Gemini CLI.

**Prompt enviat a la IA (via Terminal Gemini CLI):**
> /opsx:propose "Necessito crear la lògica per a 6 minijocs 2D. Tota la lògica s'ha d'executar al client Unity. Genera 6 scripts C# independents a la ruta 'Assets/Scripts/'. Cap d'ells ha de ser un MonoBehaviour. Minijocs: 1. Pedra-Paper-Tisora-Llangardaix-Spock (aquest ja el tenim documentat al plan.md, només fes l'script si no hi és), 2. Parells o Senars, 3. Acaparament de Mirades, 4. Polsim de Força, 5. Atura la Barra, 6. Cable Pelat."

**Resultat obtingut:** Èxit total. L'agent ha analitzat el codi existent i ha generat els artefactes `proposal.md`, `spec.md` i `design.md`. Ha establert les condicions de victòria matemàtiques de cada joc i ha pres la decisió arquitectònica de fer servir classes independents per millorar el testing.

## Iteració 6: Generació automàtica del codi (opsx:apply)
**Objectiu:** Que la IA llegeixi els documents de disseny generats i programi els 5 scripts C# pendents.

**Prompt enviat a la IA (via Terminal Gemini CLI):**
> /opsx:apply

**Resultat obtingut:** L'agent ha processat les 10 tasques del `tasks.md` i ha generat els 5 arxius `.cs` a la carpeta `Assets/Scripts/`. He verificat que cap d'ells hereta de `MonoBehaviour` i que tots utilitzen `enums` clars per als resultats, complint estrictament amb l'arquitectura definida.
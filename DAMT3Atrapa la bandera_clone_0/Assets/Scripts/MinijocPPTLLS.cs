using UnityEngine;

public enum OpcioMinijoc { Pedra, Paper, Tisora, Llangardaix, Spock }
public enum ResultatMinijoc { GuanyaJugador1, GuanyaJugador2, Empat }

public class MinijocPPTLLS
{
    public static ResultatMinijoc AvaluarGuanyador(OpcioMinijoc j1, OpcioMinijoc j2)
    {
        if (j1 == j2) return ResultatMinijoc.Empat;

        switch (j1)
        {
            case OpcioMinijoc.Pedra:
                if (j2 == OpcioMinijoc.Llangardaix || j2 == OpcioMinijoc.Tisora) return ResultatMinijoc.GuanyaJugador1;
                break;
            case OpcioMinijoc.Paper:
                if (j2 == OpcioMinijoc.Pedra || j2 == OpcioMinijoc.Spock) return ResultatMinijoc.GuanyaJugador1;
                break;
            case OpcioMinijoc.Tisora:
                if (j2 == OpcioMinijoc.Paper || j2 == OpcioMinijoc.Llangardaix) return ResultatMinijoc.GuanyaJugador1;
                break;
            case OpcioMinijoc.Llangardaix:
                if (j2 == OpcioMinijoc.Paper || j2 == OpcioMinijoc.Spock) return ResultatMinijoc.GuanyaJugador1;
                break;
            case OpcioMinijoc.Spock:
                if (j2 == OpcioMinijoc.Tisora || j2 == OpcioMinijoc.Pedra) return ResultatMinijoc.GuanyaJugador1;
                break;
        }

        return ResultatMinijoc.GuanyaJugador2;
    }
}
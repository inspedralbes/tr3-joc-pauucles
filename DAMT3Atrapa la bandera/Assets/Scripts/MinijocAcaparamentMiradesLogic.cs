public enum DireccioMirada { Up, Down, Left, Right }
public enum ResultatAcaparamentMirades { GuanyaAtrapador, GuanyaEvitador }

public class MinijocAcaparamentMiradesLogic
{
    public static ResultatAcaparamentMirades Avaluar(DireccioMirada atrapador, DireccioMirada evitador)
    {
        return (atrapador == evitador) ? ResultatAcaparamentMirades.GuanyaAtrapador : ResultatAcaparamentMirades.GuanyaEvitador;
    }
}

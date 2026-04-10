public enum ParellsSenarsCostat { Parells, Senars }
public enum ResultatParellsSenars { GuanyaJugador1, GuanyaJugador2 }

public class MinijocParellsSenarsLogic
{
    public static ResultatParellsSenars AvaluarGuanyador(ParellsSenarsCostat costatJ1, int ditsJ1, int ditsJ2)
    {
        int suma = ditsJ1 + ditsJ2;
        bool esParell = (suma % 2 == 0);

        if (costatJ1 == ParellsSenarsCostat.Parells)
        {
            return esParell ? ResultatParellsSenars.GuanyaJugador1 : ResultatParellsSenars.GuanyaJugador2;
        }
        else
        {
            return !esParell ? ResultatParellsSenars.GuanyaJugador1 : ResultatParellsSenars.GuanyaJugador2;
        }
    }
}

public enum ResultatAturaBarra { Perfect, Good, Miss }

public class MinijocAturaBarraLogic
{
    public static ResultatAturaBarra AvaluarAturada(float posicioAturada, float centreObjectiu, float margePerfect, float margeGood)
    {
        float diferencia = System.Math.Abs(posicioAturada - centreObjectiu);

        if (diferencia <= margePerfect)
        {
            return ResultatAturaBarra.Perfect;
        }
        else if (diferencia <= margeGood)
        {
            return ResultatAturaBarra.Good;
        }
        else
        {
            return ResultatAturaBarra.Miss;
        }
    }
}

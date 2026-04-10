public enum ResultatCablePelat { Success, Early, Late }

public class MinijocCablePelatLogic
{
    public static ResultatCablePelat AvaluarReflex(float tempsClick, float iniciFinestra, float fiFinestra)
    {
        if (tempsClick < iniciFinestra)
        {
            return ResultatCablePelat.Early;
        }
        else if (tempsClick > fiFinestra)
        {
            return ResultatCablePelat.Late;
        }
        else
        {
            return ResultatCablePelat.Success;
        }
    }
}

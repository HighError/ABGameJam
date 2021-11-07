[System.Serializable]
public class City
{
    public string Name;
    public Enums.CityDebafs Debaf;

    public string GetDebafInfo()
    {
        switch (Debaf)
        {
            case Enums.CityDebafs.None:
                return "-";
            case Enums.CityDebafs.SuccessChanceMinus15:
                return "Шанс успіху всіх місій зменшено на 15%";
            case Enums.CityDebafs.SuccessChanceMinus10:
                return "Шанс успіху всіх місій зменшено на 10%";
            case Enums.CityDebafs.StartLoseProc:
                return "Цьому місту відомо про ваші злодіяння\nРівень занепокоєння на старті = 10%";
            case Enums.CityDebafs.NoNewHacker:
                return "Вам не дається додатковий слот для хакера";
            default:
                return "";
        }
    }
}

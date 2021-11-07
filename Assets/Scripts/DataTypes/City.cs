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
                return "���� ����� ��� ��� �������� �� 15%";
            case Enums.CityDebafs.SuccessChanceMinus10:
                return "���� ����� ��� ��� �������� �� 10%";
            case Enums.CityDebafs.StartLoseProc:
                return "����� ���� ����� ��� ���� ��������\nг���� ����������� �� ����� = 10%";
            case Enums.CityDebafs.NoNewHacker:
                return "��� �� ������ ���������� ���� ��� ������";
            default:
                return "";
        }
    }
}

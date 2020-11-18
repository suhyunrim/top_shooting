using System.Collections.Generic;
using System.Linq;

public class EnemyData : GameData<EnemyData>
{
    public string Key;
    public int Hp;
    public int Score;
    public string ImageName;

    public static void LoadData(string fileName)
    {
        LoadData(fileName, elem => elem.Key);
    }
}
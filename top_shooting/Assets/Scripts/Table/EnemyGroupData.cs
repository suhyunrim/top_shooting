using System.Collections.Generic;
using System.Linq;

public class EnemyGroupData : GameData<EnemyGroupData>
{
    public string Key;
    public int MinEnemyKey;
    public int MaxEnemyKey;
    public float Speed;

    public static void LoadData(string fileName)
    {
        LoadData(fileName, elem => elem.Key);
    }
}
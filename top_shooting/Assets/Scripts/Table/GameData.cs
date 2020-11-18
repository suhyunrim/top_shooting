using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class GameData<T>
    where T : class, new()
{
    static GameData()
    {
        new T();
    }

    protected static DataHolder<T> data;

    public static T[] All
    {
        get { return data.All; }
    }

    public static T Get(int id)
    {
        return data[id];
    }

    public static T Get(string id)
    {
        var ret = data[id];
        if (ret == null)
            Debug.LogError($"{id} is not exist in {data.Filename} table.");

        return data[id];
    }

    protected static void LoadData(T[] array, Func<T, string> idGetter)
    {
        data = DataHolder<T>.Create(array, idGetter);
    }

    protected static void LoadData(string fileName, Func<T, string> idGetter)
    {
        data = DataHolder<T>.Create(fileName, idGetter);
    }
}
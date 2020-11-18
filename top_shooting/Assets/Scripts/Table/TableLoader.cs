using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class TableLoader
{
    public static readonly List<(Type, string)> ClientDataFiles = new List<(Type, string)>
        {
            (typeof(EnemyData), "EnemyData"),
            (typeof(EnemyGroupData), "EnemyGroupData"),
        };

    public static void LoadAllData()
    {
        foreach (var pair in ClientDataFiles)
        {
            Type type = pair.Item1;
            string filename = pair.Item2;

            if (type == null)
                continue;

            var method = type.GetMethod("LoadData", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(string) }, null);
            if (method == null)
                throw new InvalidOperationException($"Can't find {type.Name}::LoadData(string).");

            method.Invoke(null, new[] { filename });

            Debug.Log($"{type.Name} table is loaded.");
        }
    }
}
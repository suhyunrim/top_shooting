using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI<T> : Singleton<T> where T : Component
{
    private readonly string UIParsingSeparator = ":";

    protected Dictionary<string, GameObject> Vars;

    protected override void Awake()
    {
        base.Awake();

        Vars = new Dictionary<string, GameObject>();

        foreach (var child in transform.GetComponentsInChildren<Transform>(true))
        {
            if (child.name.StartsWith(UIParsingSeparator))
            {
                Vars.Add(child.name.Substring(1), child.gameObject);
            }
        }
    }
}
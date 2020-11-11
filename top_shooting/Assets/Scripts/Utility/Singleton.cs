using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var foundObject = FindObjectsOfType(typeof(T)) as T[];
                if (foundObject.Length >= 2)
                {
                    foreach (var found in foundObject)
                        Debug.LogError($"gameObject name: {found.name}");

                    throw new System.Exception($"{typeof(T)} is duplicated.");
                }

                if (foundObject.Length > 0)
                {
                    instance = foundObject[0];
                }

                if (instance == null)
                {
                    var newGameObject = new GameObject(typeof(T).ToString());
                    instance = newGameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var foundObject = FindObjectOfType(typeof(T)) as T;
                if (foundObject != null)
                {
                    instance = foundObject;
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
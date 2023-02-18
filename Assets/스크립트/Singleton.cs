using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    GameObject T_temp = new GameObject(typeof(T).Name, typeof(T));
                    instance = T_temp.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != this)
            Destroy(gameObject);
    }
}
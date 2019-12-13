using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneRegistrator : MonoBehaviour
{
    private static SceneRegistrator _current;
    public static SceneRegistrator Current
    {
        get
        {
            if (_current == null)
                _current = FindObjectOfType<SceneRegistrator>();
            return _current;
        }
    }

    [Header("Registered static objects on this scene (Access by type):")]

    [SerializeField] private List<MonoBehaviour> registeredObjects = new List<MonoBehaviour>();


    public bool GetObject<T>(out T returnObj) where T : MonoBehaviour
    {
        returnObj = default;

        foreach (MonoBehaviour obj in registeredObjects)
            if (obj is T)
            {
                returnObj = (T)obj;
                return true;
            }

        return false;
    }


}

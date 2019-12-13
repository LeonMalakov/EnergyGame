using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnergyGame
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        private static object _lock = new object();

        private static bool isAppQuitting;

        public static T Instance
        {
            get
            {
                if (isAppQuitting)
                    return null;

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            GameObject _instanceObject = new GameObject("[SINGLETON]" + typeof(T).ToString());
                            _instance = _instanceObject.AddComponent<T>();
                            DontDestroyOnLoad(_instanceObject);
                        }
                    }

                    return _instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            isAppQuitting = true;
        }
    }
}

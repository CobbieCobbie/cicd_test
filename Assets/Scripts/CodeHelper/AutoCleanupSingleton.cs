using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A singleton base class for the use of singletons which are cleaned up with
/// every new instance and should therefore be safe if they are e.g. used in 
/// multiple following scenes.
/// 
/// Created by Mathias Schlenker - zumschlenker.de
/// Part of the Codevember.org Team
/// </summary>
public class AutoCleanupSingleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null) {
                    _instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // The following code prevents duplicates and makes sure that every instance in a scene is the correct one
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
    }
}

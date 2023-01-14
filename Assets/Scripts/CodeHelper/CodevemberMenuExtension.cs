using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CodevemberMenuExtension : MonoBehaviour
{

    [MenuItem("Codevember/Do Something")]
    static void DoSomething() {
        Debug.Log("Doing something");
    }

    [ContextMenu("Codevember/Do Something else")]
    static void DoSomethingInContext()
    {
        Debug.Log("Doing something in context");
    }

}

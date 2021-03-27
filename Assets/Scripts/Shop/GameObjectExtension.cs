using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension
{
    public static void KillAllChild(this GameObject go)
    {
        foreach (Transform t in go.transform)
        {
            UnityEngine.Component.Destroy(t.gameObject);
        }
    }
}

using UnityEngine;

public static class Extention
{
    public static T FindComponent<T>(this GameObject gameObject, string name) where T : Component
    {
        return Utility.FindComponent<T>(gameObject, name);
    }
}
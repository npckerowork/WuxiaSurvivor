using UnityEngine;

public class Scene_Main : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GameManager.Instance.Spawning());
    }
}
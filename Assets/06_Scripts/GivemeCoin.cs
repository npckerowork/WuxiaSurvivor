using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivemeCoin : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            DataManager.Instance.Coin.Add(10000);
        }
    }
}

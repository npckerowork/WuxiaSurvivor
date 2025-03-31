using Newtonsoft.Json;
using System;
using UnityEngine;

public class Coin
{
    public long Current
    {
        get => current;
        set
        {
            current = value;
            OnUpdateCoinAmountEvent?.Invoke(current);
        }
    }

    [JsonProperty]
    private long current;

    public Action<long> OnUpdateCoinAmountEvent = delegate { }; //코인량이 업데이트 될때마다 호출되는 이벤트

    //추가
    public void Add(long amount)
    {
        if (amount <= 0)
        {
            Debug.Log("추가할려는 코인량이 0이거나 음수입니다");
            return;
        }
        Current += amount;
    }

    //사용
    public void Use(long amount)
    {
        if (amount <= 0)
        {
            Debug.Log("사용하려는 코인량이 0이거나 음수입니다");
            return;
        }

        if (!IsCanUse(amount))
        {
            Debug.Log("코인 부족");
            return;
        }
        Current -= amount;
    }

    //코인 사용 가능한지
    public bool IsCanUse(float amount)
    {
        return Current - amount >= 0;
    }
}

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    ExpRatio,
    CoinRatio,
    MoveSpeed,
    Damage
}

public class UpgradeData
{
    public UpgradeScriptable[] upgradeDatas { get; private set; }

    public int[] upgradeLevels; // 업그레이드 레벨
    public int[] upgradePrice;  // 업그레이드 가격
    public float[] upgradeValues; // 업그레이드 수치

    public UpgradeData()
    {
        int datalength = Enum.GetValues(typeof(UpgradeType)).Length;

        // 기본 데이터 캐싱
        upgradeDatas = new UpgradeScriptable[datalength];
        foreach(UpgradeType type in Enum.GetValues(typeof(UpgradeType)))
        {
            upgradeDatas[(int)type] = 
                Resources.Load<UpgradeScriptable>($"UpgradeData/{type.ToString()}");
        }

        foreach (UpgradeScriptable a in upgradeDatas)
        {
            Debug.Log(a.ToString());    
        }

        // 업그레이드 데이터 초기화
        upgradeLevels = new int[datalength];
        upgradePrice = new int[datalength];
        upgradeValues = new float[datalength];
        foreach (UpgradeScriptable data in upgradeDatas)
        {
            upgradePrice[(int)data.type] = data.price;
            upgradeValues[(int)data.type] = data.value;
        }
    }
}
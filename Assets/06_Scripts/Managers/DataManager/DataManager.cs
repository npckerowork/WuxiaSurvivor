using Newtonsoft.Json;
using UnityEngine;

public class DataManager
{
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataManager();
            }
            return instance;
        }
    }

    private static DataManager instance = null;
    private bool isLoaded = false;

    private DataManager()
    {
        LoadData();
    }

    //저장할 데이터---------------------------
    public Coin Coin = new();
    public UpgradeData UpgradeData = new();
    //-------------------------------------

    //데이터 저장
    public void SaveData()
    {
        string json = JsonConvert.SerializeObject(instance);
        PlayerPrefs.SetString(Define.SAVEDATA_KEY, json);
        PlayerPrefs.Save();
    }

    //데이터 불러오기
    public void LoadData()
    {
        if (!isLoaded) return;
        if (!PlayerPrefs.HasKey(Define.SAVEDATA_KEY)) return; //저장키가 없다면
        isLoaded = true;
        string json = PlayerPrefs.GetString(Define.SAVEDATA_KEY);
        var saveData = JsonConvert.DeserializeObject<DataManager>(json);
        JsonConvert.PopulateObject(json, this); // 싱글톤 인스턴스에 값만 덮어씀
    }
}


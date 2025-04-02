using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerData : EntityData
{
    public void ApplyUpgrade()
    {
        MaxHP *= DataManager.Instance.UpgradeData[UpgradeType.HP];
        MoveSpeed *= DataManager.Instance.UpgradeData[UpgradeType.MoveSpeed];
    }
}
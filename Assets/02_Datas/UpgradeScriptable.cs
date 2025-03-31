using UnityEngine;

[CreateAssetMenu(fileName = "newUpgradeType", menuName = "Upgrade/Data")]
public class UpgradeScriptable : ScriptableObject
{
    public UpgradeType type;      // 업그레이드 타입
    public Sprite sprite;         // 업그레이드 이미지
    public int price;             // 기본 가격
    public float value;           // 기본 수치
    public float priceRatio;      // 가격 상승 배율
    public float valueRatio;      // 수치 상승 배율
}
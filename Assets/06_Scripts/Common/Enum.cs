public enum TileType
{
    Ground, //땅
    Grass, //풀
    Item, //아이템
    Gimmick //함정
}

#region Audio Enums
public enum VolumeType
{
    Master,
    Bgm,
    Sfx
}

public enum BgmName
{
    LobbyBGM,
    GameBGM,
}

public enum SfxName
{
    ButtonClick,
    GetItem,
    TaskDone,
    LevelUp,
    Victory,
    Lose,
    Fight1,
    Fight2,
    Fight3
}
#endregion

public enum UIType
{
    Lobby,
    Upgrade,
    Option,
    Ingame,
    Pause,
    SkillSelect,
    Result
}

public enum UpgradeType
{
    ExpRatio,
    CoinRatio,
    MoveSpeed,
    Damage,
    HP,
    Magnet
}

public enum EffectType
{
    SparkBlue,
    SparkYellow,
    SparkPurple,
    SparkColorful,
    SparkBlueStar,
    SparkYellowStar,
    Heart,
    SparkHeart,
}

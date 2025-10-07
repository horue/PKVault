using System;
using System.Reflection;
using PKHeX.Core;

class PKMDto
{
    public int SIZE_PARTY { get; set; }
    public int SIZE_STORED { get; set; }
    public string Extension { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
    public bool Valid { get; set; }
    public ushort Species { get; set; }
    public string Nickname { get; set; }
    public int HeldItem { get; set; }
    public byte Gender { get; set; }
    public string Nature { get; set; }
    public string StatNature { get; set; }
    public int Ability { get; set; }
    public byte CurrentFriendship { get; set; }
    public byte Form { get; set; }
    public bool IsEgg { get; set; }
    public bool IsNicknamed { get; set; }
    public uint EXP { get; set; }
    public ushort TID16 { get; set; }
    public ushort SID16 { get; set; }
    public string OriginalTrainerName { get; set; }
    public byte OriginalTrainerGender { get; set; }
    public byte Ball { get; set; }
    public byte MetLevel { get; set; }
    public uint TrainerTID7 { get; set; }
    public uint TrainerSID7 { get; set; }
    public uint DisplayTID { get; set; }
    public uint DisplaySID { get; set; }
    public uint PID { get; set; }
    public string Language { get; set; }
    public bool FatefulEncounter { get; set; }
    public uint TSV { get; set; }
    public uint PSV { get; set; }
    public int Characteristic { get; set; }
    public string MetLocation { get; set; }
    public string EggLocation { get; set; }
    public byte OriginalTrainerFriendship { get; set; }
    public bool Japanese { get; set; }
    public bool Korean { get; set; }
    public string MetDateString { get; set; }
    public string HandlingTrainerName { get; set; }
    public byte HandlingTrainerGender { get; set; }
    public byte HandlingTrainerFriendship { get; set; }
    public int AbilityNumber { get; set; }
    public string EggMetDateString { get; set; }
    public ushort RelearnMove1 { get; set; }
    public ushort RelearnMove2 { get; set; }
    public ushort RelearnMove3 { get; set; }
    public ushort RelearnMove4 { get; set; }
    public byte CurrentHandler { get; set; }
    public ushort MaxMoveID { get; set; }
    public ushort MaxSpeciesID { get; set; }
    public int MaxItemID { get; set; }
    public int MaxAbilityID { get; set; }
    public int MaxBallID { get; set; }
    public string MaxGameID { get; set; }
    public string MinGameID { get; set; }
    public int MaxIV { get; set; }
    public int MaxEV { get; set; }
    public int MaxStringLengthTrainer { get; set; }
    public int MaxStringLengthNickname { get; set; }
    public int TrashCharCountTrainer { get; set; }
    public int TrashCharCountNickname { get; set; }
    public int SpriteItem { get; set; }
    public bool IsShiny { get; set; }
    public ushort ShinyXor { get; set; }
    public ushort Move1 { get; set; }
    public ushort Move2 { get; set; }
    public ushort Move3 { get; set; }
    public ushort Move4 { get; set; }
    public int Move1_PP { get; set; }
    public int Move2_PP { get; set; }
    public int Move3_PP { get; set; }
    public int Move4_PP { get; set; }
    public int Move1_PPUps { get; set; }
    public int Move2_PPUps { get; set; }
    public int Move3_PPUps { get; set; }
    public int Move4_PPUps { get; set; }
    public string Version { get; set; }

    public PKMDto(PKM pkm)
    {
        SIZE_PARTY = pkm.SIZE_PARTY;
        SIZE_STORED = pkm.SIZE_STORED;
        Extension = pkm.Extension ?? string.Empty;
        PersonalInfo = pkm.PersonalInfo;

        var dtoProps = typeof(PKMDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var pkmProps = typeof(PKM).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var dtoProp in dtoProps)
        {
            if (!dtoProp.CanWrite)
                continue;

            var pkmProp = Array.Find(pkmProps, p => p.Name == dtoProp.Name && p.PropertyType == dtoProp.PropertyType);
            if (pkmProp == null || !pkmProp.CanRead)
                continue;

            object? value = pkmProp.GetValue(pkm);

            if (value == null && Nullable.GetUnderlyingType(dtoProp.PropertyType) == null && dtoProp.PropertyType.IsValueType)
            {
                value = Activator.CreateInstance(dtoProp.PropertyType);
            }

            if (dtoProp.PropertyType == typeof(string) && value == null)
            {
                value = string.Empty;
            }

            dtoProp.SetValue(this, value);
        }

        // Convertendo enums para string, pois no PKM eles são enums
        Nature = pkm.Nature.ToString();
        StatNature = pkm.StatNature.ToString();

        // Garantindo que strings nunca sejam nulas
        Nickname = pkm.Nickname ?? string.Empty;
        OriginalTrainerName = pkm.OriginalTrainerName ?? string.Empty;
        Language = pkm.Language.ToString();
        MetLocation = pkm.MetLocation.ToString();
        EggLocation = pkm.EggLocation.ToString();
        MetDateString = pkm.MetDate?.ToString("yyyy-MM-dd") ?? string.Empty;
        HandlingTrainerName = pkm.HandlingTrainerName ?? string.Empty;
        EggMetDateString = pkm.EggMetDate?.ToString("yyyy-MM-dd") ?? string.Empty;
        MaxGameID = pkm.MaxGameID.ToString();
        MinGameID = pkm.MinGameID.ToString();
        Version = pkm.Version.ToString();
    }
}

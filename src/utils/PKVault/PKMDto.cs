using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            Extension = pkm.Extension;
            PersonalInfo = pkm.PersonalInfo;
            Valid = pkm.Valid;
            Species = pkm.Species;
            Nickname = pkm.Nickname ?? string.Empty;
            HeldItem = pkm.HeldItem;
            Gender = pkm.Gender;
            Nature = pkm.Nature.ToString();
            StatNature = pkm.StatNature.ToString();
            Ability = pkm.Ability;
            CurrentFriendship = pkm.CurrentFriendship;
            Form = pkm.Form;
            IsEgg = pkm.IsEgg;
            IsNicknamed = pkm.IsNicknamed;
            EXP = pkm.EXP;
            TID16 = pkm.TID16;
            SID16 = pkm.SID16;
            OriginalTrainerName = pkm.OriginalTrainerName ?? string.Empty;
            OriginalTrainerGender = pkm.OriginalTrainerGender;
            Ball = pkm.Ball;
            MetLevel = pkm.MetLevel;
            TrainerTID7 = pkm.TrainerTID7;
            TrainerSID7 = pkm.TrainerSID7;
            DisplayTID = pkm.DisplayTID;
            DisplaySID = pkm.DisplaySID;
            PID = pkm.PID;
            Language = pkm.Language.ToString();
            FatefulEncounter = pkm.FatefulEncounter;
            TSV = pkm.TSV;
            PSV = pkm.PSV;
            Characteristic = pkm.Characteristic;
            MetLocation = pkm.MetLocation.ToString();
            EggLocation = pkm.EggLocation.ToString();
            OriginalTrainerFriendship = pkm.OriginalTrainerFriendship;
            Japanese = pkm.Japanese;
            Korean = pkm.Korean;
            MetDateString = pkm.MetDate?.ToString("yyyy-MM-dd") ?? string.Empty;
            HandlingTrainerName = pkm.HandlingTrainerName ?? string.Empty;
            HandlingTrainerGender = pkm.HandlingTrainerGender;
            HandlingTrainerFriendship = pkm.HandlingTrainerFriendship;
            AbilityNumber = pkm.AbilityNumber;
            EggMetDateString = pkm.EggMetDate?.ToString("yyyy-MM-dd") ?? string.Empty;
            RelearnMove1 = pkm.RelearnMove1;
            RelearnMove2 = pkm.RelearnMove2;
            RelearnMove3 = pkm.RelearnMove3;
            RelearnMove4 = pkm.RelearnMove4;
            CurrentHandler = pkm.CurrentHandler;
            MaxMoveID = pkm.MaxMoveID;
            MaxSpeciesID = pkm.MaxSpeciesID;
            MaxItemID = pkm.MaxItemID;
            MaxAbilityID = pkm.MaxAbilityID;
            MaxBallID = pkm.MaxBallID;
            MaxGameID = pkm.MaxGameID.ToString();
            MinGameID = pkm.MinGameID.ToString();
            MaxIV = pkm.MaxIV;
            MaxEV = pkm.MaxEV;
            MaxStringLengthTrainer = pkm.MaxStringLengthTrainer;
            MaxStringLengthNickname = pkm.MaxStringLengthNickname;
            TrashCharCountTrainer = pkm.TrashCharCountTrainer;
            TrashCharCountNickname = pkm.TrashCharCountNickname;
            SpriteItem = pkm.SpriteItem;
            IsShiny = pkm.IsShiny;
            ShinyXor = pkm.ShinyXor;
            Move1 = pkm.Move1;
            Move2 = pkm.Move2;
            Move3 = pkm.Move3;
            Move4 = pkm.Move4;
            Move1_PP = pkm.Move1_PP;
            Move2_PP = pkm.Move2_PP;
            Move3_PP = pkm.Move3_PP;
            Move4_PP = pkm.Move4_PP;
            Move1_PPUps = pkm.Move1_PPUps;
            Move2_PPUps = pkm.Move2_PPUps;
            Move3_PPUps = pkm.Move3_PPUps;
            Move4_PPUps = pkm.Move4_PPUps;
            Version = pkm.Version.ToString();
        }
    }

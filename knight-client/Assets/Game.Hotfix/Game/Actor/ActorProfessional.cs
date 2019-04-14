﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using Knight.Hotfix.Core;

namespace Game
{
    [HotfixSBGroup("GameConfig")]
    public partial class ActorProfessional : HotfixSerializerBinary
    {
        public int ID;
        public int HeroID;
        public string Name;
        public string Desc;
    }
}

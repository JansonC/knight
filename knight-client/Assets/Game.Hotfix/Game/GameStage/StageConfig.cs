﻿//======================================================================
//        Copyright (C) 2015-2020 Winddy He. All rights reserved
//        Email: hgplan@126.com
//======================================================================
using Knight.Hotfix.Core;

namespace Game
{
    [HotfixSBGroup("GameConfig")]
    public partial class StageConfig : HotfixSerializerBinary
    {
        /// <summary>
        /// 关卡ID
        /// </summary>
        public int StageID;

        /// <summary>
        /// 关卡对应的AB路径
        /// </summary>
        public string SceneABPath;

        /// <summary>
        /// 关卡对应的场景资源路径
        /// </summary>
        public string ScenePath;

        /// <summary>
        /// 角色的初始位置
        /// </summary>
        public float[] BornPos;

        /// <summary>
        /// 相机的初始化参数
        /// </summary>
        public float[] CameraSettings;
    }
}

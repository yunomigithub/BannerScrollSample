// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LoadingConst.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using UnityEngine;

    #endregion

    /// <summary> 定数関連 </summary>
    public class LoadingConst : MonoBehaviour
    {
        /// <summary> 自動でバナーがスクロールする時間 </summary>
        public const float AutoBannerMoveIntervalTime = 5.0f;

        /// <summary> バナーの移動に要する時間 </summary>
        public const float BannerMoveTime = 0.3f;

        public const int LeftMove = 2;

        public const int RightMove = 1;

        /// <summary> フリックしたとみなされる幅 </summary>
        public const float FlickSensitivity = 30;
    }
}
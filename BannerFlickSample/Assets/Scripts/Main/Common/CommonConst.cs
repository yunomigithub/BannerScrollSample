// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommonConst.cs">
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

    /// <summary> 共通の定数管理 </summary>
    public class CommonConst : MonoBehaviour
    {
        /// <summary> フリック処理の連続処理を回避するための時間(ms) </summary>
        public const float FlickDodgeTime = 400f;

        /// <summary> タップ処理の連続処理を回避するための時間(ms) </summary>
        public const float TapDodgeTime = 400f;
    }
}
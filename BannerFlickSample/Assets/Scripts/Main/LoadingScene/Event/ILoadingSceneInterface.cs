// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ILoadingSceneInterface.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using UnityEngine.EventSystems;

    #endregion

    /// <summary> ローディングシーン用のインターフェイス </summary>
    public interface ILoadingSceneInterface : IEventSystemHandler
    {
        void ManualMovementLoadingImage(int flickDirection);
    }
}
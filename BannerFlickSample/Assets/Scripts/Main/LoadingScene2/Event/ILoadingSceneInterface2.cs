// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ILoadingSceneInterface2.cs">
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
    public interface ILoadingSceneInterface2 : IEventSystemHandler
    {
        void ManualMovementLoadingImage(int flickDirection);

        void OnPointerUpMoveContentBanner(int flickDirection);
    }
}
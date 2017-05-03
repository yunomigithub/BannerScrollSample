// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LeftArrowTapEvent2.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using System;
    using UniRx;
    using UniRx.Triggers;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    #endregion

    /// <summary> 左矢印ボタン用のイベント </summary>
    [RequireComponent(typeof(Button))]
    public class LeftArrowTapEvent2 : MonoBehaviour
    {
        private void Awake()
        {
            this.GetComponent<Button>().OnPointerClickAsObservable().ThrottleFirst(TimeSpan.FromMilliseconds(CommonConst.TapDodgeTime)).Subscribe(_ => {
                ExecuteEvents.Execute<ILoadingSceneInterface2>(LoadingPresenter2.Instance.gameObject, null, (target, funcEventData) => target.ManualMovementLoadingImage(LoadingConst.RightMove));
            }).AddTo(this);
        }
    }
}
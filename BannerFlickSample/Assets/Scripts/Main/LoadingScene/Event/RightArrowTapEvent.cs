// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RightArrowTapEvent.cs">
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

    /// <summary> 右矢印ボタン用のイベント </summary>
    [RequireComponent(typeof(Button))]
    public class RightArrowTapEvent : MonoBehaviour
    {
        private void Awake()
        {
            this.GetComponent<Button>().OnPointerClickAsObservable().ThrottleFirst(TimeSpan.FromMilliseconds(CommonConst.TapDodgeTime)).Subscribe(_ => {
                ExecuteEvents.Execute<ILoadingSceneInterface>(LoadingPresenter.Instance.gameObject, null, (target, funcEventData) => target.ManualMovementLoadingImage(LoadingConst.LeftMove));
            }).AddTo(this);
        }
    }
}
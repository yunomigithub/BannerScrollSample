// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BannerScrollEvent.cs">
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

    #endregion

    /// <summary> バナーのスクロールを終えたかどうかの判定 </summary>
    public class BannerScrollEvent : MonoBehaviour
    {
        private Vector2 beginPosition;

        private void Awake()
        {
            var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();

            eventTrigger.OnPointerDownAsObservable().ThrottleFirst(TimeSpan.FromMilliseconds(CommonConst.FlickDodgeTime)).Subscribe(pointerEventData => {
                this.beginPosition = pointerEventData.position;
            }).AddTo(this);

            // 左スクロール
            eventTrigger.OnPointerUpAsObservable()
                .ThrottleFirst(TimeSpan.FromMilliseconds(CommonConst.TapDodgeTime))
                .Where(pointerEventData => this.beginPosition.x > pointerEventData.position.x)
                .Subscribe(_ => {
                    ExecuteEvents.Execute<ILoadingSceneInterface2>(LoadingPresenter2.Instance.gameObject, null, (target, funcEventData) => target.OnPointerUpMoveContentBanner(LoadingConst.LeftMove));
                }).AddTo(this);

            // 右スクロール
            eventTrigger.OnPointerUpAsObservable()
                .ThrottleFirst(TimeSpan.FromMilliseconds(CommonConst.TapDodgeTime))
                .Where(pointerEventData => this.beginPosition.x < pointerEventData.position.x)
                .Subscribe(_ => {
                    ExecuteEvents.Execute<ILoadingSceneInterface2>(LoadingPresenter2.Instance.gameObject, null, (target, funcEventData) => target.OnPointerUpMoveContentBanner(LoadingConst.RightMove));
                }).AddTo(this);
        }
    }
}
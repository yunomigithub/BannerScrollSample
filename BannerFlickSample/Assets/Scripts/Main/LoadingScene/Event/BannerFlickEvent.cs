// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BannerFlickEvent.cs">
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

    /// <summary>
    /// フリック処理イベント
    /// </summary>
    public class BannerFlickEvent : MonoBehaviour
    {
        private Vector2 beginPosition;

        private DateTime beginTime;

        private void Awake()
        {
            var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();

            eventTrigger.OnPointerDownAsObservable().ThrottleFirst(TimeSpan.FromMilliseconds(CommonConst.FlickDodgeTime)).Subscribe(pointerEventData => {
                this.beginPosition = pointerEventData.position;
                this.beginTime = DateTime.Now;
            }).AddTo(this);

            // 左フリック処理
            eventTrigger.OnPointerUpAsObservable()
                .Where(_ => (DateTime.Now - this.beginTime).TotalSeconds <= 1)
                .Where(pointerEventData => this.beginPosition.x - LoadingConst.FlickSensitivity > pointerEventData.position.x)
                .Subscribe(pointerEventData => {
                    ExecuteEvents.Execute<ILoadingSceneInterface>(LoadingPresenter.Instance.gameObject, null, (target, funcEventData) => target.ManualMovementLoadingImage(LoadingConst.LeftMove));
                }).AddTo(this);

            // 右フリック処理
            eventTrigger.OnPointerUpAsObservable()
                .Where(_ => (DateTime.Now - this.beginTime).TotalSeconds <= 1)
                .Where(pointerEventData => this.beginPosition.x + LoadingConst.FlickSensitivity < pointerEventData.position.x)
                .Subscribe(pointerEventData => {
                    ExecuteEvents.Execute<ILoadingSceneInterface>(LoadingPresenter.Instance.gameObject, null, (target, funcEventData) => target.ManualMovementLoadingImage(LoadingConst.RightMove));
                }).AddTo(this);
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LoadingPresenter2.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using System;
    using System.Collections;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary>
    /// ローディングを管理するためのクラス
    /// </summary>
    public class LoadingPresenter2 : SingletonMonoBehaviourFast<LoadingPresenter2>, ILoadingSceneInterface2
    {
        [SerializeField]
        private BannerCountImageRootView bannerCountImageRootView;

        [SerializeField]
        private ContentRootView2 contentRootView;

        private LoadingBannerModel loadingBannerModel = new LoadingBannerModel();

        private IDisposable moveBannerCoroutine;

        /// <summary>
        /// 手動でバナーを移動させた場合（矢印画像をタップ）
        /// </summary>
        /// <param name="flickDirection">フリックされた方向</param>
        public void ManualMovementLoadingImage(int flickDirection)
        {
            this.contentRootView.MoveContentBanner(flickDirection, this.loadingBannerModel);
            this.moveBannerCoroutine.Dispose();
            this.moveBannerCoroutine = Observable.FromCoroutine(this.AutoMoveLoadingImageCoroutine).Subscribe();
        }

        /// <summary>
        /// バナースクロール上で画面を離したタイミングでバナー位置を調整する
        /// </summary>
        /// <param name="moveDirection">スクロールした方向</param>
        public void OnPointerUpMoveContentBanner(int moveDirection)
        {
            this.contentRootView.OnPointerUpMoveContentBanner(moveDirection, this.loadingBannerModel);
            this.moveBannerCoroutine.Dispose();
            this.moveBannerCoroutine = Observable.FromCoroutine(this.AutoMoveLoadingImageCoroutine).Subscribe();
        }

        private void Start()
        {
            this.bannerCountImageRootView.CreateBannerCountImage(this.loadingBannerModel.MaxBannerNum);
            this.contentRootView.CreateBannerImage();

            this.moveBannerCoroutine = Observable.FromCoroutine(this.AutoMoveLoadingImageCoroutine).Subscribe();

            this.contentRootView.gameObject.GetComponent<ScrollRect>().OnValueChangedAsObservable().Subscribe(_ => {
                this.contentRootView.CheckContentRootPosition(this.loadingBannerModel);
            }).AddTo(this);

            this.loadingBannerModel.NowBannerPos.Subscribe(pos => {
                this.bannerCountImageRootView.ShowBannerCountCheckImageToggle(pos);
            }).AddTo(this);
        }

        /// <summary> 自動スクロール用のコルーチン(手動操作中は自動スクロールが起こらないように制御) </summary>
        private IEnumerator AutoMoveLoadingImageCoroutine()
        {
            while (true) {
                yield return new WaitForSeconds(LoadingConst.AutoBannerMoveIntervalTime);

                if (this.contentRootView.IsDuringMove()) {
                    this.contentRootView.MoveContentBanner(LoadingConst.LeftMove, this.loadingBannerModel);
                }
            }
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LoadingPresenter.cs">
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

    #endregion

    /// <summary>
    /// ローディングを管理するためのクラス
    /// </summary>
    public class LoadingPresenter : SingletonMonoBehaviourFast<LoadingPresenter>, ILoadingSceneInterface
    {
        [SerializeField]
        private BannerCountImageRootView bannerCountImageRootView;

        [SerializeField]
        private ContentRootView contentRootView;

        private LoadingBannerModel loadingBannerModel = new LoadingBannerModel();

        private IDisposable moveBannerCoroutine;

        /// <summary>
        /// 手動でバナーを移動させた場合（フリックor矢印画像をタップ）
        /// </summary>
        /// <param name="flickDirection">フリックされた方向</param>
        public void ManualMovementLoadingImage(int flickDirection)
        {
            this.contentRootView.MoveContentBanner(flickDirection, this.loadingBannerModel);
            this.moveBannerCoroutine.Dispose();
            this.moveBannerCoroutine = Observable.FromCoroutine(this.AutoMoveLoadingImageCoroutine).Subscribe();
        }

        private void Start()
        {
            this.bannerCountImageRootView.CreateBannerCountImage(this.loadingBannerModel.MaxBannerNum);
            this.contentRootView.CreateBannerImage();
            this.moveBannerCoroutine = Observable.FromCoroutine(this.AutoMoveLoadingImageCoroutine).Subscribe();

            this.loadingBannerModel.NowBannerPos.Subscribe(pos => {
                this.bannerCountImageRootView.ShowBannerCountCheckImageToggle(pos);
            }).AddTo(this);
        }

        /// <summary> 自動スクロール用のコルーチン </summary>
        private IEnumerator AutoMoveLoadingImageCoroutine()
        {
            while (true) {
                yield return new WaitForSeconds(LoadingConst.AutoBannerMoveIntervalTime);

                this.contentRootView.MoveContentBanner(LoadingConst.LeftMove, this.loadingBannerModel);
            }
        }
    }
}
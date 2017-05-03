// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ContentRootView2.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using System;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> バナースクロール用のView </summary>
    [RequireComponent(typeof(HorizontalLayoutGroup)), RequireComponent(typeof(ScrollRect))]
    public class ContentRootView2 : MonoBehaviour
    {
        private float contentSizeWidth;

        /// <summary> バナーの位置を監視し、バナー下のチェックマークと位置を同期させる </summary>
        public void CheckContentRootPosition(LoadingBannerModel loadingBannerModel)
        {
            Vector2 contentPosition = this.GetComponent<RectTransform>().anchoredPosition;

            loadingBannerModel.NowBannerPos.Value = (int)Math.Abs(contentPosition.x / this.contentSizeWidth);
        }

        /// <summary> バナーを設置する、サーバーと通信させて行う場合はここを修正する </summary>
        public void CreateBannerImage()
        {
            // バナーを表示する
            GameObject bannerObject = Instantiate((GameObject)Resources.Load("Prefab/BannerImage01"), this.transform, false);
            Instantiate((GameObject)Resources.Load("Prefab/BannerImage02"), this.transform, false);
            Instantiate((GameObject)Resources.Load("Prefab/BannerImage03"), this.transform, false);

            this.contentSizeWidth = bannerObject.GetComponent<RectTransform>().sizeDelta.x + this.gameObject.GetComponent<HorizontalLayoutGroup>().spacing;
        }

        /// <summary> バナーがぴったり止まっているかどうか </summary>
        public bool IsDuringMove()
        {
            Vector2 contentPosition = this.GetComponent<RectTransform>().anchoredPosition;

            // ユーザーさんの手動移動の場合、Unity標準のバウンド処理でポジションがほんの少しずれるので調整を入れている
            if (Math.Abs(contentPosition.x % this.contentSizeWidth) < 1) {
                return true;
            }

            return false;
        }

        /// <summary> バナーの移動処理 </summary>
        public void MoveContentBanner(int flickDirection, LoadingBannerModel loadingBannerModel)
        {
            Vector2 contentPosition = this.GetComponent<RectTransform>().anchoredPosition;
            int maxBannerPos = loadingBannerModel.MaxBannerNum - 1;

            switch (flickDirection) {
                case LoadingConst.LeftMove:
                    if (loadingBannerModel.NowBannerPos.Value == maxBannerPos) {
                        contentPosition.x = 0;
                    }
                    else {
                        contentPosition.x -= this.contentSizeWidth;
                    }

                    break;
                case LoadingConst.RightMove:
                    if (loadingBannerModel.NowBannerPos.Value == 0) {
                        contentPosition.x = maxBannerPos * -this.contentSizeWidth;
                    }
                    else {
                        contentPosition.x += this.contentSizeWidth;
                    }

                    break;
            }

            this.GetComponent<RectTransform>().DOAnchorPos(contentPosition, LoadingConst.BannerMoveTime).SetEase(Ease.InQuad);
        }

        /// <summary> 指を離した時に中途半端な位置にあるバナーを適正位置に移動させる </summary>
        public void OnPointerUpMoveContentBanner(int scrollDirection, LoadingBannerModel loadingBannerModel)
        {
            Vector2 contentPosition = this.GetComponent<RectTransform>().anchoredPosition;
            int bannerNo = (int)Math.Abs(contentPosition.x / this.contentSizeWidth);
            int maxBannerNo = loadingBannerModel.MaxBannerNum - 1;

            switch (scrollDirection) {
                case LoadingConst.LeftMove:
                    if ((Math.Abs(contentPosition.x) >= bannerNo * this.contentSizeWidth + this.contentSizeWidth / 3) && (bannerNo != maxBannerNo)) {
                        contentPosition.x = -this.contentSizeWidth * (bannerNo + 1);
                    }
                    else {
                        contentPosition.x = -this.contentSizeWidth * bannerNo;
                    }

                    break;
                case LoadingConst.RightMove:
                    if ((Math.Abs(contentPosition.x) <= bannerNo * this.contentSizeWidth + this.contentSizeWidth / 3 * 2) || (contentPosition.x >= 0)) {
                        contentPosition.x = -this.contentSizeWidth * bannerNo;
                    }
                    else {
                        contentPosition.x = -this.contentSizeWidth * (bannerNo + 1);
                    }

                    break;
            }

            this.GetComponent<RectTransform>().DOAnchorPos(contentPosition, LoadingConst.BannerMoveTime).SetEase(Ease.InQuad);
        }
    }
}
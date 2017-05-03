// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BannerCountImageRootView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using System.Collections.Generic;
    using UnityEngine;

    #endregion

    /// <summary> バナーの下にある●ボタンを管理（全体） </summary>
    public class BannerCountImageRootView : MonoBehaviour
    {
        private List<BannerCountImageView> bannerCountCheckToggleList = new List<BannerCountImageView>();

        /// <summary> バナー下の●画像を作成 </summary>
        public void CreateBannerCountImage(int bannerNum)
        {
            for (var i = 0; i < bannerNum; i++) {
                GameObject bannerObject = Instantiate((GameObject)Resources.Load("Prefab/BannerCountImage"), this.transform, false);
                bannerObject.transform.SetAsLastSibling();
                this.bannerCountCheckToggleList.Add(bannerObject.GetComponent<BannerCountImageView>());
            }
        }

        /// <summary> ●の表示トグルを変更 </summary>
        public void ShowBannerCountCheckImageToggle(int bannerNo)
        {
            this.bannerCountCheckToggleList[bannerNo].GetComponent<BannerCountImageView>().ShowBannerCountCheckImageToggle();
        }
    }
}
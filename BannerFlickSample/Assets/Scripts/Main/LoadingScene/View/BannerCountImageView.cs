// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BannerCountImageView.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    /// <summary> バナー下の●を管理（個別） </summary>
    public class BannerCountImageView : MonoBehaviour
    {
        [SerializeField]
        private Toggle bannerCountCheckImageToggle;

        private void Awake()
        {
            this.bannerCountCheckImageToggle.group = this.transform.parent.GetComponent<ToggleGroup>();
        }

        /// <summary> ●を活性化させる </summary>
        public void ShowBannerCountCheckImageToggle()
        {
            this.bannerCountCheckImageToggle.isOn = true;
        }
    }
}
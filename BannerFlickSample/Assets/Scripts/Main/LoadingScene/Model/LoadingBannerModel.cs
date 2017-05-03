// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LoadingBannerModel.cs">
//      Copyright ©Yunomi. All rights reserved.
//  </copyright>
//  <author>Yunomi</author>
//  <email>yunomi@childhooddream.sakura.ne.jp</email>
// --------------------------------------------------------------------------------------------------------------------
namespace MyChildhoodDream
{
    #region

    using UniRx;

    #endregion

    /// <summary> ローディングシーンのモデル </summary>
    public class LoadingBannerModel
    {
        public LoadingBannerModel()
        {
            this.MaxBannerNum = 3;
            this.NowBannerPos = new IntReactiveProperty(0);
        }

        public int MaxBannerNum { get; private set; }
        public IntReactiveProperty NowBannerPos { get; set; }
    }
}
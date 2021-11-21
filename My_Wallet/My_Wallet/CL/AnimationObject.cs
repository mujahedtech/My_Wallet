using System;
using Xamarin.Forms;

namespace My_Wallet.CL
{
    class AnimationObject
    {

        public static async void StartAnimationFrame(Frame Frame)
        {

            Frame.Scale = 0;

            Frame.IsVisible = true;
            //await FrameNewAccount.ScaleTo(3, 1000);
            await Frame.ScaleTo(1, 200, Easing.CubicIn);

        }

        public static async void EndAnimationFrame(Frame Frame)
        {

            Frame.Scale = 1;

          
            //await FrameNewAccount.ScaleTo(3, 1000);
            await Frame.ScaleTo(0, 200, Easing.Linear);

            Frame.IsVisible = false;

        }










        public static  void AnimationHeightFrame(Frame Grid)
        {
            var mainDisplayInfo = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo;
            

            if (Grid.Height == 0)
            {
                Action<double> callback = input => Grid.HeightRequest = input;
                double startHeight = 0;
                double endHeight = mainDisplayInfo.Height / 3;
                uint rate = 32;
                uint length = 500;
                Easing easing = Easing.Linear;
                Grid.Animate("anim", callback, startHeight, endHeight, rate, length, easing);
            }
            else
            {
                Action<double> callback = input => Grid.HeightRequest = input;
                double startHeight = mainDisplayInfo.Height / 3;
                double endiendHeight = 0;
                uint rate = 32;
                uint length = 500;
                Easing easing = Easing.SinOut;
                Grid.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);

            }


        }






    }
}

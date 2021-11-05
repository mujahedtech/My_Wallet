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
            await Frame.ScaleTo(1, 1000, Easing.BounceIn);

        }

        public static async void EndAnimationFrame(Frame Frame)
        {

            Frame.Scale = 1;

          
            //await FrameNewAccount.ScaleTo(3, 1000);
            await Frame.ScaleTo(0, 1000, Easing.BounceOut);

            Frame.IsVisible = false;

        }

    }
}

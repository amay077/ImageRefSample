using System;
using System.Reflection;
using UIKit;

namespace ImageRefSample.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // 他のプロジェクトにある型からアセンブリを取得
            var assembly = typeof(MyClass).GetTypeInfo().Assembly;

            // 一応埋め込みリソースをリストアップ
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            // ImageRefSample プロジェクトの myprof.png を読み込み
            using (var stream = assembly.GetManifestResourceStream("ImageRefSample.myprof.png"))
            {
                var imageData = Foundation.NSData.FromStream(stream);
                var image = UIImage.LoadFromData(imageData);

                image1.Image = image;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ProductiveBob_Firebase.Services;
using UIKit;

namespace ProductiveBob_Firebase.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

    }
    public class GetInfoImplement : IGetDeviceInfo
    {
        string IGetDeviceInfo.GetDeviceID()
        {
            string id = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            return id;
        }
    }
}

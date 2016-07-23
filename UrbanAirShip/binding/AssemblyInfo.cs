using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libUAirship-5.0.3.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7,
                     Frameworks = "MobileCoreServices CFNetwork CoreGraphics Security SystemConfiguration CoreTelephony StoreKit CoreLocation MessageUI AudioToolbox MapKit UIKit", LinkerFlags = "-lsqlite3",  ForceLoad = false, SmartLink = true)]

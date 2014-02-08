using System;

using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using MonoTouch.CoreMotion;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Wikitude {

    [Model, BaseType (typeof (NSObject))]
    public partial interface WTArchitectViewDelegate {

        [Export ("architectView:invokedURL:")]
        void InvokedURL (WTArchitectView architectView, NSUrl url);

        [Export ("architectView:didFailLoadWithError:")]
        void DidFailLoadWithError (WTArchitectView architectView, NSError error);

        [Export ("architectView:didCaptureScreenWithContext:")]
        void DidCaptureScreenWithContext (WTArchitectView architectView, NSDictionary context);

        [Export ("architectView:didFailCaptureScreenWithError:")]
        void DidFailCaptureScreenWithError (WTArchitectView architectView, NSError error);
    }

    [BaseType (typeof (UIView))]
    public partial interface WTArchitectView {

        [Field ("kWTScreenshotBundleDirectoryKey", "__Internal")]
        NSString WTScreenshotBundleDirectoryKey { get; }

        [Field ("kWTScreenshotSaveModeKey", "__Internal")]
        NSString WTScreenshotSaveModeKey { get; }

        [Field ("kWTScreenshotCaptureModeKey", "__Internal")]
        NSString WTScreenshotCaptureModeKey { get; }

        [Field ("kWTScreenshotImageKey", "__Internal")]
        NSString WTScreenshotImageKey { get; }

        [Export ("delegate", ArgumentSemantic.Assign)]
        WTArchitectViewDelegate Delegate { get; set; }

        [Export ("isRunning")]
        bool IsRunning { get; }

        [Export ("desiredLocationAccuracy")]
        Double DesiredLocationAccuracy { get; set; }

        [Export ("desiredDistanceFilter")]
        Double DesiredDistanceFilter { get; set; }

        [Export ("shouldWebViewRotate")]
        bool ShouldWebViewRotate { get; set; }

        [Static, Export ("isDeviceSupportedForARMode:")]
        bool IsDeviceSupportedForARMode (WTARMode supportedARMode);

        [Export ("initializeWithKey:motionManager:")]
        void InitializeWithKey (string key, CMMotionManager motionManager);

        [Export ("loadArchitectWorldFromUrl:")]
        void LoadArchitectWorldFromUrl (NSUrl architectWorldUrl);

        [Export ("callJavaScript:")]
        void CallJavaScript (string javaScript);

        [Export ("injectLocationWithLatitude:longitude:altitude:accuracy:")]
        void InjectLocationWithLatitude (Double latitude, Double longitude, Double altitude, Double accuracy);

        [Export ("injectLocationWithLatitude:longitude:accuracy:")]
        void InjectLocationWithLatitude (Double latitude, Double longitude, Double accuracy);

        [Export ("useInjectedLocation")]
        bool UseInjectedLocation { set; }

        [Export ("isUsingInjectedLocation")]
        bool IsUsingInjectedLocation { get; }

        [Export ("cullingDistance")]
        float CullingDistance { get; set; }

        [Export ("versionNumber")]
        string VersionNumber { get; }

        [Export ("clearCache")]
        void ClearCache ();

        [Export ("setShouldRotate:toInterfaceOrientation:")]
        void SetShouldRotate (bool shouldAutoRotate, UIInterfaceOrientation interfaceOrientation);

        [Export ("isRotatingToInterfaceOrientation")]
        bool IsRotatingToInterfaceOrientation { get; }

        [Export ("stop")]
        void Stop ();

        [Export ("start")]
        void Start ();

        [Export ("motionManager")]
        CMMotionManager MotionManager { get; }

        [Export ("captureScreenWithMode:usingSaveMode:saveOptions:context:")]
        void CaptureScreenWithMode (WTScreenshotCaptureMode captureMode, WTScreenshotSaveMode saveMode, WTScreenshotSaveOptions options, NSDictionary context);
    }
}

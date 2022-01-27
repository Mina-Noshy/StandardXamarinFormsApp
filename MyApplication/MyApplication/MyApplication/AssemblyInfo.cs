using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

// use traffic to send and receive request from api
[assembly: Application(UsesCleartextTraffic = true)]

// get network permission;
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]

[assembly: ExportFont("fa-brands-400.ttf", Alias = "FA-B")]
[assembly: ExportFont("fa-regular-400.ttf", Alias = "FA-R")]
[assembly: ExportFont("fa-solid-900.ttf", Alias = "FA-S")]

[assembly: ExportFont("Cairo-Bold.ttf", Alias = "FONT-AR-BOLD")]
[assembly: ExportFont("Cairo-Light.ttf", Alias = "FONT-AR-LIGHT")]
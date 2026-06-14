using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace VirtualVector.Game_View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        Boolean initalized = false;
        public GameView()
        {
            InitializeComponent();
            Loaded += GameView_Loaded;
        }
        private async Task InitializeWebViewAsync()
        {
            if (initalized) return;

            CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions("--disable-web-security");

            //// Enable dev tools for debugging (optional - press F12)
            //GameEngine.CoreWebView2.Settings.AreDevToolsEnabled = true;

            //// Get the path to your local HTML file
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation)!;
            string webAppPath = Path.Combine(assemblyDirectory, "WebApp", "index.html");
            string userDataFolder = System.IO.Path.Combine(assemblyDirectory, "WebApp", "./Scene_View/");
            CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync("", userDataFolder, options);
            await GameEngine.EnsureCoreWebView2Async(environment);

            GameEngine.CoreWebView2.Settings.AreHostObjectsAllowed = true;
            GameEngine.CoreWebView2.Settings.IsScriptEnabled = true;
            GameEngine.CoreWebView2.Settings.IsWebMessageEnabled = true;
            GameEngine.CoreWebView2.SetVirtualHostNameToFolderMapping("gameengine", new Uri(assemblyDirectory).AbsolutePath, CoreWebView2HostResourceAccessKind.Allow);

            GameEngine.Source = new Uri("https://gameengine/Game_View/index.html");
            initalized = true;

        }
        private async void GameView_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeWebViewAsync();
        }
    }
}

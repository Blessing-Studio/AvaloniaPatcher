using System;
using System.Reflection;
using Avalonia;
using Avalonia.ReactiveUI;
using AvaloniaApplication.Views;

namespace AvaloniaApplication.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        BlessingStudio.AvaloniaPatcher.AvaloniaPatcher.Init(Assembly.GetAssembly(typeof(MainView))!);
        BlessingStudio.AvaloniaPatcher.AvaloniaPatcher.Patch(typeof(MainWindow), new TestPatch1());
        BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}

﻿namespace Chromely.CefGlue.Gtk.ChromeHost
{
    using Xilium.CefGlue;
    using Chromely.Core;
    using Chromely.Core.Helpers;

    public class CefGlueBrowserHost : HostBase
    {
        public CefGlueBrowserHost(ChromelyConfiguration hostConfig) 
            : base(hostConfig)
        {
        }

        protected override void PlatformInitialize()
        {
            Application.Init();
        }

        protected override void PlatformShutdown()
        {
        }

        protected override void PlatformRunMessageLoop()
        {
            bool isMultiThreadedLoopSet = HostConfig.GetBooleanValue(CefSettingKeys.MultiThreadedMessageLoop, true);

            if (!isMultiThreadedLoopSet)
            {
                CefRuntime.RunMessageLoop();
            }
            else
            {
                Application.Run();
            }
        }

        protected override void PlatformQuitMessageLoop()
        {
            if (CefRuntime.Platform == CefRuntimePlatform.Windows) Application.Quit();
            else CefRuntime.QuitMessageLoop();
        }

        protected override Window CreateMainView()
        {
            return new Window(this, HostConfig);
        }
    }
}

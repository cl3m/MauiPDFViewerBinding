using System;
using Android.OS;
using Java.Interop;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Handlers;
using Binding = Com.Maui.Binding.Binding;
using MauiDemoApp.Platforms.Android;
using Java.Net;
using static Android.Icu.Text.CaseMap;

namespace MauiDemoApp
{
    public partial class PDFViewHandler : ViewHandler<PDFView, Android.Views.View>
    {
        public PDFViewHandler(IPropertyMapper mapper, CommandMapper commandMapper = null)
            : base(mapper, commandMapper) { }

        protected override Android.Views.View CreatePlatformView()
        {
            return new Binding().CreatePDFView(MainActivity.instance);
        }

        public static void PDFUrl(PDFViewHandler handler, PDFView view)
        {
            new Binding().SetPDFViewURL(MainActivity.instance, handler.PlatformView, view.Url);
        }

        protected override void ConnectHandler(Android.Views.View platformView)
        {
            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(Android.Views.View platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }
    }
}

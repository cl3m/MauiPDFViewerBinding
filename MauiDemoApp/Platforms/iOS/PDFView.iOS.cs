using System;
using Microsoft.Maui.Handlers;
using UIKit;
using iOS.Binding;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MauiDemoApp
{
    public partial class PDFViewHandler : ViewHandler<PDFView, UIView>
    {
        public PDFViewHandler(IPropertyMapper mapper, CommandMapper commandMapper = default!)
            : base(mapper, commandMapper) { }

        protected override UIView CreatePlatformView()
        {
            return new iOS.Binding.Binding().CreatePDFView;
        }

        public static void PDFUrl(PDFViewHandler handler, PDFView view)
        {
            new iOS.Binding.Binding().SetPDFViewURLWithView(handler.PlatformView, view.Url);
        }

        protected override void ConnectHandler(UIView platformView)
        {
            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(UIView platformView)
        {
            platformView.Dispose();
            base.DisconnectHandler(platformView);
        }
    }
}

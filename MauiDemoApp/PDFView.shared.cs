using System;
using System.ComponentModel;
using Microsoft.Maui.Handlers;

namespace MauiDemoApp
{
    public class PDFView : View
    {
        public string Url
        {
            get { return (string)base.GetValue(UrlProperty); }
            set { base.SetValue(UrlProperty, value); }
        }
        public static readonly BindableProperty UrlProperty = BindableProperty.Create(
            propertyName: nameof(Url),
            returnType: typeof(string),
            declaringType: typeof(PDFView),
            defaultValue: "");
    }

    partial class PDFViewHandler
    {
        public static IPropertyMapper<PDFView, PDFViewHandler> PropertyMapper = new PropertyMapper<PDFView, PDFViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(PDFView.Url)] = PDFUrl
        };

        public PDFViewHandler() : base(PropertyMapper)
        {
        }
    }
}




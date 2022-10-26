using Foundation;

namespace iOS.Binding
{
	// typedef void (^StringCallback)(NSString * _Nonnull);
	delegate void StringCallback (string arg0);

	// @interface Binding : NSObject
	[BaseType (typeof(NSObject))]
	interface Binding
	{
		// -(void)asyncWithParameters:(NSArray<NSString *> * _Nonnull)parameters callback:(StringCallback _Nonnull)callback;
		[Export ("asyncWithParameters:callback:")]
		void AsyncWithParameters (string[] parameters, StringCallback callback);

		// -(void)openPDFWithTitle:(NSString * _Nonnull)title url:(NSString * _Nonnull)url;
		[Export ("openPDFWithTitle:url:")]
		void OpenPDFWithTitle (string title, string url);
	}
}

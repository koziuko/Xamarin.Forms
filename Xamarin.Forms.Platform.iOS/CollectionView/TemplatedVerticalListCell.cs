﻿using System;
using System.Diagnostics;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	internal sealed class TemplatedVerticalListCell : TemplatedCell, IConstrainedCell
	{
		public static NSString ReuseId = new NSString("Xamarin.Forms.Platform.iOS.TemplatedVerticalListCell");

		[Export("initWithFrame:")]
		public TemplatedVerticalListCell(CGRect frame) : base(frame)
		{
		}

		public void SetConstrainedDimension(nfloat constant)
		{
			ConstrainedDimension = constant;
			Layout();
		}

		protected override void Layout()
		{
			var nativeView = VisualElementRenderer.NativeView;

			nativeView.BackgroundColor = UIColor.Green;

			Debug.WriteLine($">>>>> TemplatedCell SetRenderer: ContentView.Frame.Width {ContentView.Frame.Width}");
			Debug.WriteLine($">>>>> TemplatedCell SetRenderer: ContentView.Frame.Height {ContentView.Frame.Height}");

			var measure = VisualElementRenderer.Element.Measure(ConstrainedDimension, 
				ContentView.Frame.Height, MeasureFlags.IncludeMargins);

			Debug.WriteLine($">>>>> TemplatedCell SetRenderer: sizeRequest is {measure}");

			var height = VisualElementRenderer.Element.Height > 0 
				? VisualElementRenderer.Element.Height : measure.Request.Height;

			nativeView.Frame = new CGRect(0, 0, ConstrainedDimension, height);
			ContentView.Frame = nativeView.Frame;

			Debug.WriteLine($">>>>> TemplatedCell SetRenderer 48: {nativeView.Frame}");

			VisualElementRenderer.Element.Layout(nativeView.Frame.ToRectangle());

			Debug.WriteLine($">>>>> TemplatedCell SetRenderer 52: {VisualElementRenderer.Element.Bounds}");
			Debug.WriteLine($">>>>> TemplatedCell SetRenderer 53: {ContentView.Frame}");
		}
	}
}
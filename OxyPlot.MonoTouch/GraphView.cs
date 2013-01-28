// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphView.cs" company="OxyPlot">
//   The MIT License (MIT)
//
//   Copyright (c) 2012 Oystein Bjorke
//
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using OxyPlot;
using System;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch;
using MonoTouch.CoreFoundation;
using MonoTouch.CoreAnimation;

namespace OxyPlot.MonoTouch
{
	public class GraphView : UIView
	{
		private PlotModel plot;

		bool allowPinchScaling = false;
		public UIPinchGestureRecognizer pinchGestureRecognizer;

		double EPSILON = 1.0e-6;


		/// <summary>
		/// Initializes a new instance of the <see cref="MonoTouch.Demo.GraphView"/> class.
		/// </summary>
		/// <param name='exampleInfo'>
		/// Example info.
		/// </param>
		public GraphView (PlotModel plotInfo)
		{
			this.plot = plotInfo;

		}






		/// <summary>
		/// Draw the specified rect.
		/// </summary>
		/// <param name='rect'>
		/// Rect.
		/// </param>
		public override void Draw (System.Drawing.RectangleF rect)
		{

			plot.PlotMargins = new OxyThickness(10);
			plot.Background = OxyColors.LightGray;
			plot.Update(true);

			RectangleF big_rect = rect;

			big_rect.Width = rect.Width*UIScreen.MainScreen.Scale;
			big_rect.Height = rect.Height*UIScreen.MainScreen.Scale;
			big_rect.X = rect.X;
			big_rect.Y = rect.Y;

			SizeF new_image_size = new SizeF(big_rect.Width, big_rect.Height);

			UIGraphics.BeginImageContextWithOptions(new_image_size, true, 1);

			CGContext context = UIGraphics.GetCurrentContext();
			context.SaveState();

			context.InterpolationQuality = CGInterpolationQuality.High;

			MonoTouchRenderContext renderer = new MonoTouchRenderContext(context, big_rect);

			AdjustPlotChartMargins(plot, rect.Width*UIScreen.MainScreen.Scale, rect.Height*UIScreen.MainScreen.Scale);

			context.TranslateCTM(0.0f, big_rect.Height);
			context.ScaleCTM(1.0f, -1.0f);

			plot.Render(renderer);

			UIImage resulting_plot_image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			CGContext original_context = UIGraphics.GetCurrentContext();

			original_context.InterpolationQuality = CGInterpolationQuality.High;
			original_context.DrawImage (rect, resulting_plot_image.CGImage);

			context.RestoreState();

		}

		private void AdjustPlotChartMargins(PlotModel target_plot, double dWidth, double dHeight)
		{

			
			target_plot.IsLegendVisible = true;

			var horzMarginLeft = 50;
			var vertMarginTop = 20;
			var horzMarginRight = 20;
			var vertMarginBottom = 50;

			horzMarginLeft = Math.Max(0, horzMarginLeft);
			vertMarginTop = Math.Max(0, vertMarginTop);
			horzMarginRight = Math.Max(0, horzMarginRight);
			vertMarginBottom = Math.Max(0, vertMarginBottom);


			target_plot.PlotMargins = new OxyPlot.OxyThickness(horzMarginLeft, vertMarginTop, horzMarginRight, vertMarginBottom);

		}





		public override void TouchesCancelled (NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled (touches, evt);
			SetNeedsDisplay();
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);

			PointF pointOfTouch  = ((UITouch)touches.AnyObject).LocationInView(this);
			PointF pointOfTouchOld  = ((UITouch)touches.AnyObject).PreviousLocationInView(this);

			ScreenPoint point1 = new ScreenPoint(pointOfTouch.X, pointOfTouch.Y);
			ScreenPoint point2 = new ScreenPoint(pointOfTouchOld.X, pointOfTouchOld.Y);

			foreach (var item in plot.Axes) {
				item.Pan (point2, point1);
			}

			SetNeedsDisplay();
		}


		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);

			PointF pointOfTouch  = ((UITouch)touches.AnyObject).LocationInView(this);
			PointF pointOfTouchOld  = ((UITouch)touches.AnyObject).PreviousLocationInView(this);
			
			ScreenPoint point1 = new ScreenPoint(pointOfTouch.X, pointOfTouch.Y);
			ScreenPoint point2 = new ScreenPoint(pointOfTouchOld.X, pointOfTouchOld.Y);


			foreach (var item in plot.Axes) {
				item.Pan (point2, point1);
			}


			SetNeedsDisplay();
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);

			// Ignore pinch or other multitouch gestures
			if ( evt.AllTouches.Count > 1 ) {
				return;
			}
			PointF pointOfTouch  = ((UITouch)touches.AnyObject).LocationInView(this);
			PointF pointOfTouchOld  = ((UITouch)touches.AnyObject).PreviousLocationInView(this);
			
			ScreenPoint point1 = new ScreenPoint(pointOfTouch.X, pointOfTouch.Y);
			ScreenPoint point2 = new ScreenPoint(pointOfTouchOld.X, pointOfTouchOld.Y);

			foreach (var item in plot.Axes) {
				item.Pan (point2, point1);
			}

			SetNeedsDisplay();
		}
	


	public void SetAllowPinchScaling(bool allowScaling)
		{
			if ( allowPinchScaling != allowScaling ) {
				allowPinchScaling = allowScaling;
				if ( allowPinchScaling ) {
					// Register for pinches
					pinchGestureRecognizer = new UIPinchGestureRecognizer(HandlePinchGesture);
						this.AddGestureRecognizer(pinchGestureRecognizer);
					}
				}
				else {
					if ( pinchGestureRecognizer != null) {
						this.RemoveGestureRecognizer(pinchGestureRecognizer);
					}
					pinchGestureRecognizer = null;
				}
		}
			
		//PINCH ZOOM
		[Export]
		public void HandlePinchGesture(UIPinchGestureRecognizer aPinchGestureRecognizer)
		{

			PointF interactionPoint = aPinchGestureRecognizer.LocationInView(this);

			ScreenPoint point1 = new ScreenPoint(interactionPoint.X, interactionPoint.Y);


			foreach (var item in plot.Axes) {
				item.ZoomAt(pinchGestureRecognizer.Scale, point1);
			}

			pinchGestureRecognizer.Scale = 1.0f;
			SetNeedsDisplay();
		}






	}
}
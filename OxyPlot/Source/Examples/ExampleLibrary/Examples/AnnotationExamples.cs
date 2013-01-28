﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnnotationExamples.cs" company="OxyPlot">
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

namespace ExampleLibrary
{
    using System;

    [Examples("Annotations")]
    public static class AnnotationExamples
    {
        [Example("LineAnnotations on linear axes")]
        public static PlotModel LinearAxes()
        {
            var model = new PlotModel("LineAnnotations on linear axes");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 80));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10));
            model.Annotations.Add(new LineAnnotation { Slope = 0.1, Intercept = 1, Text = "First" });
            model.Annotations.Add(new LineAnnotation { Slope = 0.3, Intercept = 2, MaximumX = 40, Color = OxyColors.Red, Text = "Second" });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 4, MaximumY = 10, Color = OxyColors.Green, Text = "Vertical" });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Horizontal, Y = 2, MaximumX = 4, Color = OxyColors.Gold, Text = "Horizontal" });
            return model;
        }

        [Example("LineAnnotations on logarithmic axes")]
        public static PlotModel LogarithmicAxes()
        {
            var model = new PlotModel("Annotations on logarithmic axes");
            model.Axes.Add(new LogarithmicAxis(AxisPosition.Bottom, 1, 80));
            model.Axes.Add(new LogarithmicAxis(AxisPosition.Left, 1, 10));
            model.Annotations.Add(new LineAnnotation { Slope = 0.1, Intercept = 1, Text = "First", TextMargin = 40 });
            model.Annotations.Add(new LineAnnotation { Slope = 0.3, Intercept = 2, MaximumX = 40, Color = OxyColors.Red, Text = "Second" });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 4, MaximumY = 10, Color = OxyColors.Green, Text = "Vertical" });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Horizontal, Y = 2, MaximumX = 4, Color = OxyColors.Gold, Text = "Horizontal" });
            return model;
        }

        [Example("LineAnnotations with text orientation specified")]
        public static PlotModel LinearAxesTextOrientation()
        {
            var model = new PlotModel("LineAnnotations", "with TextOrientation specified");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 80));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10));
            model.Annotations.Add(new LineAnnotation { Slope = 0.1, Intercept = 1, Text = "Horizontal", TextOrientation = AnnotationTextOrientation.Horizontal, TextVerticalAlignment = VerticalTextAlign.Bottom });
            model.Annotations.Add(new LineAnnotation { Slope = 0.3, Intercept = 2, MaximumX = 40, Color = OxyColors.Red, Text = "Vertical", TextOrientation = AnnotationTextOrientation.Vertical });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 4, MaximumY = 10, Color = OxyColors.Green, Text = "Horizontal (x=4)", TextPadding = 8, TextOrientation = AnnotationTextOrientation.Horizontal });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 45, MaximumY = 10, Color = OxyColors.Green, Text = "Horizontal (x=45)", TextHorizontalAlignment = HorizontalTextAlign.Left, TextPadding = 8, TextOrientation = AnnotationTextOrientation.Horizontal });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Horizontal, Y = 2, MaximumX = 4, Color = OxyColors.Gold, Text = "Horizontal", TextPosition = 0.5, TextOrientation = AnnotationTextOrientation.Horizontal });
            return model;
        }

        [Example("RectangleAnnotations")]
        public static PlotModel RectangleAnnotation()
        {
            var model = new PlotModel("RectangleAnnotations - vertical limit");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom));
            model.Axes.Add(new LinearAxis(AxisPosition.Left));
            model.Annotations.Add(new RectangleAnnotation { MinimumX = 20, MaximumX = 70, MinimumY = 10, MaximumY = 40, TextRotation = 10, Text = "RectangleAnnotation", Fill = OxyColors.Black.ChangeAlpha(99) });
            return model;
        }

        [Example("RectangleAnnotations - vertical limit")]
        public static PlotModel RectangleAnnotationVerticalLimit()
        {
            var model = new PlotModel("RectangleAnnotations - vertical limit");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom));
            model.Axes.Add(new LinearAxis(AxisPosition.Left));
            model.Annotations.Add(new RectangleAnnotation { MaximumY = 89.5, Text = "Valid area", Fill = OxyColors.Black.ChangeAlpha(99) });
            return model;
        }

        [Example("RectangleAnnotations - horizontal bands")]
        public static PlotModel RectangleAnnotationsHorizontals()
        {
            var model = new PlotModel("RectangleAnnotation - horizontal bands");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0, 10));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, 87, 97) { MajorStep = 1, MinorStep = 1 });
            model.Annotations.Add(new RectangleAnnotation { MinimumY = 89.5, MaximumY = 90.8, Text = "Invalid", Fill = OxyColors.Red.ChangeAlpha(99) });
            model.Annotations.Add(new RectangleAnnotation { MinimumY = 90.8, MaximumY = 92.1, Fill = OxyColors.Orange.ChangeAlpha(99) });
            model.Annotations.Add(new RectangleAnnotation { MinimumY = 92.1, MaximumY = 94.6, Fill = OxyColors.Yellow.ChangeAlpha(99) });
            model.Annotations.Add(new RectangleAnnotation { MinimumY = 94.6, MaximumY = 96, Text = "Ok", Fill = OxyColors.Green.ChangeAlpha(99) });
            LineSeries series1;
            model.Series.Add(series1 = new LineSeries { Color = OxyColors.Black, StrokeThickness = 6.0, LineJoin = OxyPenLineJoin.Round });
            series1.Points.Add(new DataPoint(0.5, 90.7));
            series1.Points.Add(new DataPoint(1.5, 91.2));
            series1.Points.Add(new DataPoint(2.5, 91));
            series1.Points.Add(new DataPoint(3.5, 89.5));
            series1.Points.Add(new DataPoint(4.5, 92.5));
            series1.Points.Add(new DataPoint(5.5, 93.1));
            series1.Points.Add(new DataPoint(6.5, 94.5));
            series1.Points.Add(new DataPoint(7.5, 95.5));
            series1.Points.Add(new DataPoint(8.5, 95.7));
            series1.Points.Add(new DataPoint(9.5, 96.0));
            return model;
        }

        [Example("RectangleAnnotations - vertical bands")]
        public static PlotModel RectangleAnnotationsVerticals()
        {
            var model = new PlotModel("RectangleAnnotation - vertical bands");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0, 10));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, 87, 97) { MajorStep = 1, MinorStep = 1 });
            model.Annotations.Add(new RectangleAnnotation { MinimumX = 2.5, MaximumX = 2.8, TextRotation = 90, Text = "Red", Fill = OxyColors.Red.ChangeAlpha(99) });
            model.Annotations.Add(new RectangleAnnotation { MinimumX = 2.8, MaximumX = 6.1, TextRotation = 90, Text = "Orange", Fill = OxyColors.Orange.ChangeAlpha(99) });
            model.Annotations.Add(new RectangleAnnotation { MinimumX = 6.1, MaximumX = 7.6, TextRotation = 90, Text = "Yellow", Fill = OxyColors.Yellow.ChangeAlpha(99) });
            model.Annotations.Add(new RectangleAnnotation { MinimumX = 7.6, MaximumX = 9.7, TextRotation = 270, Text = "Green", Fill = OxyColors.Green.ChangeAlpha(99) });
            LineSeries series1;
            model.Series.Add(series1 = new LineSeries { Color = OxyColors.Black, StrokeThickness = 6.0, LineJoin = OxyPenLineJoin.Round });
            series1.Points.Add(new DataPoint(0.5, 90.7));
            series1.Points.Add(new DataPoint(1.5, 91.2));
            series1.Points.Add(new DataPoint(2.5, 91));
            series1.Points.Add(new DataPoint(3.5, 89.5));
            series1.Points.Add(new DataPoint(4.5, 92.5));
            series1.Points.Add(new DataPoint(5.5, 93.1));
            series1.Points.Add(new DataPoint(6.5, 94.5));
            series1.Points.Add(new DataPoint(7.5, 95.5));
            series1.Points.Add(new DataPoint(8.5, 95.7));
            series1.Points.Add(new DataPoint(9.5, 96.0));
            return model;
        }

        [Example("No clipping")]
        public static PlotModel LinearAxesMultipleAxes()
        {
            var model = new PlotModel("ClipByAxis", "This property controls if the annotation should be clipped by the current axes or by the full plot area.");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 80) { StartPosition = 0, EndPosition = 0.45, TextColor = OxyColors.Red });
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10) { StartPosition = 0, EndPosition = 0.45, TextColor = OxyColors.Green });
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 80) { StartPosition = 0.55, EndPosition = 1, TextColor = OxyColors.Blue });
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10) { StartPosition = 0.55, EndPosition = 1, TextColor = OxyColors.Orange });

            model.Annotations.Add(new LineAnnotation { ClipByYAxis = true, Type = LineAnnotationType.Vertical, X = 0, Color = OxyColors.Green, Text = "Vertical, ClipByAxis = true" });
            model.Annotations.Add(new LineAnnotation { ClipByYAxis = false, Type = LineAnnotationType.Vertical, X = 20, Color = OxyColors.Green, Text = "Vertical, ClipByAxis = false" });
            model.Annotations.Add(new LineAnnotation { ClipByXAxis = true, Type = LineAnnotationType.Horizontal, Y = 2, Color = OxyColors.Gold, Text = "Horizontal, ClipByAxis = true" });
            model.Annotations.Add(new LineAnnotation { ClipByXAxis = false, Type = LineAnnotationType.Horizontal, Y = 8, Color = OxyColors.Gold, Text = "Horizontal, ClipByAxis = false" });
//			model.DefaultFontSize = 30d;
//			model.LegendFontSize = 30d;
//			model.SubtitleFontSize = 30d;
//			model.TitleFontSize = 30d;
            return model;
        }

        [Example("ArrowAnnotations")]
        public static PlotModel ArrowAnnotations()
        {
            var model = new PlotModel("ArrowAnnotations");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -40, 60));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10));
            model.Annotations.Add(new ArrowAnnotation { StartPoint = new DataPoint(8, 4), EndPoint = new DataPoint(0, 0), Color = OxyColors.Green, Text = "StartPoint and EndPoint" });
            model.Annotations.Add(new ArrowAnnotation { ArrowDirection = new ScreenVector(30, 70), EndPoint = new DataPoint(40, -3), Color = OxyColors.Blue, Text = "ArrowDirection and EndPoint" });
            model.Annotations.Add(new ArrowAnnotation { ArrowDirection = new ScreenVector(30, -70), EndPoint = new DataPoint(10, -3), HeadLength = 14, HeadWidth = 6, Veeness = 4, Color = OxyColors.Red, Text = "HeadLength = 20, HeadWidth = 10, Veeness = 4" });
//			model.DefaultFontSize = 30d;
//			model.LegendFontSize = 30d;
//			model.SubtitleFontSize = 30d;
//			model.TitleFontSize = 30d;
            return model;
        }

        [Example("PolygonAnnotations")]
        public static PlotModel PolygonAnnotations()
        {
            var model = new PlotModel("PolygonAnnotations");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 20));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10));
            model.Annotations.Add(new PolygonAnnotation { Points = new[] { new DataPoint(4, -2), new DataPoint(8, -4), new DataPoint(17, 7), new DataPoint(5, 8), new DataPoint(2, 5) }, Text = "Polygon 1" });
//			model.DefaultFontSize = 30d;
//			model.LegendFontSize = 30d;
//			model.SubtitleFontSize = 30d;
//			model.TitleFontSize = 30d;
            return model;
        }

        [Example("Annotation Layers")]
        public static PlotModel AnnotationLayers()
        {
            var model = new PlotModel("Annotation Layers");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 30) { MajorGridlineStyle = LineStyle.Solid, MajorGridlineThickness = 1 });
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10) { MajorGridlineStyle = LineStyle.Solid, MajorGridlineThickness = 1 });

            model.Annotations.Add(new PolygonAnnotation { Layer = AnnotationLayer.BelowAxes, Points = new[] { new DataPoint(-11, -2), new DataPoint(-7, -4), new DataPoint(-3, 7), new DataPoint(-10, 8), new DataPoint(-13, 5) }, Text = "Layer = BelowAxes" });
            model.Annotations.Add(new PolygonAnnotation { Layer = AnnotationLayer.BelowSeries, Points = new[] { new DataPoint(4, -2), new DataPoint(8, -4), new DataPoint(12, 7), new DataPoint(5, 8), new DataPoint(2, 5) }, Text = "Layer = BelowSeries" });
            model.Annotations.Add(new PolygonAnnotation { Layer = AnnotationLayer.AboveSeries, Points = new[] { new DataPoint(19, -2), new DataPoint(23, -4), new DataPoint(27, 7), new DataPoint(20, 8), new DataPoint(17, 5) }, Text = "Layer = AboveSeries" });

            model.Series.Add(new FunctionSeries(Math.Sin, -20, 30, 400));
//			model.DefaultFontSize = 30d;
//			model.LegendFontSize = 30d;
//			model.SubtitleFontSize = 30d;
//			model.TitleFontSize = 30d;
            return model;
        }

        [Example("TextAnnotations")]
        public static PlotModel TextAnnotations()
        {
            var model = new PlotModel("TextAnnotations");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 20));
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10));
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(-6, 2), Text = "Text annotation 1" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(-7, 6), Rotation = 60, Text = "Text annotation 2" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(2, 2), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Right, VerticalAlignment = VerticalTextAlign.Top, Text = "Right/Top" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(2, 4), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Right, VerticalAlignment = VerticalTextAlign.Middle, Text = "Right/Middle" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(2, 6), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Right, VerticalAlignment = VerticalTextAlign.Bottom, Text = "Right/Bottom" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(6, 2), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Center, VerticalAlignment = VerticalTextAlign.Top, Text = "Center/Top" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(6, 4), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Center, VerticalAlignment = VerticalTextAlign.Middle, Text = "Center/Middle" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(6, 6), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Center, VerticalAlignment = VerticalTextAlign.Bottom, Text = "Center/Bottom" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(10, 2), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Left, VerticalAlignment = VerticalTextAlign.Top, Text = "Left/Top" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(10, 4), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Left, VerticalAlignment = VerticalTextAlign.Middle, Text = "Left/Middle" });
            model.Annotations.Add(new TextAnnotation { Position = new DataPoint(10, 6), Rotation = 20, HorizontalAlignment = HorizontalTextAlign.Left, VerticalAlignment = VerticalTextAlign.Bottom, Text = "Left/Bottom" });

            double d = 0.05;

            Action<double, double> addPoint = (x, y) => model.Annotations.Add(
                new PolygonAnnotation
                    {
                        Layer = AnnotationLayer.BelowAxes,
                        Points =
                            new[]
                                {
                                    new DataPoint(x-d, y-d), new DataPoint(x+d, y-d), new DataPoint(x+d, y+d),
                                    new DataPoint(x-d,y+d), new DataPoint(x-d,y-d)
                                }
                    });

            addPoint(-6, 2);
            addPoint(-7, 6);
            addPoint(2, 2);
            addPoint(2, 4);
            addPoint(2, 6);
            addPoint(6, 2);
            addPoint(6, 4);
            addPoint(6, 6);
            addPoint(10, 2);
            addPoint(10, 4);
            addPoint(10, 6);
//			model.DefaultFontSize = 15d;
//			model.LegendFontSize = 15d;
//			model.SubtitleFontSize = 15d;
//			model.TitleFontSize = 15d;
            return model;
        }

        [Example("Annotations on reversed axes")]
        public static PlotModel ReversedAxes()
        {
            var model = new PlotModel("Annotations on reversed axes");
            model.Axes.Add(new LinearAxis(AxisPosition.Bottom, -20, 80) { StartPosition = 1, EndPosition = 0 });
            model.Axes.Add(new LinearAxis(AxisPosition.Left, -10, 10) { StartPosition = 1, EndPosition = 0 });
            model.Annotations.Add(new LineAnnotation { Slope = 0.1, Intercept = 1, Text = "First", TextHorizontalAlignment = HorizontalTextAlign.Left });
            model.Annotations.Add(new LineAnnotation { Slope = 0.3, Intercept = 2, MaximumX = 40, Color = OxyColors.Red, Text = "Second", TextHorizontalAlignment = HorizontalTextAlign.Left, TextVerticalAlignment = VerticalTextAlign.Bottom });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 4, MaximumY = 10, Color = OxyColors.Green, Text = "Vertical", TextHorizontalAlignment = HorizontalTextAlign.Right });
            model.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Horizontal, Y = 2, MaximumX = 4, Color = OxyColors.Gold, Text = "Horizontal", TextHorizontalAlignment = HorizontalTextAlign.Left });
//			model.DefaultFontSize = 30d;
//			model.LegendFontSize = 30d;
//			model.SubtitleFontSize = 30d;
//			model.TitleFontSize = 30d;
            return model;
        }
    }
}
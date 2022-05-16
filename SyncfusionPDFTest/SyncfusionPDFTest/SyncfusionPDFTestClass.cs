using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.IO;

namespace SyncfusionPDFTest
{
    public class SyncfusionPDFTestClass
    {
        private readonly System.Drawing.Color COLOR_STROKE_BLUE = System.Drawing.Color.FromArgb(88, 151, 203);
        private readonly System.Drawing.Color COLOR_LIGHT_GRAY = System.Drawing.Color.FromArgb(240, 240, 240);
        private readonly System.Drawing.Color COLOR_DARK_GRAY = System.Drawing.Color.FromArgb(163, 163, 163);

        public byte[] CreatePDFWithCharts(PdfDocument pdfDoc)
        {
            using (var mem = new MemoryStream())
            {
                try
                {
                    var data = new List<float?>() {
                        1.1f,
                        1.2f,
                        1.3f,
                        1.2f,
                        1.35f,
                        1.5f,
                        1.4f,
                        1.3f,
                        1.2f,
                        1f,
                        1.1f,
                        1.2f,
                        1.3f,
                        1.2f,
                        1.35f,
                        1.5f,
                        1.4f,
                        1.3f,
                        1.2f,
                        1f,
                        1.1f,
                        1.2f,
                        1.3f,
                        1.2f,
                        1.35f,
                        1.5f,
                        1.4f,
                        1.3f,
                        1.2f,
                        1f,
                    };
                    var chart = CreateChart(data);
                    var page = pdfDoc.Pages.Add();
                    page.Graphics.DrawImage(PdfImage.FromStream(chart.GetStream()), new PointF(10, 30));
                    pdfDoc.Save(mem);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
                finally
                {
                    pdfDoc.Close(true);
                }
                return mem.ToArray();
            }
        }

        private SfChart CreateChart(List<float?> data)
        {
            var chart = new SfChart
            {
                PrimaryAxis = new DateTimeAxis()
                {
                    EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Fit,
                    RangePadding = DateTimeRangePadding.None,
                    LabelStyle = new ChartAxisLabelStyle() { LabelFormat = "g", TextColor = COLOR_DARK_GRAY, FontSize = 6 },
                    MajorTickStyle = { TickSize = 0 },
                    MajorGridLineStyle = { StrokeColor = COLOR_LIGHT_GRAY },
                    AxisLineStyle = { StrokeColor = COLOR_LIGHT_GRAY, StrokeWidth = 0.5 },
                },
                SecondaryAxis = new NumericalAxis()
                {
                    RangePadding = NumericalPadding.Additional,
                    AxisLineStyle = { StrokeColor = COLOR_LIGHT_GRAY, StrokeWidth = 0.5 },
                    ShowMajorGridLines = false,
                    ShowMinorGridLines = false,
                    MajorTickStyle = { TickSize = 0 },
                    LabelStyle = new ChartAxisLabelStyle() { TextColor = COLOR_DARK_GRAY, FontSize = 6 },

                }
            };
            chart.Series.Add(new LineSeries
            {
                ItemsSource = CreateChartPointsFromData(data),
                StrokeWidth = 1.0,
                Color = COLOR_STROKE_BLUE
            });

            return chart;

        }

        private List<ChartDataPoint> CreateChartPointsFromData(List<float?> data)
        {
            var source = new List<ChartDataPoint>();
            var xPosition = 0;
            foreach (var val in data)
            {
                source.Add(new ChartDataPoint(xPosition, val ?? double.NaN));
                xPosition++;
            }
            return source;
        }
    }
}

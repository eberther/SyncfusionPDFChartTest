using NUnit.Framework;
using Syncfusion.Pdf;
using SyncfusionPDFTest;
using System;
using System.IO;

namespace SyncfusionPDFTests
{
    public class Tests
    {
        SyncfusionPDFTestClass _testee;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            _testee = new SyncfusionPDFTestClass();

            if (!Directory.Exists("testing\\pdfchart"))
            {
                Directory.CreateDirectory("testing\\pdfchart");
            }
            var path = Path.Combine("testing\\pdfchart", $"ChartPDF{DateTime.Now.ToFileTime()}.pdf");

            var documentBytes = _testee.CreatePDFWithCharts(new PdfDocument());

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(documentBytes);
                Assert.True(File.Exists(path));
                Assert.IsNotNull(documentBytes);
                Assert.IsNotEmpty(documentBytes);
            }

            Assert.Pass();
        }
    }
}
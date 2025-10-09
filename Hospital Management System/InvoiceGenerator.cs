using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Hospital_Management_System
{
    internal class InvoiceGenerator
    {
        public static void GenerateInvoice(InvoiceData data, string filePath)
        {
            if (data == null || data.Items == null) return;

            using (var document = new Document(PageSize.A4, 36, 36, 54, 36)) // Margins: left, right, top, bottom
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // ### FONTS & COLORS ###
                    var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    var titleFont = new Font(baseFont, 24, Font.BOLD, BaseColor.BLACK);
                    var headerFont = new Font(baseFont, 10, Font.BOLD, BaseColor.WHITE);
                    var subHeaderFont = new Font(baseFont, 12, Font.BOLD);
                    var normalFont = new Font(baseFont, 10);
                    var boldFont = new Font(baseFont, 10, Font.BOLD);
                    var totalFont = new Font(baseFont, 12, Font.BOLD);
                    var primaryColor = new BaseColor(66, 139, 202);
                    var lightGray = new BaseColor(240, 240, 240);

                    // ### 1. HEADER SECTION ###
                    var headerTable = new PdfPTable(2) { WidthPercentage = 100 };
                    headerTable.SetWidths(new float[] { 70f, 30f });
                    headerTable.DefaultCell.Border = Rectangle.NO_BORDER;

                    // --- Pharmacy Info & Logo ---
                    var pharmacyCell = new PdfPCell { Border = Rectangle.NO_BORDER };
                    // Uncomment and set your logo path
                    // Image logo = Image.GetInstance("path/to/your/logo.png");
                    // logo.ScaleToFit(120f, 60f);
                    // pharmacyCell.AddElement(logo);
                    pharmacyCell.AddElement(new Paragraph("Snowdrop Pharmacy", new Font(baseFont, 16, Font.BOLD)));
                    pharmacyCell.AddElement(new Paragraph("Basundhara Block C, Dhaka, 1205", normalFont));
                    pharmacyCell.AddElement(new Paragraph("info@gmail.com | +880 123 456 7890", normalFont));
                    headerTable.AddCell(pharmacyCell);

                    // --- Invoice Title ---
                    var titleCell = new PdfPCell(new Paragraph("INVOICE", titleFont))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    headerTable.AddCell(titleCell);
                    document.Add(headerTable);

                    // ### 2. CUSTOMER & INVOICE DETAILS ###
                    document.Add(new Paragraph(" "));
                    var infoTable = new PdfPTable(2) { WidthPercentage = 100 };
                    infoTable.SetWidths(new float[] { 50f, 50f });
                    infoTable.DefaultCell.Border = Rectangle.NO_BORDER;

                    // --- Billed To Section ---
                    var billedToCell = new PdfPCell { Border = Rectangle.NO_BORDER };
                    billedToCell.AddElement(new Paragraph("BILLED TO", subHeaderFont));
                    billedToCell.AddElement(new Paragraph(data.CustomerName ?? "", normalFont));
                    billedToCell.AddElement(new Paragraph(data.CustomerContact ?? "", normalFont));
                    infoTable.AddCell(billedToCell);

                    // --- Invoice # & Date Section ---
                    var invoiceDetailsCell = new PdfPCell { Border = Rectangle.NO_BORDER, PaddingLeft = 20 };
                    var detailsPara = new Paragraph();
                    detailsPara.Add(new Chunk("Invoice ID: ", boldFont));
                    detailsPara.Add(new Chunk("#"+data.InvoiceId.ToString(), normalFont));
                    detailsPara.Add(Chunk.NEWLINE);
                    detailsPara.Add(new Chunk("Date of Issue: ", boldFont));
                    detailsPara.Add(new Chunk(DateTime.Now.ToString("dd MMM, yyyy"), normalFont));
                    invoiceDetailsCell.AddElement(detailsPara);
                    infoTable.AddCell(invoiceDetailsCell);
                    document.Add(infoTable);

                    // ### 3. ITEMS TABLE ###
                    document.Add(new Paragraph(" ") { SpacingBefore = 20f });
                    var itemsTable = new PdfPTable(5) { WidthPercentage = 100 };
                    itemsTable.SetWidths(new float[] { 1f, 5f, 2f, 2f, 2.5f });

                    // --- Table Headers ---
                    var headers = new[] { "NO.", "DRUG NAME", "PRICE PER UNIT", "QUANTITY", "PRICE" };
                    foreach (var header in headers)
                    {
                        var cell = new PdfPCell(new Phrase(header, headerFont))
                        {
                            BackgroundColor = primaryColor,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 8,
                            Border = Rectangle.NO_BORDER
                        };
                        itemsTable.AddCell(cell);
                    }

                    // --- Table Body ---
                    for (int i = 0; i < data.Items.Count; i++)
                    {
                        var item = data.Items[i];
                        var rowColor = (i % 2 == 0) ? BaseColor.WHITE : lightGray;

                        itemsTable.AddCell(CreateCell((i + 1).ToString(), normalFont, Element.ALIGN_CENTER, rowColor));
                        itemsTable.AddCell(CreateCell(item.DrugName ?? "", normalFont, Element.ALIGN_LEFT, rowColor));
                        itemsTable.AddCell(CreateCell(item.PricePerUnit.ToString("N2", CultureInfo.InvariantCulture), normalFont, Element.ALIGN_RIGHT, rowColor));
                        itemsTable.AddCell(CreateCell(item.Quantity.ToString(CultureInfo.InvariantCulture), normalFont, Element.ALIGN_CENTER, rowColor));
                        itemsTable.AddCell(CreateCell(item.TotalPrice.ToString("N2", CultureInfo.InvariantCulture), normalFont, Element.ALIGN_RIGHT, rowColor));
                    }
                    document.Add(itemsTable);

                    // ### 4. TOTALS SECTION ###
                    var culture = new CultureInfo("en-BD");

                    var totalsTable = new PdfPTable(2) { WidthPercentage = 40, HorizontalAlignment = Element.ALIGN_RIGHT };
                    totalsTable.SetWidths(new float[] { 5f, 5f });
                    totalsTable.DefaultCell.Border = Rectangle.NO_BORDER;
                    totalsTable.SpacingBefore = 20f;

                    totalsTable.AddCell(CreateTotalCell("Subtotal:", boldFont, Element.ALIGN_RIGHT));
                    totalsTable.AddCell(CreateTotalCell($"৳ {data.Subtotal:N2}", normalFont, Element.ALIGN_RIGHT));

                    totalsTable.AddCell(CreateTotalCell($"Discount:", boldFont, Element.ALIGN_RIGHT));
                    totalsTable.AddCell(CreateTotalCell($"৳ {data.Discount:N2}", normalFont, Element.ALIGN_RIGHT));

                    var totalLabelCell = new PdfPCell(new Phrase("TOTAL", totalFont))
                    {
                        Border = Rectangle.TOP_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Padding = 8,
                        BorderWidthTop = 1.5f,
                        BorderColorTop = primaryColor
                    };
                    var totalValueCell = new PdfPCell(new Phrase($"৳ {data.Total:N2}", totalFont))
                    {
                        Border = Rectangle.TOP_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Padding = 8,
                        BorderWidthTop = 1.5f,
                        BorderColorTop = primaryColor
                    };
                    totalsTable.AddCell(totalLabelCell);
                    totalsTable.AddCell(totalValueCell);

                    document.Add(totalsTable);

                    // ### 5. FOOTER SECTION ###
                    document.Add(new Paragraph(" ") { SpacingBefore = 30f });
                    document.Add(new LineSeparator(0.5f, 100, BaseColor.GRAY, Element.ALIGN_CENTER, -1));
                    var thankYouPara = new Paragraph("Thank you for your business!", new Font(baseFont, 10, Font.ITALIC, BaseColor.GRAY))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingBefore = 10f
                    };
                    document.Add(thankYouPara);

                    document.Close();
                }
            }

            // Open the file
            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not open the file. Error: {ex.Message}");
            }
        }

        // Helper method to create styled table cells
        private static PdfPCell CreateCell(string text, Font font, int alignment, BaseColor backgroundColor)
        {
            return new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = alignment,
                BackgroundColor = backgroundColor,
                Padding = 8,
                Border = Rectangle.NO_BORDER
            };
        }

        // Helper method for totals section
        private static PdfPCell CreateTotalCell(string text, Font font, int alignment)
        {
            return new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = alignment,
                Border = Rectangle.NO_BORDER,
                PaddingTop = 4,
                PaddingBottom = 4
            };
        }
    }

    public class InvoiceItem
    {
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }
    }

    public class InvoiceData
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public double Subtotal { get; set; }
        public double Discount { get; set; } 
        public double Total { get; set; }
    }
}

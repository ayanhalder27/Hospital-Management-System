using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    public static class InvoiceService
    {
        // Generate invoice at the full file path chosen by user
        public static string GenerateInvoicePdf(int billId, string patientName, string doctorName, decimal amount, string paymentMethod, decimal paidAmount, decimal changeAmount, DateTime billDate, string filePath)
        {
            string folder = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var doc = new Document(PageSize.A4, 36, 36, 36, 36);
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var normal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                doc.Add(new Paragraph("Hospital Name", titleFont));
                doc.Add(new Paragraph("Address line 1", normal));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Bill ID: {billId}", normal));
                doc.Add(new Paragraph($"Bill Date: {billDate:yyyy-MM-dd HH:mm}", normal));
                doc.Add(new Paragraph($"Patient: {patientName}", normal));
                doc.Add(new Paragraph($"Doctor: {doctorName}", normal));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Doctor Visit Fee: {amount:C2}", normal));
                doc.Add(new Paragraph($"Payment Method: {paymentMethod}", normal));
                doc.Add(new Paragraph($"Paid Amount: {paidAmount:C2}", normal));
                doc.Add(new Paragraph($"Change: {changeAmount:C2}", normal));
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph("Thank you.", normal));

                doc.Close();
                writer.Close();
            }

            return filePath;
        }
    }
}

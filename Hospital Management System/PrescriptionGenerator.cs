using Hospital_Management_System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

/// <summary>
/// Main class to generate the prescription PDF.
/// </summary>
public class PrescriptionGenerator
{
    /// <summary>
    /// Creates and opens the prescription PDF file on the user's desktop.
    /// </summary>
    public static Font fontSectionHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
    public static Font fontListItem = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
    public static void CreatePrescription(int prescriptionID, string patientName, string patientAge, string patientSex, List testList, System.Collections.Generic.List<string> medicineList)
    {
        // Set document margins: Left, Right, Top, Bottom.
        Document doc = new Document(PageSize.A4, 36, 36, 110, 50);

        string fileName = "#" + prescriptionID + "." + patientName + "." + DateTime.Now.ToString("dd-mm-yyyy") + ".pdf";
        string filepath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName, "Documents", fileName);

        try
        {
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));

            // Assign our custom class to handle page events (header and footer).
            writer.PageEvent = new PrescriptionPageEvents();

            doc.Open();

            // --- 1. PATIENT AND DIAGNOSIS DATA ---
            string diagnosis = "Acute Viral Pharyngitis";
            string prescriptionDate = DateTime.Now.ToString("dd, MMMM yyyy");

            // --- 2. ADD PATIENT INFORMATION SECTION ---
            PdfPTable patientInfoTable = new PdfPTable(4);
            patientInfoTable.WidthPercentage = 100;
            patientInfoTable.SetWidths(new float[] { 1.5f, 5f, 1.2f, 3f });
            patientInfoTable.SpacingBefore = 10f;

            patientInfoTable.AddCell(CreateLabelCell("Patient Name:"));
            patientInfoTable.AddCell(CreateValueCell(patientName));
            patientInfoTable.AddCell(CreateLabelCell("Date:"));
            patientInfoTable.AddCell(CreateValueCell(prescriptionDate));
            patientInfoTable.AddCell(CreateLabelCell("Age:"));
            patientInfoTable.AddCell(CreateValueCell(patientAge));
            patientInfoTable.AddCell(CreateLabelCell("Gender:"));
            patientInfoTable.AddCell(CreateValueCell(patientSex));
            PdfPCell diagnosisLabelCell = CreateLabelCell("Diagnosis:");
            PdfPCell diagnosisValueCell = CreateValueCell(diagnosis);
            diagnosisValueCell.Colspan = 3;
            patientInfoTable.AddCell(diagnosisLabelCell);
            patientInfoTable.AddCell(diagnosisValueCell);

            doc.Add(patientInfoTable);

            Paragraph testHeader = new Paragraph("Lab Tests Recommended", fontSectionHeader)
            {
                SpacingBefore = 15f,
                SpacingAfter = 8f,
                IndentationLeft = 5f
            };
            doc.Add(testHeader);

            doc.Add(testList);

            // --- 4. ADD MAIN CONTENT AREA & SIGNATURE ---
            PdfPTable mainContentTable = new PdfPTable(1);
            mainContentTable.WidthPercentage = 100;
            mainContentTable.SpacingBefore = 5f; // Small space before Rx

            // Cell 1: Rx Symbol and Writing Space
            Font fontRx = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 36, BaseColor.BLACK);
            Font fontAdvice = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);

            Paragraph rxSymbol = new Paragraph("Rx", fontRx) { IndentationLeft = 10f };

            PdfPCell contentCell = new PdfPCell();
            contentCell.Border = Rectangle.NO_BORDER;
            contentCell.AddElement(rxSymbol);

            // Adding medication details
            //contentCell.AddElement(new Paragraph("1. Tab. Napa Extend (Paracetamol 665mg)", fontListItem) { IndentationLeft = 20f });
            //contentCell.AddElement(new Paragraph("     1 + 0 + 1 (after meal) - 5 days", fontListItem) { IndentationLeft = 25f });
            //contentCell.AddElement(new Paragraph(" "));
            //contentCell.AddElement(new Paragraph("2. Tab. Fexo (Fexofenadine 120mg)", fontListItem) { IndentationLeft = 20f });
            //contentCell.AddElement(new Paragraph("     0 + 0 + 1 - 7 days", fontListItem) { IndentationLeft = 25f });
            //contentCell.AddElement(new Paragraph(" "));
            //contentCell.AddElement(new Paragraph("3. Adryl Lozenges (for sucking)", fontListItem) { IndentationLeft = 20f });
            //contentCell.AddElement(new Paragraph("     1 lozenge 4 times daily", fontListItem) { IndentationLeft = 25f });
            //contentCell.AddElement(new Paragraph(" ") { SpacingBefore = 20f });

            for (int i = 0; i < medicineList.Count; i++)
            {
                string[] medicine = medicineList[i].Split('~');
                contentCell.AddElement(new Paragraph((i + 1) + ". " + medicine[1] + " " + medicine[0], fontListItem) { IndentationLeft = 20f });
                contentCell.AddElement(new Paragraph(medicine[2] + " (" + medicine[3] + ") - " + medicine[4], fontListItem) { IndentationLeft = 25f });
                contentCell.AddElement(new Paragraph(" "));
            }

            // Adding advice using a List
            contentCell.AddElement(new Paragraph("Advice:", fontAdvice) { IndentationLeft = 20f });
            //List adviceList = new List(List.UNORDERED, 10f);
            //adviceList.SetListSymbol("•");
            //adviceList.IndentationLeft = 30f;
            //adviceList.Add(new ListItem(" Gargle with lukewarm salt water 3-4 times a day.", fontListItem));
            //adviceList.Add(new ListItem(" Drink plenty of warm fluids.", fontListItem));
            //adviceList.Add(new ListItem(" Take complete rest.", fontListItem));
            //contentCell.AddElement(adviceList);

            mainContentTable.AddCell(contentCell);

            // Cell 2: Signature
            Font fontLabel = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);
            Paragraph line = new Paragraph("_________________________");
            Paragraph sigText = new Paragraph("Signature", fontLabel);
            PdfPCell signatureCell = new PdfPCell
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                VerticalAlignment = Element.ALIGN_BOTTOM,
                MinimumHeight = 100f // Adjust height to ensure it fits
            };
            signatureCell.AddElement(line);
            signatureCell.AddElement(sigText);
            mainContentTable.AddCell(signatureCell);

            doc.Add(mainContentTable);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error creating PDF: " + ex.Message);
        }
        finally
        {
            if (doc.IsOpen()) doc.Close();
        }

        try
        {
            Process.Start(new ProcessStartInfo(filepath) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Could not open PDF. Error: " + ex.Message);
        }
    }

    // --- HELPER METHODS ---
    private static PdfPCell CreateLabelCell(string text)
    {
        Font fontLabel = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, BaseColor.DARK_GRAY);
        PdfPCell cell = new PdfPCell(new Phrase(text, fontLabel))
        {
            Border = Rectangle.NO_BORDER,
            HorizontalAlignment = Element.ALIGN_LEFT,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            PaddingBottom = 10
        };
        return cell;
    }

    private static PdfPCell CreateValueCell(string text)
    {
        Font fontValue = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
        PdfPCell cell = new PdfPCell(new Phrase(text, fontValue))
        {
            Border = Rectangle.BOTTOM_BORDER,
            BorderColor = BaseColor.LIGHT_GRAY,
            BorderWidthBottom = 1f,
            HorizontalAlignment = Element.ALIGN_LEFT,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            PaddingBottom = 10
        };
        return cell;
    }
}

/// <summary>
/// Handles drawing the fixed header and footer on each page of the PDF.
/// </summary>
public class PrescriptionPageEvents : PdfPageEventHelper
{
    private readonly Font fontHeaderLarge = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.WHITE);
    private readonly Font fontHeaderSmall = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.WHITE);
    private readonly Font fontFooter = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
    private readonly BaseColor headerColor = new BaseColor(46, 179, 179);
    private readonly BaseColor footerColor = new BaseColor(240, 240, 240);


    public override void OnEndPage(PdfWriter writer, Document document)
    {
        // === DRAW HEADER ===
        PdfPTable headerTable = new PdfPTable(2);
        headerTable.TotalWidth = document.PageSize.Width;
        headerTable.LockedWidth = true;
        headerTable.SetWidths(new float[] { 8, 2 });

        PdfPCell textCell = new PdfPCell { BackgroundColor = headerColor, Border = Rectangle.NO_BORDER, PaddingLeft = 20, PaddingTop = 15, PaddingBottom = 15 };
        HospitalContext db = new HospitalContext();
        var doctor = db.Users.Where(u=> u.UserID == Login_form.userID).Select(u => new { u.FullName, u.Specialization, u.PhoneNumber, u.Email }).FirstOrDefault();
        //var doctor = db.Users.Where(u=> u.UserID == 1027).Select(u => new { u.FullName, u.Specialization, u.PhoneNumber, u.Email }).FirstOrDefault();
        textCell.AddElement(new Phrase(doctor.FullName, fontHeaderLarge));
        textCell.AddElement(new Phrase(doctor.Specialization, fontHeaderSmall));
        textCell.AddElement(new Phrase(doctor.PhoneNumber, fontHeaderSmall));
        textCell.AddElement(new Phrase(doctor.Email, fontHeaderSmall));
        headerTable.AddCell(textCell);

        PdfPCell iconCell = new PdfPCell { BackgroundColor = headerColor, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE };
        try
        {
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "stethoscope.png");
            if (File.Exists(iconPath))
            {
                Image icon = Image.GetInstance(iconPath);
                icon.ScaleToFit(50f, 50f);
                iconCell.AddElement(icon);
            }
        }
        catch (Exception ex) { Debug.WriteLine("Icon error: " + ex.Message); }
        headerTable.AddCell(iconCell);

        headerTable.WriteSelectedRows(0, -1, 0, document.PageSize.Height, writer.DirectContent);

        // === DRAW FOOTER ===
        PdfPTable footerTable = new PdfPTable(3);
        footerTable.TotalWidth = document.PageSize.Width;
        footerTable.LockedWidth = true;

        PdfPCell clinicCell = new PdfPCell(new Phrase("XYZ Clinic", fontFooter))
        { BackgroundColor = footerColor, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingLeft = 20, FixedHeight = 40 };
        PdfPCell addressCell = new PdfPCell(new Phrase("📍 Basundhara, Dhaka", fontFooter))
        { BackgroundColor = footerColor, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, FixedHeight = 40 };
        PdfPCell phoneCell = new PdfPCell(new Phrase("📞 +880611237016", fontFooter))
        { BackgroundColor = footerColor, Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE, PaddingRight = 20, FixedHeight = 40 };

        footerTable.AddCell(clinicCell);
        footerTable.AddCell(addressCell);
        footerTable.AddCell(phoneCell);

        footerTable.WriteSelectedRows(0, -1, 0, 40, writer.DirectContent);
    }
}
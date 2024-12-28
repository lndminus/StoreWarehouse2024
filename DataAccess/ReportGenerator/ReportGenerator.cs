using DataAccess.Entities;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ReportGenerator
{
    public class ReportGenerator
    {
        public bool GenerateReport(Report report, string path)
        {
            if (Directory.Exists(path))
            {
                //@"C:\WordReports\Файл.docx"
                string time = string.Format("{0:dd.MM.yyyy}{0:-HH.mm.ss}", report.ReportTime);
                string resultPath = path + "Звіт" + time + ".docx";
                using (WordprocessingDocument document = WordprocessingDocument.Create(resultPath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = document.AddMainDocumentPart();
                    mainPart.Document = new Document();

                    Paragraph paragraph = new Paragraph();
                    string reportType;
                    if (report.IsDelivery)
                    {
                        reportType = "Про видачу товару";
                    }
                    else
                    {
                        reportType = "Про прийом товару";
                    }

                    Run row1 = new Run(new Text("Звіт:              " + reportType));
                    Run break1 = new Run(new Break());
                    Run row2 = new Run(new Text("Товар:             " + report.WarehouseItem.Name));
                    Run break2 = new Run(new Break());
                    Run row3 = new Run(new Text("Кількість          " + report.Quantity + " " + report.WarehouseItem.Unit));
                    Run break3 = new Run(new Break());
                    Run row4 = new Run(new Text("Загальна ціна:     " + report.Price + " грн."));
                    Run break4 = new Run(new Break());
                    Run row5 = new Run(new Text("Час оформлення:    " + report.ReportTime));
                    Run break5 = new Run(new Break());
                    Run row6 = new Run(new Text("Оформлював:        " + report.User.Name + " " + report.User.LastName));
                    paragraph.Append(row1, break1, row2, break2, row3, break3, row4, break4, row5, break5, row6);

                    Body body = mainPart.Document.AppendChild(new Body());
                    body.Append(paragraph);

                    mainPart.Document.Save();
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Data.Common;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PDF_Gen.Services
{
    public interface IPdfService
    {
        Task GenerateSamplePdf();
    }

    public class PdfService : IPdfService
    {
        public async Task GenerateSamplePdf()
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(100); // Adjust the width as needed
                            columns.RelativeColumn(); // Adjust the relative size as needed
                        });

                        // First Column
                        


                        table.Cell().Row(1).Column(1).RowSpan(1).Height(140).Text(text =>
                        {
                            text.AlignCenter();
                            text.Line("Dr. Weder, Kauta & Hoveka Inc. ");
                            text.Line("2").FontSize(20);
                            text.Line("Tel. 275550").FontSize(13);
                        });

                        table.Cell().Row(2).Column(1).RowSpan(8).Height(400).Element(container =>
                        {
                            container
                                .Padding(20) // Adjust padding as needed
                                .RotateLeft() // Rotate content 90 degrees counterclockwise
                                .Text(text =>
                                {
                                    text.Span("Erf No 20304 Goreangab(Ext No.1)").FontSize(20);
                                });
                                 // Adjust font size as needed
                        });


                        // Second Column
                        table.Cell().Row(1).Column(2).Height(140).PaddingRight(5).Column(column =>
                        {
                            column.Item().Text(text =>
                            {
                                text.AlignCenter();
                                text.Line("Execution");
                            });

                            column.Item().Text(text =>
                            {
                                text.AlignLeft();
                                text.Span("Date of lodgement");
                            });

                            column.Item().Border(1).BorderColor(Colors.Black).PaddingVertical(10).Text(text =>
                            {
                                text.AlignCenter();
                                text.Line("01 May 2024");
                            });
                        });
                        //A. FOR DEEDS OFFICE USE
                        table.Cell().Row(2).Column(2).Border(1).BorderColor(Colors.Black).PaddingRight(5).Column(column =>
                        {
                            // Top item
                            column.Item().Text(text =>
                            {
                                text.AlignLeft();
                                text.Line("A. FOR DEEDS OFFICE USE");
                            });

                            // Nested table for bottom items
                            column.Item().Table(innerTable =>
                            {
                                innerTable.ColumnsDefinition(innerColumns =>
                                {
                                    innerColumns.RelativeColumn();
                                    innerColumns.RelativeColumn();
                                });
                                innerTable.Cell().Border(1).BorderColor(Colors.Black).PaddingVertical(5).Element(container =>
                                {
                                    container
                                        .Column(stack =>
                                        {
                                            stack.Item().AlignCenter().Width(100).Height(50).Placeholder();
                                            stack.Item().AlignCenter().Text("T02/2024");
                                        });
                                });
                                innerTable.Cell().Border(1).BorderColor(Colors.Black).Text(text =>
                                {

                                });
                            });
                        });
                        // Start of Examiner Details
                        table.Cell().Row(3).Column(2).Border(1).BorderColor(Colors.Black).PaddingRight(5).Column(column =>
                        {
                            column.Item().Table(innerTable =>
                            {
                                innerTable.ColumnsDefinition(innerColumns =>
                                {
                                    innerColumns.RelativeColumn(); // Column 1
                                    innerColumns.RelativeColumn(); // Column 2
                                    innerColumns.RelativeColumn(); // Column 3
                                    innerColumns.RelativeColumn(); // Column 4
                                    innerColumns.RelativeColumn(); // Column 5
                                });

                                // Add cells to the new table with 5 columns
                                innerTable.Cell().Row(1).Column(1).Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    container.Column(column =>
                                    {
                                        column.Item().Text(text =>
                                        {
                                            text.Line("Examiner");
                                        });
                                        column.Item().Table(nestedTable =>
                                        {
                                            nestedTable.ColumnsDefinition(columns =>
                                            {
                                                columns.ConstantColumn(10); // Fixed width column
                                                columns.RelativeColumn();   // Flexible width column
                                            });

                                            // Add rows in the nested table
                                            nestedTable.Cell().Row(1).Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("1");
                                            });
                                            nestedTable.Cell().Row(2).Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("2");
                                            });
                                            nestedTable.Cell().Row(3).Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("3");
                                            });

                                            nestedTable.Cell().Row(1).Column(2).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("Examiner name");
                                            });
                                            nestedTable.Cell().Row(2).Column(2).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("Examiner name");
                                            });
                                            nestedTable.Cell().Row(3).Column(2).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("Examiner name");
                                            });
                                        });
                                    });
                                });
                                innerTable.Cell().Row(1).Column(2).Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    container.Column(column =>
                                    {
                                        column.Item().Text(text =>
                                        {
                                            text.Line("Rooms");
                                        });
                                        column.Item().Table(nestedTable =>
                                        {
                                            nestedTable.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn();  
                                            });
                                            // Add rows in the nested table
                                            nestedTable.Cell().Row(1).Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("Room 1");
                                            });
                                            nestedTable.Cell().Row(2).Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("Room 2");
                                            });
                                            nestedTable.Cell().Row(3).Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                innerContainer.AlignLeft().Text("Room 3");
                                            });
                                        });
                                    });
                                });
                                innerTable.Cell().Row(1).Column(3).Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    
                                });
                                innerTable.Cell().Row(1).Column(4).Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    container.Column(column =>
                                    {
                                        column.Item().Text(text =>
                                        {
                                            text.Line("Reject");
                                        });
                                        column.Item().Table(nestedTable =>
                                        {
                                            nestedTable.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn();
                                            });
                                            // Signature box
                                            nestedTable.Cell().Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {
                                                
                                            });
                                        });
                                    });
                                });
                                innerTable.Cell().Row(1).Column(5).Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    container.Column(column =>
                                    {
                                        column.Item().Text(text =>
                                        {
                                            text.Line("Pass");
                                        });
                                        column.Item().Table(nestedTable =>
                                        {
                                            nestedTable.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn();
                                            });
                                            // Signature box
                                            nestedTable.Cell().Column(1).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                            {

                                            });
                                        });
                                    });
                                });
                                /*innerTable.Cell().Row(2).Column(1).ColumnSpan(3).Element(container =>
                                {
                                    container.Row(row =>
                                    {
                                        row.RelativeItem().Column(column =>
                                        {
                                            column.Item().AlignLeft().Text("Nature of deed, e.g transfer, bond etc.");
                                        });
                                    });
                                });
                                innerTable.Cell().Row(3).Column(1).ColumnSpan(3).Element(container =>
                                {
                                    container.Row(row =>
                                    {
                                        row.RelativeItem().Column(column =>
                                        {
                                            column.Item().AlignLeft().Text("DEED OF TRANSFER");
                                        });
                                    });
                                });
                                innerTable.Cell().Row(2).Column(4).ColumnSpan(2).Element(container =>
                                {
                                    container.Row(row =>
                                    {
                                        row.RelativeItem().Column(column =>
                                        {
                                            column.Item().AlignLeft().Text("Stamp");
                                        });
                                    });
                                });*/
                            });
                        });// End of Examiner Details

                        table.Cell().Row(4).Column(2).Border(1).BorderColor(Colors.Black).PaddingRight(5).Column(column =>
                        {
                            // Nested table for bottom items
                            column.Item().Table(innerTable =>
                            {
                                innerTable.ColumnsDefinition(innerColumns =>
                                {
                                    innerColumns.RelativeColumn();
                                    innerColumns.RelativeColumn();
                                });
                                innerTable.Cell().Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    container
                                        .Column(stack =>
                                        {
                                            stack.Item().PaddingBottom(20).AlignLeft().Text("Nature of deed, e.g. transfer, bond etc.");
                                            stack.Item().AlignCenter().Text("DEED OF TRANSFER");
                                        });
                                });
                                innerTable.Cell().Border(1).BorderColor(Colors.Black).Element(container =>
                                {
                                    container.PaddingTop(10).AlignCenter().Width(80).Height(35).Placeholder();
                                });
                            });
                        });
                        table.Cell().Row(5).Column(2).Border(1).BorderColor(Colors.Black).PaddingRight(5).Column(column =>
                        {
                            column.Item().Text(text =>
                            {
                                text.Span("B. FOR CONVEYANCER'S USE:");
                            });
                        });
                        table.Cell().Row(6).Column(2).Border(1).BorderColor(Colors.Black).PaddingRight(5).Row(row =>
                        {
                            // First row
                            row.RelativeItem().Text(text =>
                            {
                                text.Line("Ref. No. :");
                                //ref box
                                text.Element(container =>
                                {
                                    container.Border(1).BorderColor(Colors.Black).Padding(20).Text("Ref: 2024/101582");
                                });
                            });

                            // Second row
                            row.RelativeItem().Column(column =>
                            {
                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Linking");
                                });

                                // Inner columns under Linking
                                column.Item().Row(row =>
                                {
                                    row.RelativeItem().Border(1).BorderColor(Colors.Black).Padding(20).AlignCenter().Text("3");
                                    row.RelativeItem().Border(1).BorderColor(Colors.Black).Padding(20).AlignCenter().Text("2");
                                });
                            });
                        });
                        table.Cell().Row(7).Column(2).Border(1).BorderColor(Colors.Black).PaddingRight(5).Row(row =>
                        {
                            row.RelativeItem(1).Border(1).BorderColor(Colors.Black).Column(column =>
                            {
                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Code");
                                });
                                column.Item().Table(nestedTable =>
                                {
                                    nestedTable.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    nestedTable.Cell().Row(1).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-1");
                                    });
                                    nestedTable.Cell().Row(2).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-2");
                                    });
                                    nestedTable.Cell().Row(3).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-3");
                                    });
                                });
                            });
                            row.RelativeItem(2).Border(1).BorderColor(Colors.Black).Column(column =>
                            {
                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Nature of transaction");
                                });
                                column.Item().Table(nestedTable =>
                                {
                                    nestedTable.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    nestedTable.Cell().Row(1).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-1");
                                    });
                                    nestedTable.Cell().Row(2).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-2");
                                    });
                                    nestedTable.Cell().Row(3).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-3");
                                    });
                                });
                            });
                            row.RelativeItem(1).Border(1).BorderColor(Colors.Black).Column(column =>
                            {
                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Firm No.");
                                });
                                column.Item().Table(nestedTable =>
                                {
                                    nestedTable.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    nestedTable.Cell().Row(1).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-1");
                                    });
                                    nestedTable.Cell().Row(2).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-2");
                                    });
                                    nestedTable.Cell().Row(3).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-3");
                                    });
                                });
                            });
                            row.RelativeItem(1).Border(1).BorderColor(Colors.Black).Column(column =>
                            {
                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("No. in batch");
                                });
                                column.Item().Table(nestedTable =>
                                {
                                    nestedTable.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    nestedTable.Cell().Row(1).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-1");
                                    });
                                    nestedTable.Cell().Row(2).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-2");
                                    });
                                    nestedTable.Cell().Row(3).Column(1).ColumnSpan(3).Border(1).BorderColor(Colors.Black).Element(innerContainer =>
                                    {
                                        innerContainer.AlignCenter().Text("Data 1-3");
                                    });
                                });
                            });
                            row.RelativeItem(2).Border(1).BorderColor(Colors.Black).Column(column =>
                            {//no additional rows needed.
                                column.Item().AlignCenter().Text(text =>
                                {
                                    text.Span("Titles within");
                                });
                            });
                        });
                    });
                });
            })
            .ShowInPreviewer();
        }
    }
}

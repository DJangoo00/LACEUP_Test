using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using FrontEnd.Models;

namespace FrontEnd.Services
{
    public class ExcelService
    {
        public async Task<(OrderModel order, List<ProductModel> products)> ReadExcelFile(Stream fileStream)
        {
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0; // Reset the position to the beginning of the stream
            
            using var package = new ExcelPackage(memoryStream);
            var worksheet = package.Workbook.Worksheets["Hoja1"];

            // Leer datos de la orden
            var order = new OrderModel();

            int day = worksheet.Cells[3, 1].GetValue<int>();
            int month = worksheet.Cells[3, 2].GetValue<int>();
            int year = worksheet.Cells[3, 3].GetValue<int>();

            try
            {
                order.createDate = new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                throw new FormatException($"The date with values Day: {day}, Month: {month}, Year: {year} was not recognized as a valid DateTime.", ex);
            }

            order.itemCount = worksheet.Cells[3, 4].GetValue<int>();
            order.totalPrice = worksheet.Cells[3, 5].GetValue<int>();
            order.customerName = worksheet.Cells[3, 6].GetValue<string>();

            // Leer datos de los productos
            var products = new List<ProductModel>();
            int row = 7;
            while (worksheet.Cells[row, 1].Value != null)
            {
                var productName = worksheet.Cells[row, 1].GetValue<string>();
                if (!string.IsNullOrEmpty(productName))
                {
                    var product = new ProductModel
                    {
                        productName = productName,
                        price = worksheet.Cells[row, 2].GetValue<int>(),
                        quantity = worksheet.Cells[row, 3].GetValue<int>(),
                        comment = worksheet.Cells[row, 4].GetValue<string>(),
                        idOrderFk = 0  // Suponiendo que el ID de la orden se establece aquí
                    };
                    products.Add(product);
                }
                row++;
            }

            return (order, products);
        }
    }
}

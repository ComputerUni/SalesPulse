using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.OrderExplorers;
using SalesPulse.Core.DTOs.OrderExplorerDtos;
using System.Text;

namespace SalesPulse.WebUI.Controllers
{
    public class OrderController(IOrderExplorerService _orderExplorerService) : Controller
    {
        public IActionResult Index(OrderExplorerFilterDto filter)
        {
            return View(filter);
        }

        public async Task<IActionResult> ExportCsv(OrderExplorerFilterDto filter)
        {
            var orders = await _orderExplorerService.GetOrdersForCsvExportAsync(filter);
            if(orders == null || !orders.Any())
            {
                TempData["ErrorMessage"] = "Dışa aktarılacak sipariş kaydı bulunamadı.";
                return RedirectToAction(nameof(Index), filter);
            }

            var maxLimit = 50000;
            if (orders.Count() >= maxLimit)
            {
                TempData["WarningMessage"] = "Seçilen aralıkta 50.000'den fazla kayıt bulunmaktadır. Sistem performansını korumak için lütfen tarih veya durum filtresini daraltarak tekrar deneyiniz.";
                return RedirectToAction(nameof(Index), filter);
            }

            var fileName = $"Siparisler_{DateTime.Now:yyyyMMdd_HHmmss}.csv"; 

            var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream, new UTF8Encoding(true), leaveOpen: true))
            {
                await writer.WriteLineAsync("Sipariş No; Müşteri Ad Soyad; E-Posta; Şehir; Tarih; Tutar; Ödeme Yöntemi; Durum");

                foreach(var item in orders)
                {
                    var customerName = EscapeCsvValue(item.CustomerName);
                    var email = EscapeCsvValue(item.CustomerEmail);
                    var city = EscapeCsvValue(item.City);
                    var paymentMethod = EscapeCsvValue(item.PaymentMethod);
                    var status = EscapeCsvValue(item.Status);
                    var date = item.CreatedAt.ToString("yyyy-MM-dd HH:mm");
                    var amount = item.TotalAmount.ToString("F2", new System.Globalization.CultureInfo("tr-TR"));

                    await writer.WriteLineAsync($"{item.OrderCode};{customerName};{email};{city};{date};{amount};{paymentMethod};{status}");
                }

                await writer.FlushAsync();
            }
            memoryStream.Position = 0;
            return File(memoryStream, "text/csv; charset=utf-8", fileName);
        }

        private static string EscapeCsvValue(string? value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if(value.Contains(';') || value.Contains('"') || value.Contains('\n'))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}

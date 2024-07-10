using Microsoft.AspNetCore.Mvc;
using PDF_Gen.Services;
using System.Threading.Tasks;

namespace PDF_Gen.Controllers
{
    public class PdfController : Controller
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        public async Task<IActionResult> GeneratePdf()
        {
            await _pdfService.GenerateSamplePdf();
            return Ok("PDF generation preview started.");
        }
    }
}

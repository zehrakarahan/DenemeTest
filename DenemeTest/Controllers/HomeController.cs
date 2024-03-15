using DenemeTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DenemeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            kayit.RecordScreen("C:\\Users\\user\\source\\repos\\DenemeTest\\DenemeTest\\wwwroot\\output3.mp4",30);
            return View();
        }
      

        public IActionResult Privacy()
        {
            var Width = Screen.AllScreens.Sum(s => s.Bounds.Width);
            var Height = Screen.AllScreens.Max(s => s.Bounds.Height);
            Rectangle rect = new Rectangle(0, 0,Width, Height);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save(@"C:\Users\user\source\repos\DenemeTest\DenemeTest\wwwroot\image.jpg", ImageFormat.Jpeg);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

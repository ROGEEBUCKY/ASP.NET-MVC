using QR_Code_Generator.Models;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace QR_Code_Generator.Controllers
    {
    public class HomeController : Controller
        {
        public ActionResult Index()
            {
            return View();
            }
        [HttpPost]
        public ActionResult Index(QRModel qrcode)
            {
            if (string.IsNullOrEmpty(qrcode.Message))
                {
                return View();
                }
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCode = qRCodeGenerator.CreateQrCode(qrcode.Message, QRCodeGenerator.ECCLevel.Q);
            Bitmap bitmap = new QRCode(qrCode).GetGraphic(20, Color.Black, Color.Red, (Bitmap)Image.FromFile("C:\\Users\\ritur\\Downloads\\Userjpg.jpg"));
            using (MemoryStream ms = new MemoryStream())
                {
                bitmap.Save(ms, ImageFormat.Png);
                ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            return View();
            }
        }
    }
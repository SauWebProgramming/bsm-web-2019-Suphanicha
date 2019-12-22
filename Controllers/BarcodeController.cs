using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OnBarcode.Barcode.BarcodeScanner;

namespace WebApplication1.Controllers
{
    public class BarcodeController : Controller
    {
        // GET: Barcode
        public ActionResult generate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult generate(string barcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //The Image is drawn based on length of Barcode text.
                using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
                {
                    //The Graphics library object is generated for the Image.
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //The installed Barcode font.
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);

                        //White Brush is used to fill the Image with white color.
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        //Black Brush is used to draw the Barcode over the Image.
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                    }

                    //The Bitmap is saved to Memory Stream.
                    bitMap.Save(ms, ImageFormat.Png);

                    //The Image is finally converted to Base64 string.
                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }


        //----------------READER -----------------//

        public ActionResult BarcodeReader()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BarcodeReader(HttpPostedFileBase barCodeUpload)
        {

            string localSavePath = "~/UploadFiles/";
            string str = string.Empty;
            string strImage = string.Empty;
            string strBarcode = string.Empty;



            if (barCodeUpload != null)
            {
                string fileName = barCodeUpload.FileName;
                localSavePath += fileName;
                barCodeUpload.SaveAs(Server.MapPath(localSavePath));

                Bitmap bitmap = null;
                try
                {
                    bitmap = new Bitmap(barCodeUpload.InputStream);
                }

                catch (Exception ex)
                {
                    ex.ToString();
                }


                if (bitmap == null)
                {
                    str = "File is not an image";
                }
                else
                {
                    strImage = "http://localhost:" + Request.Url.Port + "/UploadFile/" + fileName;
                    strBarcode = ReadBarcodeFromFile(Server.MapPath(localSavePath));

                }
            }

            else
            {
                str = "Please upload the barcode image";

            }

            ViewBag.ErrorMessage = str;
            ViewBag.Barcode = strBarcode;
            ViewBag.BarImage = strImage;

            return View();


        }

        private string ReadBarcodeFromFile(string v)
        {

            String[] barcodes = BarcodeScanner.Scan(v, BarcodeType.Code39);
            return barcodes[0];

        }
    }
}

using System;
using System.Drawing;
using System.IO;
using ZXing.QrCode;
// test 
namespace barcodeGenerator
{
    public class Barcode
    {
        public Barcode()
        {
           //Change from VS
        }

        public Bitmap Geerate(string barcode, int height = 170, int width = 375)
        {
            var QrcodeContent = barcode;

            var margin = 0;
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin,
                    PureBarcode = true,
                }
            };

            var pixelData = qrCodeWriter.Write(QrcodeContent);
            // creating a bitmap from the raw pixel data; if only black and white colors are used it makes no difference   
            // that the pixel data ist BGRA oriented and the bitmap is initialized with RGB   

            //using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))

            ////using (var ms = new FileStream(QrcodeContent + ".png", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //using (var ms = new MemoryStream())
            //{
            //    var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //    try
            //    {
            //        //    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image   
            //        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            //    }
            //    finally
            //    {
            //        bitmap.UnlockBits(bitmapData);
            //    }
            //    return ms;
            //}

            return new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        }

    }
}


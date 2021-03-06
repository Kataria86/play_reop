﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZXing.QrCode;

namespace BarcodeGenerator
{
    public class BarCode128
    {
        public int Height { get; set; }
        public int Weidth { get; set; }
        public int Type { get; set; }

        public string Data { get; set; }
        public void Geerate(string fileName)
        {

            var QrcodeContent = Data;

            var margin = 0;
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new QrCodeEncodingOptions
                {
                    Height = this.Height,
                    Width = this.Weidth,
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

            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))

            //using (var ms = new FileStream(QrcodeContent + ".png", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    //    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image   
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            }

        }
    }
}

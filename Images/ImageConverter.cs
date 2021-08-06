using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
namespace WebShop.Images
{
    public static class ImageConverter
    {
        public static byte[] ImageFromFilePathToByteArray(string imagePath)
        {
            return File.ReadAllBytes(imagePath); 
        }
        
    }
}

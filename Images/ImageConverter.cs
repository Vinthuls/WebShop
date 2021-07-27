using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Images
{
    public static class ImageConverter
    {
        public static byte[] ImageFromFilePathToByteArray(string imagePath)
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory())
                                .Parent.FullName;
            return File.ReadAllBytes(imagePath); 
        }
        
    }
}

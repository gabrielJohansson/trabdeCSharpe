using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace trabFinal_Misael_Gabriel.Util
{
    class Utilidade
    {
        public static ImageBrush returnImage(int t)
        {
            switch (t)
            {
                case 1:
                var imagePath = @"C:\Users\Gabriel\Desktop\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabFinal_Misael_Gabriel\Images\type1.jpg";
                ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(imagePath, UriKind.Absolute)));
                    return brush;
                case 2:
                    var imagePath2 = @"C:\Users\Gabriel\Desktop\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabFinal_Misael_Gabriel\Images\type2.jpg";
                    ImageBrush brush2 = new ImageBrush(new BitmapImage(new Uri(imagePath2, UriKind.Absolute)));
                    return brush2;
                case 3:
                    var imagePath3 = @"C:\Users\Gabriel\Desktop\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabFinal_Misael_Gabriel\Images\type3.jpg";
                    ImageBrush brush3 = new ImageBrush(new BitmapImage(new Uri(imagePath3, UriKind.Absolute)));
                    return brush3;
                case 4:
                    var imagePath4 = @"C:\Users\Gabriel\Desktop\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabdeC--3814be32c7f01beab5a4f6be8f16fd0062b79964\trabFinal_Misael_Gabriel\Images\type4.jpg";
                    ImageBrush brush4 = new ImageBrush(new BitmapImage(new Uri(imagePath4, UriKind.Absolute)));
                    return brush4;
            }
            return null;
        }

        public static int atk(int atk,string el1,string el2)
        {
            if(el1.Equals("Fogo")&&el2.Equals("Agua") || el1.Equals("Agua") && el2.Equals("Terra")|| el1.Equals("Ar") && el2.Equals("Fogo")|| el1.Equals("Terra") && el2.Equals("Ar"))
            {
                atk = atk + (int)(atk * 0.25);
            }
            if(el1.Equals("Fogo") && el2.Equals("Ar")|| el1.Equals("Agua") && el2.Equals("Fogo")|| el1.Equals("Ar") && el2.Equals("Terra")|| el1.Equals("Terra") && el2.Equals("Agua"))
            {
                atk = atk - (int)(atk * 0.25);
            }          
            return atk;
        }

    }
}

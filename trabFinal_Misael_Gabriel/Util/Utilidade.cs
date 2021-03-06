﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using trabFinal_Misael_Gabriel.Model;

namespace trabFinal_Misael_Gabriel.Util
{
    class Utilidade
    {
        public static ImageBrush returnImage(int t)
        {
            switch (t)
            {
                //trocar até desktop
                case 1:
                var imagePath = @"C:\Users\Aluno\Source\Repos\trabdeCSharpe\trabFinal_Misael_Gabriel\Images\type1.jpg";
                ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(imagePath, UriKind.Absolute)));
                    return brush;
                case 2:
                    var imagePath2 = @"C:\Users\Aluno\Source\Repos\trabdeCSharpe\trabFinal_Misael_Gabriel\Images\type2.jpg";
                    ImageBrush brush2 = new ImageBrush(new BitmapImage(new Uri(imagePath2, UriKind.Absolute)));
                    return brush2;
                case 3:
                    var imagePath3 = @"C:\Users\Aluno\Source\Repos\trabdeCSharpe\trabFinal_Misael_Gabriel\Images\type3.jpg";
                    ImageBrush brush3 = new ImageBrush(new BitmapImage(new Uri(imagePath3, UriKind.Absolute)));
                    return brush3;
                case 4:
                    var imagePath4 = @"C:\Users\Aluno\Source\Repos\trabdeCSharpe\trabFinal_Misael_Gabriel\Images\type4.jpg";
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


        public static Personagem LevelUp(Personagem p)
        {

            int qtdexp = 100;

            qtdexp = 100 + (p.Level * 10);

            if(p.Experiencia>qtdexp)
            {
                p.Experiencia = p.Experiencia - qtdexp;
                p.Level = p.Level + 1;
                p.VidaTotal = p.VidaTotal +  100;
                p.Ataque = p.Ataque +  10;
                return p;
            }

            return p;
        }
    }
}

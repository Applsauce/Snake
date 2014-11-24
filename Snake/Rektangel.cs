using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Rektangel
    {
        // Medlemsvariabler:
        private int x = 0;
        private int y = 0;
        private int bredd = 5;
        private int höjd = 5;
        private int r = 0; // Ger riktning, 0 = stilla, 1 uppåt, 2 höger, 3 neråt, 4 vänster
        private Color färg = Color.Red;

        // Konstruktor
        public Rektangel(int x, int y, int bredd, int höjd, Color Färg)
        {
            X = x;
            Y = y;
            Bredd = bredd;
            Höjd = höjd;
            färg = Färg;
        }

        // Egenskaper:
        // För x-kordinat
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 0) x = value;
                else x = -value;
            }
        }
        // För y-kordinat
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value > 0) y = value;
                else y = -value;
            }
        }
        // För bredd
        public int Bredd
        {
            get
            {
                return bredd;
            }
            set
            {
                if (value > 0) bredd = value;
                else bredd = -value;
            }
        }
        // För höjd
        public int Höjd
        {
            get
            {
                return höjd;
            }
            set
            {
                if (value > 0) höjd = value;
                else höjd = -value;
            }
        }
        // För up
        public bool Up
        {
            get;
            set;
        }
        // För ner
        public bool Ner
        {
            get;
            set;
        }
        // För höger
        public bool Höger
        {
            get;
            set;
        }
        // För vänster
        public bool Vänster
        {
            get;
            set;
        }
        // För riktning
        public int R
        {
            get
            {
                return r;
            }
            set
            {
                if (value > 0) r = value;
                else r = -value;
            }
        }


        // Metod Rita:
        public void Rita(Graphics g)
        {
            g.FillRectangle(new SolidBrush(färg), x, y, bredd, höjd);
        }

        // Metod Träffad: Kollar ifall en kub är innanför en annan kub
        public bool ÄrTräffad(int posX, int posY, int posX2, int posY2)
        {
            bool träffad = false;
            
            bool dx1 = x <= posX &&  (x + bredd) >= posX;
            bool dy1 = y <= posY &&  (y + höjd)  >= posY;

            bool dx2 = x <= posX2 && (x + bredd) >= posX2;
            bool dy2 = y <= posY2 && (y + höjd)  >= posY2;
            // Om något av hörnen krossar något av de andra hörnen
            if ( dx1 && dy1 || dx1 && dy2 || dx2 && dy2 || dx2 && dy1 )
            {
                träffad = true;
            }
            return träffad;
        }

    }
}

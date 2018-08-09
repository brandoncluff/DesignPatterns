using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns {
    public class Rectangle {
        //public int Width { get; set; }
        //public int Height { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle() {

        }

        public Rectangle(int width, int height) {
            Width = width;
            Height = height;
        }

        public override string ToString() {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle {
        // THE FOLLOWING VARIABLES VIOLATE THE LISKOV SUBSTITUTION PRINCIPAL
        /*
        public new int Width {
          set { base.Width = base.Height = value; }
        }

        public new int Height { 
          set { base.Width = base.Height = value; }
        }
        */

        // SHOULD BE ABLE TO UPCAST TO THE BASE TYPE BY OVERRIDING
        public override int Width {
            set { base.Width = base.Height = value; }
        }

        public override int Height {
            set { base.Width = base.Height = value; }
        }
    }

    class LiskovSubstitutionPrinciple {
        static public int Area(Rectangle r) => r.Width * r.Height;

        public static void Test() {
            Rectangle rc = new Rectangle(2, 3);
            WriteLine($"{rc} has area {Area(rc)}");

            // SHOULD BE ABLE TO SUBSTITUTE A BASE TYPE FOR A SUBTYPE
            Rectangle sq = new Square {
                Width = 4
            };

            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}

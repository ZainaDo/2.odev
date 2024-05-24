using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.odev2.donemNDP
{
    public  class Class1
    {
      
    }

     public class Nokta
    {
        public double X, Y;

        public Nokta(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class Nokta3D : Nokta
    {
        public double Z;

        public Nokta3D(double x, double y, double z) : base(x, y)
        {
            Z = z;
        }
    }

    public class Cember
    {
        public Nokta Center;
        public double Radius;

        public Cember(Nokta center, double radius)
        {
            Center = center;
            Radius = radius;
        }
    }

   public  class Rectangle
    {
        public double Left, Top, Right, Bottom;

        public Rectangle(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }

   public  class Sphere : Cember
    {
        public Sphere(Nokta3D center, double radius) : base(center, radius)
        {
        }

        public Nokta3D Center3D => (Nokta3D)Center;
    }

    public class Cylinder
    {
        public Nokta3D Center;
        public double Radius, Height;
        public Cylinder(Nokta3D center, double radius, double height)
        {
            Center = center;
            Radius = radius;
            Height = height;
        }
    }

    public static class CollisionDetection
    {
        public static bool PointToRectangle(Nokta n, Rectangle r)
        {
            return n.X >= r.Left && n.X <= r.Right && n.Y >= r.Top && n.Y <= r.Bottom;
        }

        public static bool PointToCircle(Nokta p, Cember c)
        {
           

            float mesafe = (float)Math.Sqrt((p.X - c.Center.X) * (p.X - c.Center.X) + (p.Y - c.Center.Y) * (p.Y - c.Center.Y));
            if (mesafe <= c.Radius )
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public static bool RectangleToRectangle(Rectangle r1, Rectangle r2)
        {
            return !(r1.Left > r2.Right || r1.Right < r2.Left || r1.Top > r2.Bottom || r1.Bottom < r2.Top);
        }

        public static bool CircleToRectangle(Cember c, Rectangle r)
        {
            Nokta closestPoint = new Nokta(Math.Max(r.Left, Math.Min(c.Center.X, r.Right)), Math.Max(r.Top, Math.Min(c.Center.Y, r.Bottom)));
            return Math.Sqrt((closestPoint.X - c.Center.X) * (closestPoint.X - c.Center.X) + (closestPoint.Y - c.Center.Y) * (closestPoint.Y - c.Center.Y)) <= c.Radius;
        }

        public static bool CircleToCircle(Cember c1, Cember c2)
        {
            return Math.Sqrt((c2.Center.X - c1.Center.X) * (c2.Center.X - c1.Center.X) + (c2.Center.Y - c1.Center.Y) * (c2.Center.Y - c1.Center.Y)) <= (c1.Radius + c2.Radius);
        }

        public static bool PointToSphere(Nokta3D n, Sphere s)
        {
            return Math.Sqrt((n.X - s.Center3D.X) * (n.X - s.Center3D.X) + (n.Y - s.Center3D.Y) * (n.Y - s.Center3D.Y) + (n.Z - s.Center3D.Z) * (n.Z - s.Center3D.Z)) <= s.Radius;
        }

        public static bool SphereToSphere(Sphere s1, Sphere s2)
        {
            return Math.Sqrt((s2.Center3D.X - s1.Center3D.X) * (s2.Center3D.X - s1.Center3D.X) + (s2.Center3D.Y - s1.Center3D.Y) * (s2.Center3D.Y - s1.Center3D.Y) + (s2.Center3D.Z - s1.Center3D.Z) * (s2.Center3D.Z - s1.Center3D.Z)) <= (s1.Radius + s2.Radius);
        }
        public static bool CylinderToCylinder(Cylinder c1, Cylinder c2)
        {
            double distance = Math.Sqrt((c2.Center.X - c1.Center.X) * (c2.Center.X - c1.Center.X) + (c2.Center.Y - c1.Center.Y) * (c2.Center.Y - c1.Center.Y));
            return distance <= (c1.Radius + c2.Radius) && Math.Abs(c1.Center.Z - c2.Center.Z) <= c1.Height + c2.Height;
        }

    }



}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point2d3d
{
    internal class Program
    {
        interface IPoint
        {
            double CalcDist(IPoint other);
        }

        interface ITriangle
        {
            void CheckType();
        }

        class Point2D : IPoint
        {
            public string Name { get; set; }
            public double X { get; set; }
            public double Y { get; set; }

            public double CalcDist(IPoint other)
            {
                Point2D other2D = other as Point2D;
                if (other2D == null)
                    throw new ArgumentException("Other point must be a Point2D");

                return Math.Sqrt(Math.Pow(X - other2D.X, 2) + Math.Pow(Y - other2D.Y, 2));
            }
        }

        class Point3D : IPoint
        {
            public string Name { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }


            public double CalcDist(IPoint other)
            {
                Point3D other3D = other as Point3D;
                if (other3D == null)
                    throw new ArgumentException("Other point must be a Point3D");

                return Math.Sqrt(Math.Pow(X - other3D.X, 2) + Math.Pow(Y - other3D.Y, 2) + Math.Pow(Z - other3D.Z, 2));
            }
        }
        class Vector3
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public Vector3(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public
         double DotProduct(Vector3 other)
            {
                return X * other.X + Y * other.Y + Z * other.Z;
            }
        }

        class Triangle : ITriangle
        {

            public Point3D A { get; set; }
            public Point3D B { get; set; }
            public Point3D C { get; set; }
             
            public void CheckType()
            {
                // Tính các vectơ
                Vector3 AB = new Vector3(B.X - A.X, B.Y - A.Y, B.Z - A.Z);
                Vector3 BC = new Vector3(C.X - B.X, C.Y - B.Y, C.Z - B.Z);
                Vector3 CA = new Vector3(A.X - C.X, A.Y - C.Y, A.Z - A.Z);
                // độ dài cạnh 
                double ABlg = A.CalcDist(B);
                double BClg = B.CalcDist(C);
                double CAlg = C.CalcDist(A);


                // Kiểm tra các loại tam giác
                string loaiTamGiac;
                if (ABlg == BClg && BClg == CAlg)
                {
                    loaiTamGiac = "     Tam giác đều";
                }
                else
               if (AB.DotProduct(BC) == 0 || AB.DotProduct(CA) == 0 || BC.DotProduct(CA) == 0 && ABlg == BClg || BClg == CAlg || ABlg == CAlg)
                {
                    loaiTamGiac = "       Tam giác vuông cân ";
                }
                else
                 if (AB.DotProduct(BC) == 0 || AB.DotProduct(CA) == 0 || BC.DotProduct(CA) == 0)
                {
                    loaiTamGiac = "       Tam giác vuông";
                }
                else if (ABlg == BClg || BClg == CAlg || ABlg == CAlg)
                {
                    loaiTamGiac = "         Tam giác cân";
                }
                /* if (AB.DotProduct(BC) == 0 || AB.DotProduct(CA) == 0 || BC.DotProduct(CA) == 0 && ABlg == BClg || BClg == CAlg || ABlg == CAlg)
                 {
                     loaiTamGiac = " Tam giác vuông cân ";
                         }*/
                else
                {
                    loaiTamGiac = "Tam giác thường";
                }
                Console.WriteLine($"Tam giác {A.Name}({A.X},{A.Y},{A.Z}){B.Name}({B.X},{B.Y},{B.Z}){C.Name}({C.X},{C.Y},{C.Z}) là: {loaiTamGiac} ");
                /*Console.WriteLine($"Tọa độ các đỉnh:");
                Console.WriteLine($"{A.Name}({A.X}, {A.Y}, {A.Z})");
                Console.WriteLine($"{B.Name} (({B.X}, {B.Y}, {B.Z})");
                Console.WriteLine($"{C.Name} (({C.X}, {C.Y}, {C.Z})");*/
            }
        }



        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Tạo các điểm 2D
            Point2D p1 = new Point2D { Name = "A", X = 1, Y = 2 };
            Point2D p2 = new Point2D { Name = "B", X = 4, Y = 6 };
            Point2D p3 = new Point2D { Name = "C", X = 5, Y = 7 };
            // tao diem 3d 
            Point3D p4 = new Point3D { Name = "D", X = 0, Y = 0, Z = 0 };
            Point3D p5 = new Point3D { Name = "E", X = 1, Y = 2, Z = 3 };
            Point3D p6 = new Point3D { Name = "F", X = 4, Y = 5, Z = 6 };
            // EFG vuông 
            Point3D p7 = new Point3D { Name = "G", X = 1, Y = 5, Z = 3 };
            Point3D p8 = new Point3D { Name = "H", X = 4.5, Y = 0.5, Z = 2.5 };
            Point3D p9 = new Point3D { Name = "I", X = 3, Y = 0, Z = 0 };
            Point3D p10 = new Point3D { Name = "K", X = 5, Y = 3, Z = 6 };
            Point3D p11 = new Point3D { Name= "X",X=1,Y=0, Z = 0};
            Point3D p12 = new Point3D { Name = "Y", X = 0, Y = 1, Z = 0 };
            Point3D p13 = new Point3D { Name = "Z", X = 0, Y = 0, Z = 1 };
            Console.WriteLine(" khảong cách giữa các điểm 2D ");
            Point2D[] all2DPoints = { p1, p2, p3 };
            for (int i = 0; i < all2DPoints.Length; i++)
            {
                for (int j = i + 1; j < all2DPoints.Length; j++)
                {
                    Console.WriteLine($"Khoảng cách giữa {all2DPoints[i].Name}({all2DPoints[i].X},{all2DPoints[i].Y}) và {all2DPoints[j].Name}({all2DPoints[j].X},{all2DPoints[j].Y}) là: {all2DPoints[i].CalcDist(all2DPoints[j])}");
                }
            }

            Console.WriteLine("\nKhoảng cách giữa tất cả các điểm 3D:");
            Point3D[] all3DPoints = { p4, p5, p6, p7, p8, p9, p10,p11,p12,p13 };
            for (int i = 0; i < all3DPoints.Length; i++)
            {
                for (int j = i + 1; j < all3DPoints.Length; j++)
                {
                    Console.WriteLine($"Khoảng cách giữa {all3DPoints[i].Name}({all3DPoints[i].X},{all3DPoints[i].Y},{all3DPoints[i].Z}) và {all3DPoints[j].Name}({all3DPoints[j].X},{all3DPoints[j].Y},{all3DPoints[j].Z}) là: {all3DPoints[i].CalcDist(all3DPoints[j])}");
                }
            }
            Console.WriteLine(  "");

            // Tạo tam giác
            for (int i = 0; i < all3DPoints.Length - 2; i++)
            {
                for (int j = i + 1; j < all3DPoints.Length - 1; j++)
                {
                    for (int k = j + 1; k < all3DPoints.Length; k++)
                    {


                        Triangle t = new Triangle { A = all3DPoints[i], B = all3DPoints[j], C = all3DPoints[k] };

                        t.CheckType();
                    }
                }
            }

            Console.ReadKey();
            /* Một interface IPoint có phương thức cal.dis (IPoint)- tính khoảng cách 
             * một interface ITriangle có phương thức checktype() ktra dạng tam giác
             * a. khai báo 2 interface
             * b. một lớp Point2D và Point3D thực thi interface Ipont
             * một lớp triangle thuẹc thi interface Itriangle 
             * lớp Triangle được tạo từ 3 Point3D
             * khai báo các lớp 
             * c.tạo mảng gồm 3 Point2D và 7 Point3D in ra khoảng cách giữa các Point cùng loại ( 2D với 2D, 3D với 3D)
             * d. in ra bộ 3 Point 3D  tạo thành các tam giác
             * e.kiểm tra các dạng tam giác ở câu d ( vuông, cân đều... )
             
            */
        }
    }
}

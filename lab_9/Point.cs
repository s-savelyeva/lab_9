using System;

namespace lab_9
{
    /// <summary>
    /// Класс, описывающий объект - точка
    /// Поля:
    /// x - координата x
    /// y - координата y
    /// </summary>
    class Point
    {
        // Поля
        private double x;
        private double y;

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        // Конструктор с параметрами
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Конструктор копирования
        public Point(Point other)
        {
            x = other.x;
            y = other.y;
        }
        
        /// <summary>
        /// Перегруженный метод ToString()
        /// </summary>
        public override string ToString()
        {
            return $"x: {x}, y: {y}";
        }

        /// <summary>
        ///Унарный оператор -- (уменьшить координаты x и y на 1)
        /// </summary>
        /// <param name="p">Точка, у которой нужно уменьшить координаты</param>
        /// <returns>Точку с уменьшенными координатами</returns>
        public static Point operator --(Point p)
        {
            return new Point(p.X - 1, p.Y - 1);
        } 
        
        /// <summary>
        ///Унарный оператор - (поменять координаты x и y местами)
        /// </summary>
        /// <param name="p">Точка, у которой нужно поменять координаты</param>
        /// <returns>Точку с поменянными координатами</returns>
        public static Point operator +(Point p)
        {
            return new Point(p.Y, p.X);
        }
        
        /// <summary>
        ///Неявное приведение типа к int (возвращает целую часть координаты x)
        /// </summary>
        /// <param name="p">Точка, у которой нужно привести X к целому</param>
        /// <returns>Целую координату X</returns>
        public static implicit operator int(Point p)
        {
            int newX = Convert.ToInt32(Math.Floor(p.X));
            return newX;
        }

        /// <summary>
        ///Явное приведение типа к double (возвращает координату y)
        /// </summary>
        /// <param name="p">Точка, у которой нужно привести Y к double</param>
        /// <returns>double координату y</returns>
        public static explicit operator double(Point p)
        {
            return (double)p.Y;
        }

        /// <summary>
        /// Бинарный оператор - уменьшается координата X
        /// </summary>
        /// <param name="p">Координаты точки</param>
        /// <param name="value">Значение, которое вычитается</param>
        /// <returns>Точку с уменьшенным Х</returns>
        public static Point operator -(Point p, int value)
        {
            return new Point(p.X - value, p.Y);
        }

        /// <summary>
        /// Бинарный оператор - уменьшается координата Y
        /// </summary>
        /// <param name="value">Координаты точки</param>
        /// <param name="p">Значение, которое вычитается</param>
        /// <returns>Точку с уменьшенным Y</returns>
        public static Point operator -(int value, Point p)
        {
            return new Point(p.X, p.Y - value);
        }

        /// <summary>
        /// Вычисление дистанции до точки
        /// </summary>
        /// <param name="p">Координаты точки</param>
        /// <returns>Расстояние до точки</returns>
        public static double operator -(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X, 2) + Math.Pow(p.Y, 2));
        }

    }
    
}



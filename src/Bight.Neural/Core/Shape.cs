using System;
using MathNet.Numerics.LinearAlgebra.Double;
using MvvmCross.ViewModels;

namespace Bight.Neural.Core
{
    public class Shape : MvxViewModel, IEquatable<Shape>
    {
        private int _height;
        private int _width;
        private int _thickness;



        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        public int Thickness
        {
            get => _thickness;
            set => SetProperty(ref _thickness, value);
        }

        public int Levels => Height * Width * Thickness;

        public int this[int i]
        {
            get
            {
                return i switch
                    {
                    0 => Height,
                    1 => Width,
                    2 => Thickness,
                    _ => throw new ArgumentOutOfRangeException(nameof(i)),
                    };
            }
            set
            {
                switch (i)
                {
                    case 0:
                        Height = value;
                        break;
                    case 1:
                        Width = value;
                        break;
                    case 2:
                        Thickness = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
        }

        #region Init
        /// <summary>
        /// for Serializer
        /// </summary>
        public Shape()
        {

        }


        public Shape(int Height)
            : this(Height, 1, 1)
        {

        }

        public Shape(int height, int width)
            : this(height, width, 1)
        {

        }


        public Shape(int height, int width, int thickness)
        {
            Height = height;
            Width = width;
            Thickness = thickness;
        }

        public static Shape From(Matrix denseMatrix)
        {
            return new Shape(denseMatrix.RowCount, denseMatrix.ColumnCount);
        }


        #endregion



        #region

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator ==(Shape s1, Shape s2)
        {
            return s1 != null && s1.Equals(s2);
        }

        public static bool operator !=(Shape s1, Shape s2)
        {
            return s1 != null && !s1.Equals(s2);
        }

        #endregion




        public override string ToString()
        {
            return $"Shape:{Height}*{Width}*{Thickness}";
        }

        public bool Equals(Shape other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _height == other._height && _width == other._width && _thickness == other._thickness;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Shape) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _height.GetHashCode();
                hashCode = (hashCode * 397) ^ _width.GetHashCode();
                hashCode = (hashCode * 397) ^ _thickness.GetHashCode();
                return hashCode;
            }
        }
    }
}

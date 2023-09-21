using System.ComponentModel.DataAnnotations;

namespace Triangles.Models
{
    public class RegularTriangle
    {
        #region Fields
        protected float _baseSideLength;
        #endregion

        #region Properties
        [Display(Name = "Side length")]
        [Required(ErrorMessage = "{0} must be provided.")]
        [Range(1, float.MaxValue, ErrorMessage = "{0} must be more or equal to 1")]
        public float SideLength { get; set; }
        #endregion

        #region Constructors
        public RegularTriangle()
        {
            _baseSideLength = 0;
        }

        public RegularTriangle(float sideLength)
        {
            if (sideLength < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _baseSideLength = sideLength;
        }

        public RegularTriangle(RegularTriangle other)
        {
            _baseSideLength = other._baseSideLength;
        }
        #endregion

        #region Methods
        public bool Equals(RegularTriangle triangle)
        {
            return this.SideLength == triangle.SideLength;
        }

        public float GetSquare() =>
            (float)(Math.Sqrt(3) * (SideLength * SideLength)) / 4;

        public float GetPerimeter() => SideLength * 3;

        public override string ToString()
        {
            return $"Side length: {SideLength}";
        }

        protected float GetHeight() => (float)(SideLength * Math.Sqrt(3)) / 2;

        protected double GetRadius()
        {
            return SideLength / (2 * (Math.Sqrt(3)));
        }
        #endregion

        #region Operators
        public static RegularTriangle operator *(RegularTriangle triangle, float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new RegularTriangle(triangle.SideLength * value);
        }

        public static RegularTriangle operator *(float value, RegularTriangle triangle)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new RegularTriangle(triangle.SideLength * value);
        }
        #endregion
    }
}

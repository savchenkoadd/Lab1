using System.ComponentModel.DataAnnotations;

namespace Triangles.Models
{
    public class RegularTriangularPyramid : RegularTriangle
    {
        #region Fields
        private float _height;
        #endregion

        #region Properties
        [Required(ErrorMessage = "{0} must be provided.")]
        [Range(1, float.MaxValue, ErrorMessage = "{0} must be more than zero.")]
        public float Height { get; set; }

        public double Volume
        {
            get
            {
                var r = (Math.Sqrt(3) / 3) * SideLength;
                return Height * (r * r) * Math.Sqrt(3);
            }
        }
        #endregion

        #region Constructors
        public RegularTriangularPyramid() : base()
        {
            _height = 0;
        }

        public RegularTriangularPyramid(float sideLength, float height) : base(sideLength)
        {
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _height = height;
        }

        public RegularTriangularPyramid(RegularTriangularPyramid other) : base(other)
        {
            _height = other._height;
        }
        #endregion

        #region Methods
        new public float GetPerimeter()
        {
            return (3 * (GetLateralSideLength()) + base.GetPerimeter());
        }

        new public float GetSquare()
        {
            return base.GetSquare() + ((base.GetPerimeter() * GetSlantHeight()) / 2);
        }

        public bool Equals(RegularTriangularPyramid piramid)
        {
            return base.Equals(piramid) && Height == piramid.Height;
        }

        public override string ToString()
        {
            return $"Side length: {SideLength}, Height: {Height}";
        }

        public float GetSlantHeight()
        {
            var baseRadius = GetRadius();

            var slantHeight = (float)Math.Sqrt((Height * Height) + (baseRadius * baseRadius));

            return slantHeight;
        }

        public float GetLateralSideLength()
        {
            var slantHeight = GetSlantHeight();

            return (float)Math.Sqrt(Math.Pow(slantHeight, 2) + (Math.Pow(SideLength / 2, 2)));
        }
        #endregion

        #region Operators
        public static RegularTriangularPyramid operator *(RegularTriangularPyramid piramid, float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new RegularTriangularPyramid(piramid.SideLength * value, piramid.Height * value);
        }

        public static RegularTriangularPyramid operator *(float value, RegularTriangularPyramid piramid)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new RegularTriangularPyramid(piramid.SideLength * value, piramid.Height * value);
        }
        #endregion
    }
}

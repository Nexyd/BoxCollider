// Daniel Morato Baudi
using System;
using System.Collections.Generic;

namespace BoxCollider
{
    public class BoxCollider
    {
        #region Structs
        struct Position
        {
            public int x;
            public int y;
        }
        #endregion

        #region Attributes
        private Position pos;
        private int height;
        private int width;
        private List<Position> points;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new void BoxCollider.
        /// </summary>
        public BoxCollider()
        {
            this.pos.x = 0;
            this.pos.y = 0;
            this.height = 0;
            this.width = 0;
            this.points = new 
                List<Position>();

            this.FillMatrix();
        }

        /// <summary>
        /// Initializes a new BoxCollider with position and dimensions.
        /// </summary>
        public BoxCollider(int x, int y, int height, int width)
        {
            this.pos.x = x;
            this.pos.y = y;
            this.height = height;
            this.width = width;
            this.points = new 
                List<Position>();

            this.FillMatrix();
        }
        #endregion

        #region Methods
        #region Public methods
        /// <summary>
        /// Checks if the box has collided with another box.
        /// </summary>
        /// <param name="collider">Box target.</param>
        /// <returns>Collision status.</returns>
        public bool CollideWith(BoxCollider collider)
        {
            for (int i = 0; i < points.Count; i++)
                if (this.points[i].Equals(collider.points[i]))
                    return true;

            return false;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Fills the matrix with all the points inside the box.
        /// </summary>
        private void FillMatrix()
        {
            int yAux = pos.y;
            for (int i = pos.y; i < (pos.y + height); i++)
            {
                for (int j = pos.x; j < (pos.x + width); j++)
                    this.points.Add(NewPosition(pos.x + 1, yAux));

                yAux++;
            }
        }

        /// <summary>
        /// Creates an "instance" of the position struct.
        /// </summary>
        /// <param name="x">X coord.</param>
        /// <param name="y">Y coord.</param>
        /// <returns>Position object.</returns>
        private Position NewPosition(int x, int y)
        {
            Position aux;
            aux.x = x;
            aux.y = y;

            return aux;
        }
        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the x coord.
        /// </summary>
        public int X
        {
            get { return this.pos.x; }
            set { if (!(Double.IsNaN(value)))
                    pos.x = value; }
        }

        /// <summary>
        /// Gets or sets the y coord.
        /// </summary>
        public int Y
        {
            get { return this.pos.y; }
            set { if (!(Double.IsNaN(value)))
                    pos.y = value; }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { if (!(Double.IsNaN(value)))
                    height = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width
        {
            get { return this.width; }
            set { if (!(Double.IsNaN(value)))
                    width = value; }
        }
        #endregion
    }
}

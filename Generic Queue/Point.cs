using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Queue
{
    public struct Point
    {
        private int x;
        private int y;

        /// <summary>Initializes a new instance of the <see cref="Point"/> struct.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

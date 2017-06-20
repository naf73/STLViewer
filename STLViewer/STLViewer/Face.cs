using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLViewer
{
    class Face
    {
        /// <summary>
        /// Нормаль полигона
        /// </summary>
        public float[] normal = new float[3];

        /// <summary>
        /// 1-я точка треугольного полигона
        /// </summary>
        public float[] vertex1 = new float[3];

        /// <summary>
        /// 2-я точка треугольного полигона
        /// </summary>
        public float[] vertex2 = new float[3];
        
        /// <summary>
        /// 3-я точка треугольного полигона
        /// </summary>
        public float[] vertex3 = new float[3];
    }
}

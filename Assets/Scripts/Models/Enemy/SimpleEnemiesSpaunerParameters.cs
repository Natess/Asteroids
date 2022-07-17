using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class SimpleEnemiesSpaunerParameters
    {
        /// <summary>
        /// Период создания НЛО
        /// </summary>
        public float UfoTimeSpanPeriod { get; set; }
        /// <summary>
        /// Период создания астероидов
        /// </summary>
        public float AsteroidTimeSpanPeriod { get; set; }
        /// <summary>
        /// Сторона внутреннего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMinX { get; set; }
        /// <summary>
        /// Сторона внешнего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMaxX { get; set; }
        /// <summary>
        /// Сторона внутреннего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMinY{ get; set; }
        /// <summary>
        /// Сторона внешнего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMaxY { get; set; }
        public int AsteroidHealth { get; internal set; }
        public int UFOHealth { get; internal set; }
    }
}

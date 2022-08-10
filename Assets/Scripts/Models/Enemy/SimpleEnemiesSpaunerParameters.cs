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
        public float UfoTimeSpanPeriod;
        /// <summary>
        /// Период создания астероидов
        /// </summary>
        public float AsteroidTimeSpanPeriod;
        /// <summary>
        /// Сторона внутреннего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMinX;
        /// <summary>
        /// Сторона внешнего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMaxX;
        /// <summary>
        /// Сторона внутреннего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMinY;
        /// <summary>
        /// Сторона внешнего прямоугольника для спауна
        /// </summary>
        public float CaptureDistanceMaxY;
        public int AsteroidHealth;
        public int UFOHealth;
    }
}

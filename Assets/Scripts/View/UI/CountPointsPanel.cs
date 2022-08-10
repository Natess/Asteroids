using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    internal class CountPointsPanel : BaseUi
    {
        [SerializeField] private Text _text;
        private void Start()
        {
            _text.text = "Очки: 0";
        }

        public override void Execute()
        {
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        private void Interpret(string value)
        {
            var arrParse = value.Split(':');
            if (arrParse.Count() == 2 && long.TryParse(arrParse[1].Trim(), out var number))
            {
                _text.text = arrParse[0] + ": " + ToGameFormat(number);
            }
        }
        private string ToGameFormat(long number)
        {
            if (number > 1000000)
                return $"{number / 1000000}M";

            if (number > 1000)
                return $"{number / 1000}K";

            return number.ToString();
        }

        internal void SetText(string text)
        {
            Interpret(text);
        }

    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    internal sealed class CountFragsPanel : BaseUi
    {
        [SerializeField] private Text _text;

        private void Start()
        {
            _text.text = "Уничтожено: 0";
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        public override void Execute()
        {
            gameObject.SetActive(true);
        }

        internal void SetText(string text)
        {
            _text.text = text;
        }
    }

}

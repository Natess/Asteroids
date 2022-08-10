using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class UserInterface : MonoBehaviour
    {
        [SerializeField] private CountPointsPanel _countPointsPanel;
        [SerializeField] private CountFragsPanel _countFragsPanel;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private BaseUi _currentWindow;

        private void Start()
        {
            _countFragsPanel.Cancel();
            _currentWindow = _countPointsPanel;
        }
        private void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }
            switch (stateUI)
            {
                case StateUI.FragsCountPanel:
                    _currentWindow = _countFragsPanel;
                    break;
                case StateUI.PointCountPanel:
                    _currentWindow = _countPointsPanel;
                    break;
                default:
                    break;
            }
            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Execute(StateUI.FragsCountPanel);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Execute(StateUI.PointCountPanel);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_stateUi.Count > 0)
                {
                    Execute(_stateUi.Pop(), false);
                }
            }
        }

        internal void SetText(StateUI stateUI, string text)
        {
            switch (stateUI)
            {
                case StateUI.FragsCountPanel:
                    _countFragsPanel.SetText(text);
                    break;
                case StateUI.PointCountPanel:
                    _countPointsPanel.SetText(text);
                    break;
                default:
                    break;
            }
        }

    }
}

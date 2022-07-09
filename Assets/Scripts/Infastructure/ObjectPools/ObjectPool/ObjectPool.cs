using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly GameObject _root;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{prefab.name}]");
            _root.transform.position = Vector3.zero;
        }

        public GameObject Pop()
        {
            GameObject result;
            if(_stack.Count == 0)
            {
                result = UnityEngine.Object.Instantiate<GameObject>(_prefab);
                result.name = _prefab.name;
            }
            else
            {
                result = _stack.Pop();
            }

            result.SetActive(true);
            result.transform.SetParent(null);
            return result;
        }

        public void Push(GameObject gameObject)
        {
            _stack.Push(gameObject);
            gameObject.transform.SetParent(_root.transform);
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            for(var i = 0; i < _stack.Count; i++)
            {
                var gameOject = _stack.Pop();
                UnityEngine.Object.Destroy(gameOject);
            }
            UnityEngine.Object.Destroy(_root.gameObject);
        }
    }
}
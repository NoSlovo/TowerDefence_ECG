using System.Collections.Generic;
using Enemy;
using Enemy.EnemyInterfaces;
using UnityEngine;

namespace Services.Factory
{
    public class FactoryPool<T> where T : MonoBehaviour, IPoolElement
    {
        private T _objectPrefab;
        
        private Stack<T> _poolElements;

        public FactoryPool(T objectPrefab, int objectsCount)
        {
            _objectPrefab = objectPrefab;
            _poolElements = new Stack<T>(objectsCount);
            InitPool(objectsCount);
        }

        public T GetElement()
        {
            var poolElement = GetDisabledElement();
            poolElement.SwitchActiveState(true);
            return poolElement;
        }

        public Stack<T> GetPoolElements()
        {
            var copy = _poolElements;
            return copy;
        }

        private void InitPool(int countEnemyOnPool)
        {
            for (int i = 0; i < countEnemyOnPool; i++)
            {
                var enemy = CreateElement();
                _poolElements.Push(enemy);
            }
        }


        private T CreateElement()
        {
            var enemy = Object.Instantiate(_objectPrefab);
            enemy.SwitchActiveState(false);
            return enemy;
        }

        private T GetDisabledElement()
        {
            foreach (var element in _poolElements)
            {
                if (!element.IsActive)
                    return element;
            }

            return CreateElement();
        }
    }
}
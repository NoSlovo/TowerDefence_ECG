using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Spawners.Factory
{
    public class FactoryPool<T> : IService where T : MonoBehaviour, IPolElement
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
            var polElement = GetDisableElement();
            polElement.SwitchActiveState(true);
            polElement.OnTurnedOff += ElementsRemove;
            return polElement;
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

        private T GetDisableElement()
        {
            foreach (var element in _poolElements)
            {
                if (!element.IsActive)
                    return element;
            }

            var polElement = CreateElement();
            _poolElements.Push(polElement);
            return polElement;
        }
        
        private void ElementsRemove()
        {
            foreach (var element in _poolElements)
            {
                if (!element.IsActive)
                {
                    element.SwitchActiveState(false);
                    element.OnTurnedOff -= ElementsRemove;
                }
            }
        }
    }
}
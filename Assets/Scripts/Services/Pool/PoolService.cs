using System.Collections.Generic;
using Enemy.EnemyInterfaces;
using UnityEngine;

namespace Services.Pool
{
    public class PoolService<T> where T : MonoBehaviour, IPoolElement
    {
        private readonly T _element;
        
        private readonly Stack<T> _poolElements;

        public PoolService(T element, int sizePool)
        {
            _element = element;
            _poolElements = new Stack<T>(sizePool);
            Initialize(sizePool);
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

        private void Initialize(int countEnemyOnPool)
        {
            for (int i = 0; i < countEnemyOnPool; i++)
            {
                var enemy = CreateElement();
                _poolElements.Push(enemy);
            }
        }


        private T CreateElement()
        {
            var enemy = Object.Instantiate(_element);
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
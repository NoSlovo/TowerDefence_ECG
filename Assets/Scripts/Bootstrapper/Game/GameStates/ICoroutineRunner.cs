using System.Collections;

namespace Bootstrapper.Game.GameStates
{
    public interface ICoroutineRunner
    {
        public void Run(IEnumerator coroutine);
    }
}
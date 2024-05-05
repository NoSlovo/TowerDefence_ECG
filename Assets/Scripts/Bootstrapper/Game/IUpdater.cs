using System;
using VContainer.Unity;

namespace Bootstrapper.Game
{
    public interface IUpdater
    {
        public event Action IUpdate;
        public void Ticked();
        public void AddTickedSerivece(ITickable service);

    }
}
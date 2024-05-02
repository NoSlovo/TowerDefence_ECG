using System;

namespace Enemy
{
    public interface IPolElement
    {
        public event Action TurnedOff;
        public bool IsActive { get; set; }
        public void SwitchActiveState(bool value);
        
    }
}
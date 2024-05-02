
namespace Enemy
{
    public interface IPolElement
    {
        public bool IsActive { get; set; }
        public void SwitchActiveState(bool value);
        
    }
}
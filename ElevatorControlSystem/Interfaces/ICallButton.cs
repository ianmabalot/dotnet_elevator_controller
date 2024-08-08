namespace ElevatorControlSystem.Interfaces
{
    public interface ICallButton
    {
        int Floor { get; }
        void Press();
    }
}
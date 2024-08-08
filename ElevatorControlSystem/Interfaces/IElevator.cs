namespace ElevatorControlSystem.Interfaces
{
    public interface IElevator
    {
        int Id { get; }
        int CurrentFloor { get; }
        List<int> Calls { get; }
        Task MoveToFloorAsync(int floor);
        Task ProcessRequestsAsync();
        void AddRequest(int floor);
    }
}
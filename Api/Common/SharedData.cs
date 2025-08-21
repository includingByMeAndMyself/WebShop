namespace Api.Common;

public static class SharedData
{
    public static class Role
    {
        public const string Admin = "admin";
        public const string Consumer = "consumer";

        public static IReadOnlyList<string> AllRoles => new List<string>(2) { Admin, Consumer };
    }

    public static class OrderStatus
    {
        public const string Pending = "pending";
        public const string ReadyToShip = "ready_to_ship";
        public const string Completed = "completed";
        
        public static IReadOnlyList<string> AllStatus => new List<string>(3) { Pending, ReadyToShip, Completed };
    }
}
namespace Api.Common;

public static class SharedData
{
    public static class Role
    {
        public const string Admin = "admimn";
        public const string Consumer = "consumer";

        public static IReadOnlyList<string> AllRoles => new List<string>(2) { Admin, Consumer };
    }
}
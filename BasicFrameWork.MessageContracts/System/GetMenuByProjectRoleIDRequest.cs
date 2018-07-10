namespace BasicFramework.MessageContracts
{
    public class GetMenuByRoleIDRequest
    {
        public long RoleID { get; set; }

        public bool GetAll { get; set; }
    }
}
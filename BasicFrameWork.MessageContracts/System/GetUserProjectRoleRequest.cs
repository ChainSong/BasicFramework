namespace BasicFramework.MessageContracts
{
    public class GetUserProjectRoleRequest
    {
        public long UserID { get; set; }

        public long ProjectID { get; set; }
    }
}
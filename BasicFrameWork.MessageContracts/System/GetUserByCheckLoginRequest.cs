namespace BasicFramework.MessageContracts
{
    public class GetUserByCheckLoginRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool State { get; set; }
    }
}
namespace PhysicalLibrary.Members
{
    public class MemberRequest
    {
        public required string LastName { get; set; } = string.Empty;
        public required string FirstName { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
    }
}

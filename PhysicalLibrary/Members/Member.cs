namespace PhysicalLibrary.Members
{
    public class Member : IMember
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

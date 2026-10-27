namespace PhysicalLibrary.Members
{
    public interface IMember
    {
        Guid Id { get; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string Email { get; set; }
    }
}

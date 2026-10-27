namespace PhysicalLibrary.Members
{
    public interface IMemberRepository
    {
        IMember? GetMemberById(Guid id);
        bool IsMemberExists(string email);
        void AddMember(IMember member);

    }
}

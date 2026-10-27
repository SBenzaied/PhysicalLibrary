namespace PhysicalLibrary.Members
{
    public interface IMemberService
    {
        IMember CreateMember(MemberRequest memberRequest);
        IMember GetMemberById(Guid id);
    }
}

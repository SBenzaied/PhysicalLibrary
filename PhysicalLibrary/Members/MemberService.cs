using PhysicalLibrary.Books;

namespace PhysicalLibrary.Members
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
        }

        public IMember CreateMember(MemberRequest memberRequest)
        {
            ArgumentNullException.ThrowIfNull(memberRequest);
            if (memberRepository.IsMemberExists(memberRequest.Email))
                throw new InvalidOperationException($"A member with {memberRequest.Email} already exists");

            IMember member = new Member
            {
                LastName = memberRequest.LastName,
                FirstName = memberRequest.FirstName,
                Email = memberRequest.Email
            };

            memberRepository.AddMember(member);
            return member;
        }

        public IMember GetMemberById(Guid id)
        {
            return memberRepository.GetMemberById(id) ?? throw new KeyNotFoundException("Member not found");
        }
    }

}

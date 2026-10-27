using PhysicalLibrary.Data;

namespace PhysicalLibrary.Members
{
    public class MemberRepository : IMemberRepository
    {
        private PhysicalLibraryDbContext _context;

        public MemberRepository(PhysicalLibraryDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddMember(IMember member)
        {
            ArgumentNullException.ThrowIfNull(member);
            _context.Members.Add((Member)member);
            _context.SaveChanges();
        }

        public IMember? GetMemberById(Guid id) => _context.Members.Find(id);

        public bool IsMemberExists(string email) => _context.Members.Any(m => m.Email == email);
    }
}

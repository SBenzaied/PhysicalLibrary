using Microsoft.AspNetCore.Mvc;

namespace PhysicalLibrary.Members
{
    [ApiController]
    [Route("api/members")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(Guid id)
        {
            try
            {
                return Ok(_memberService.GetMemberById(id));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateMember(MemberRequest memberRequest)
        {
            ArgumentNullException.ThrowIfNull(memberRequest);
            try
            {
                IMember member = _memberService.CreateMember(memberRequest);
                return CreatedAtAction(nameof(GetMemberById), new { id = member.Id }, member);

            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}

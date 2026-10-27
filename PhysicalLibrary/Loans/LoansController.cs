using Microsoft.AspNetCore.Mvc;

namespace PhysicalLibrary.Loans
{
    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService ?? throw new ArgumentNullException(nameof(loanService));
        }

        [HttpGet("{id}")]
        public IActionResult GetLoanById(Guid id)
        {
            try
            {
                return Ok(_loanService.GetLoanById(id));
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Borrow(LoanRequest loanRequest)
        {
            ArgumentNullException.ThrowIfNull(loanRequest);
            try
            {
                ILoan loan = _loanService.Borrow(loanRequest);
                return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }


    }
}

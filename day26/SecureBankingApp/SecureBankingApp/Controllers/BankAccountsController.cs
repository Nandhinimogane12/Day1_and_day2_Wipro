using Microsoft.AspNetCore.Mvc;
using SecureBankingApp.Data;
using SecureBankingApp.Models;

namespace SecureBankingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BankAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BankAccount account)
        {
            _context.BankAccounts.Add(account);
            await _context.SaveChangesAsync();
            return Ok(account);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.BankAccounts.ToList());
        }
    }
}
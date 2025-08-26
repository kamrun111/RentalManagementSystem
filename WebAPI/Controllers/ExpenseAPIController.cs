using Building.DataAccess.Repository.IRepository;
using Building.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseAPIController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _unitOfWork.Expense.GetAllAsync();
            if (expenses == null || !expenses.Any())
            {
                return NotFound(new { message = "No expenses found." });
            }
            return Ok(expenses);
        }


        // GET: api/ExpenseAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _unitOfWork.Expense.GetFirstOrDefaultAsync(e => e.ExpenseId == id);
            if (expense == null)
            {
                return NotFound(new { message = $"Expense with ID {id} not found." });
            }
            return Ok(expense);
        }


        [HttpPost]
        public async Task<ActionResult<Expense>> CreateExpense(Expense expense)
        {
            try
            {
                if (expense == null)
                {
                    return BadRequest(new { message = "Expense data is required." });
                }
                await _unitOfWork.Expense.AddAsync(expense);
                await _unitOfWork.SaveAsync();  // Save changes
                return Ok(expense);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error creating expense: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Expense>> UpdateExpense(int id, Expense expense)
        {
            try
            {
                if (id != expense.ExpenseId)
                {
                    return BadRequest(new { message = "Expense ID mismatch." });
                }
                var existingExpense = await _unitOfWork.Expense.GetFirstOrDefaultAsync(e => e.ExpenseId == id);
                if (existingExpense == null)
                {
                    return NotFound();
                }

                existingExpense.ExpenseName = expense.ExpenseName;
                //existingExpense.Amount = expense.Amount;
                //existingExpense.Date = expense.Date;
                _unitOfWork.Expense.Update(existingExpense);

                await _unitOfWork.SaveAsync();  // Save changes asynchronously
                return Ok(expense);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error updating expense: " + ex.Message });
            }
        }

        // DELETE: api/ExpenseAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            try
            {
                var expense = await _unitOfWork.Expense.GetFirstOrDefaultAsync(e => e.ExpenseId == id);
                if (expense == null)
                {
                    return NotFound(new { message = $"Expense with ID {id} not found." });
                }

                _unitOfWork.Expense.Remove(expense);
                await _unitOfWork.SaveAsync();  // Save changes asynchronously
                return Ok(new { message = "Expense deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error deleting expense: " + ex.Message });
            }
        }
    }
}

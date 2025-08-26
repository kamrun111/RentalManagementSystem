using Building.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BuildingBalance.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpenseController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _url;
        public ExpenseController(HttpClient client, IConfiguration configuration)
        {
            _client =client;
            _url = configuration["ApiBaseUrl"]; // root url for TestAPI
        }

        [HttpGet]    // Use async method to make API call
        public async Task<IActionResult> Index()
        {
            List<Expense> expenseList = new List<Expense>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{_url}/ExpenseAPI"); // Asynchronous API call
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();  // Read response content asynchronously
                    var data = JsonConvert.DeserializeObject<List<Expense>>(result);

                    if (data != null)
                    {
                        expenseList = data;
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable to fetch data from the API. Please try again later.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
            }

            return View(expenseList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _client.PostAsJsonAsync($"{_url}/ExpenseAPI", expense);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["success"] = "Data Saved Successfully";
                        return RedirectToAction(nameof(Index)); // Redirect to Index view after successful creation
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Unable to create the expense. Please try again later.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                }
            }
            return View(expense);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            try
            {
                // Get the existing data to edit
                HttpResponseMessage response = await _client.GetAsync($"{_url}/ExpenseAPI/{id}");

                if (response.IsSuccessStatusCode)
                {

                    var expense = await response.Content.ReadFromJsonAsync<Expense>();
                    return View(expense);
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable to retrieve the expense details. Please try again later.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _client.PutAsJsonAsync($"{_url}/ExpenseAPI/{expense.ExpenseId}", expense);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["success"] = "Data Updated Successfully";
                        return RedirectToAction(nameof(Index)); // Redirect to Index view after successful update
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Unable to update the expense. Please try again later.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                }
            }
            return View(expense);
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
             
                HttpResponseMessage response = await _client.GetAsync($"{_url}/ExpenseAPI/{id}");   // Send a GET request to the API to retrieve the expense details

                if (response.IsSuccessStatusCode)
                {
                    var expense = await response.Content.ReadFromJsonAsync<Expense>();

                    if (expense != null)
                    {
                        return View(expense); // Return the view with the expense details
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Expense not found.";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable to retrieve the expense details. Please try again later.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
            }

            return RedirectToAction(nameof(Index)); // Redirect to Index view if there is an error
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            
                HttpResponseMessage response = await _client.GetAsync($"{_url}/ExpenseAPI/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var expense = await response.Content.ReadFromJsonAsync<Expense>();//This is a method that reads the content (which is typically in JSON format) from the response and converts it into an object of type Expense.

                    if (expense != null)
                    {
                        return View(expense); 
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Expense not found.";
                        return RedirectToAction(nameof(Index)); 
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable to retrieve the expense details for deletion. Please try again later.";
                    return RedirectToAction(nameof(Index)); 
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return RedirectToAction(nameof(Index)); 
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (!User.IsInRole("Admin"))
                {
                    // If the user does not have permission, set an error message
                    TempData["error"] = "You do not have permission to delete this record.";
                    return RedirectToAction("Details", new { id = id });  // Redirect to the details page of the current record
                }
                //if (User?.Identity?.IsAuthenticated != true)
                //{

                //    return RedirectToAction("Login", "Account", new { area = "Identity" });
                //}
                // Send a DELETE request to remove the expense
                HttpResponseMessage response = await _client.DeleteAsync($"{_url}/ExpenseAPI/{id}");

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Expense deleted successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable to delete the expense. Please try again later.";
                    return RedirectToAction(nameof(Index)); // Redirect on failure
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return RedirectToAction(nameof(Index)); // Redirect to Index on error
            }
        }





    }
}



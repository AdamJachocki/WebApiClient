using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using WebApp.Services;

namespace WebApp.Pages
{
    public class AddClientPageModel : PageModel
    {
        [BindProperty]
        public ClientDto ClientData { get; set; }
        [TempData]
        public string Error { get; set; }

        private readonly ClientService _service;

        public AddClientPageModel(ClientService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAddClientAsync()
        {
            var result = await _service.AddClient(ClientData);
            if (result.IsSuccess)
                return RedirectToPage("/Index");
            else
            {
                Error = result.ErrorMsg;
                return RedirectToPage();
            }
        }
    }
}

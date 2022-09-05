using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using WebApp.Services;

namespace WebApp.Pages
{
    public class ClientListModel : PageModel
    {
        public List<ClientDto> List { get; set; } = new();
        [TempData]
        public string Error { get; set; }
        [TempData]
        public string Info { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int Offset { get; set; } = 0;

        private readonly ClientService _service;

        public ClientListModel(ClientService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            await UpdateClientList();
        }

        private async Task UpdateClientList()
        {
            var response = await _service.GetClients(Offset);
            if(!response.IsSuccess)
                Error = response.ErrorMsg;
            else
                List = new List<ClientDto>(response.Data.Data);
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var response = await _service.DeleteClient(id);
            if(!response.IsSuccess)
            {
                Error = response.ErrorMsg;
                return Page();
            }

            Info = "Usuniêto klienta";
            return RedirectToPage();
        }
    }
}

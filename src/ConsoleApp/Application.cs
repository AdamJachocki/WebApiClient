using ApiClient.Abstractions;
using Common;
using ConsoleApp.Dialogs;
using ConsoleApp.Services;
using Microsoft.Extensions.Hosting;
using Models;

namespace ConsoleApp
{
    public class Application : IHostedService, IDisposable
    {
        private readonly MainMenu _mainMenu;
        private readonly ClientService _clientService;
        private bool disposedValue;

        public Application(MainMenu mainMenu, ClientService clientService)
        {
            _mainMenu = mainMenu;
            _mainMenu.OnAddClient = _mainMenu_OnAddClient;
            _mainMenu.OnProgramEnd = _mainMenu_OnProgramEnd;
            _mainMenu.OnListClients = _mainMenu_OnListClients;
            _mainMenu.OnClientDetails += _mainMenu_OnClientDetails;
            _mainMenu.OnRemoveClient += _mainMenu_OnRemoveClient;
            _clientService = clientService;
        }

        private void _mainMenu_OnRemoveClient(object? sender, int e)
        {
            throw new NotImplementedException();
        }

        private void _mainMenu_OnClientDetails(object? sender, int e)
        {
            throw new NotImplementedException();
        }

        private async Task _mainMenu_OnListClients()
        {
            int offset = 0;
            ConsoleKeyInfo choice;
            DataResponse<GetClientsResultDto> data;
            do
            {
                data = await _clientService.GetClientList(offset);
                if (!data.IsSuccess)
                {
                    if (data.StatusCode == 404)
                    {
                        ResetMenu("Nie ma więcej rekordów");
                        return;
                    }

                    ResetMenu("Błąd! " + data.ErrorMsg);
                    return;
                }

                ShowClientList(data.Data.Data);
                offset = data.Data.Offset;
                Console.WriteLine("D - Dalej; A - anuluj");
                choice = Console.ReadKey();
            } while (choice.Key == ConsoleKey.D);
        }

        private void ShowClientList(IEnumerable<ClientDto> data)
        { 
            foreach(var client in data)
            {
                Console.WriteLine($"ID: {client.Id}");
                Console.WriteLine($"Nazwisko: {client.Name}");
                Console.WriteLine("------------------------");
            }
        }

        private async Task _mainMenu_OnAddClient()
        {
            ClientDto data = AddClientDialog.ShowClientDialog();
            if(data == null)
            {
                ResetMenu("Anulowano");
                return;
            }

            var result = await _clientService.AddClient(data);
            if (result.IsSuccess)
                ResetMenu($"Dodano klienta, ID: {result.Data.Id}");
            else
                ResetMenu("Nie można było dodać klienta, błąd: " + result.ErrorMsg);
        }

        private void ResetMenu(string msg)
        {
            if(!string.IsNullOrWhiteSpace(msg))
            {
                Console.WriteLine(msg);
                Console.ReadKey();
            }

            Console.Clear();
            _mainMenu.ShowMenu();
        }

        private async Task _mainMenu_OnProgramEnd()
        {
            await this.StopAsync(CancellationToken.None);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _mainMenu.ShowMenu();
        }

        private void WriteMainScreen()
        {
            Console.Clear();
            Console.WriteLine("Test APIClient");
            Console.Write("==========");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _mainMenu.OnProgramEnd -= _mainMenu_OnProgramEnd;
                    _mainMenu.OnAddClient -= _mainMenu_OnAddClient;
                    _mainMenu.OnListClients -= _mainMenu_OnListClients;
                    _mainMenu.OnClientDetails -= _mainMenu_OnClientDetails;
                    _mainMenu.OnRemoveClient -= _mainMenu_OnRemoveClient;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Application()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

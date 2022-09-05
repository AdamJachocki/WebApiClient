namespace ConsoleApp
{
    public class MainMenu
    {
        public Func<Task> OnAddClient;
        public Func<int, Task> OnRemoveClient;
        public Func<Task> OnListClients;
        public Func<int, Task> OnClientDetails;

        public Func<Task> OnProgramEnd;

        public void ShowMenu()
        {
            Console.WriteLine("--- Klienci ---");
            Console.WriteLine("1. Dodaj nowego klienta");
            Console.WriteLine("2. Lista klientów");
            Console.WriteLine("3. Usuń klienta");
            Console.WriteLine("4. Pokaż szczegóły klienta");

            Console.WriteLine("--- Program ---");
            Console.WriteLine("0. Koniec");

            ProcessOption();
        }

        private void ProcessOption()
        {
            Console.Write("Wybierz opcję > ");
            int choice;

            if(!GetIntFromConsole(out choice) || (choice < 0 || choice > 4))
            {
                Console.WriteLine("Nieprawidłowy wybór... Wciśnij dowolny klawisz i spróbuj jeszcze raz...");
                Console.ReadKey();
                RewriteMenu();
                return;
            }

            switch(choice)
            {
                case 0:
                    OnProgramEnd();
                    break;

                case 1: 
                    OnAddClient();
                    break;

                case 2: 
                    OnListClients();
                    break;

                case 3:
                    {
                        int? id = GetId("Podaj id klienta do usunięcia");
                        if (!id.HasValue)
                            return;
                        OnRemoveClient(this, id.Value);
                    }
                    break;

                case 4:
                    {
                        int? id = GetId("Podaj id klienta");
                        if (!id.HasValue)
                            return;

                        OnClientDetails(id.Value);
                    }
                    break;                    
            }
        }        

        private void RewriteMenu()
        {
            Console.Clear();
            ShowMenu();
        }
    }
}

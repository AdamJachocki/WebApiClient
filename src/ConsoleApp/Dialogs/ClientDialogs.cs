using Models;

namespace ConsoleApp.Dialogs
{
    public class ClientDialogs
    {
        public static ClientDto ShowClientDialog()
        {
            ClientDto result = new ClientDto();
            Console.Clear();
            Console.WriteLine("===== Dodawanie nowego klienta =====");

            Console.WriteLine("Podaj nazwisko: ");
            result.Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(result.Name))
                return null;

            return result;
        }

        public static void ShowClientDetailsDialog(ClientDto data)
        {
            Console.Clear();
            Console.WriteLine($"==== Klient {data.Name} ====");
            Console.WriteLine($"ID: {data.Id}");

            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny klawisz...");
            Console.ReadKey();
        }

        public static int? ShowClientIdDialog()
        {
            Console.WriteLine("Podaj ID klienta: ");
            int id;
            if (!GetIntFromConsole(out id) || id <= 0)
            {
                Console.WriteLine("Nieprawidłowe ID. Wciśnij Esc, żeby anulować lub inny klawisz, żeby spróbować jeszcze raz");

                var choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.Escape)
                    return null;
                else
                    return ShowClientIdDialog();
            }

            return id;
        }

        private static bool GetIntFromConsole(out int result)
        {
            var strChoice = Console.ReadLine();

            if (!int.TryParse(strChoice, out result))
                return false;

            return true;
        }

    }
}

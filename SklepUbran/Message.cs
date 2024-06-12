using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepUbran
{
    public class Message
    {
        public Message()
        {
            CreateClients();
            CreateClothingItems();
        }

        public string answer { get; set; }
        public string answer_id { get; set; }
        public string answer_type { get; set; }
        public string answer_color { get; set; }
        public string answer_size { get; set; }
        public string answer_name { get; set; }
        public decimal answer_price { get; set; }
        public string answer_status { get; set; }

        public void WelcomeScreen()
        {
            Console.WriteLine();
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA KLIENTÓW I UBRAŃ");
            Console.WriteLine("2 => WYSZUKAJ ARTYKUŁ");
            Console.WriteLine("3 => DODAJ NOWEGO KLIENTA");
            Console.WriteLine("4 => DODAJ NOWY PRODUKT");
            Console.WriteLine("5 => USUŃ KLIENTA");
            Console.WriteLine("6 => USUŃ PRODUKT");
            Console.WriteLine("7 => MODYFIKUJ KLIENTA");
            Console.WriteLine("8 => MODYFIKUJ PRODUKT");
            Console.WriteLine("9 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2, 3, 4, 5, 6, 7, 8 LUB 9:");
            answer = Console.ReadLine();
        }

        public void IdClientScreen()
        {
            Console.Clear();
            Console.WriteLine("PROSZĘ PODAĆ ID KLIENTA:");
            answer_id = Console.ReadLine();
        }

        public void IdProductScreen()
        {
            Console.Clear();
            Console.WriteLine("PROSZĘ PODAĆ ID PRODUKTU:");
            answer_id = Console.ReadLine();
        }

        public void TypeScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ RODZAJ UBRAŃ (np. T-shirt, Jeans, Jacket):");
            answer_type = Console.ReadLine();
        }

        public void ColorScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ KOLOR UBRAŃ (np. Red, Blue, Black):");
            answer_color = Console.ReadLine();
        }

        public void SizeScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ ROZMIAR UBRAŃ (np. S, M, L, XL):");
            answer_size = Console.ReadLine();
        }

        public void NewClientScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ DANE NOWEGO KLIENTA");
            string id = GenerateNewClientId();
            Console.Write("Imię: ");
            string firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            string lastName = Console.ReadLine();

            Client newClient = new Client { Id = id, FirstName = firstName, LastName = lastName };
            AllClients.Add(newClient);
            SaveClients();
            Console.WriteLine("NOWY KLIENT DODANY POMYŚLNIE!");
        }

        public void NewProductScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ DANE NOWEGO PRODUKTU");
            string id = GenerateNewProductId();
            Console.Write("Nazwa: ");
            string name = Console.ReadLine();
            Console.Write("Rodzaj: ");
            string type = Console.ReadLine();
            Console.Write("Kolor: ");
            string color = Console.ReadLine();
            Console.Write("Rozmiar: ");
            string size = Console.ReadLine();
            Console.Write("Cena: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Status: ");
            string status = Console.ReadLine();

            ClothingItem newItem = new ClothingItem { Id = id, Name = name, Type = type, Color = color, Size = size, Price = price, Status = status };
            AllClothingItems.Add(newItem);
            SaveClothingItems();
            Console.WriteLine("NOWY PRODUKT DODANY POMYŚLNIE!");
        }

        public void DeleteClientScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ ID KLIENTA DO USUNIĘCIA:");
            string id = Console.ReadLine();
            Client client = AllClients.Find(c => c.Id == id);
            if (client != null)
            {
                AllClients.Remove(client);
                SaveClients();
                Console.WriteLine("KLIENT USUNIĘTY POMYŚLNIE!");
            }
            else
            {
                Console.WriteLine("KLIENT NIE ZNALEZIONY!");
            }
        }

        public void DeleteProductScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ ID PRODUKTU DO USUNIĘCIA:");
            string id = Console.ReadLine();
            ClothingItem item = AllClothingItems.Find(c => c.Id == id);
            if (item != null)
            {
                AllClothingItems.Remove(item);
                SaveClothingItems();
                Console.WriteLine("PRODUKT USUNIĘTY POMYŚLNIE!");
            }
            else
            {
                Console.WriteLine("PRODUKT NIE ZNALEZIONY!");
            }
        }

        public void ModifyClientScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ ID KLIENTA DO MODYFIKACJI:");
            string id = Console.ReadLine();
            Client client = AllClients.Find(c => c.Id == id);
            if (client != null)
            {
                Console.WriteLine($"AKTUALNE DANE: Imię: {client.FirstName}, Nazwisko: {client.LastName}");
                Console.Write("NOWE IMIĘ: ");
                client.FirstName = Console.ReadLine();
                Console.Write("NOWE NAZWISKO: ");
                client.LastName = Console.ReadLine();
                SaveClients();
                Console.WriteLine("DANE KLIENTA ZOSTAŁY ZAKTUALIZOWANE!");
            }
            else
            {
                Console.WriteLine("KLIENT NIE ZNALEZIONY!");
            }
        }

        public void ModifyProductScreen()
        {
            Console.Clear();
            Console.WriteLine("PODAJ ID PRODUKTU DO MODYFIKACJI:");
            string id = Console.ReadLine();
            ClothingItem item = AllClothingItems.Find(c => c.Id == id);
            if (item != null)
            {
                Console.WriteLine($"AKTUALNE DANE: Nazwa: {item.Name}, Rodzaj: {item.Type}, Kolor: {item.Color}, Rozmiar: {item.Size}, Cena: {item.Price}, Status: {item.Status}");
                Console.Write("NOWA NAZWA: ");
                item.Name = Console.ReadLine();
                Console.Write("NOWY RODZAJ: ");
                item.Type = Console.ReadLine();
                Console.Write("NOWY KOLOR: ");
                item.Color = Console.ReadLine();
                Console.Write("NOWY ROZMIAR: ");
                item.Size = Console.ReadLine();
                Console.Write("NOWA CENA: ");
                item.Price = Convert.ToDecimal(Console.ReadLine());
                Console.Write("NOWY STATUS: ");
                item.Status = Console.ReadLine();
                SaveClothingItems();
                Console.WriteLine("DANE PRODUKTU ZOSTAŁY ZAKTUALIZOWANE!");
            }
            else
            {
                Console.WriteLine("PRODUKT NIE ZNALEZIONY!");
            }
        }

        public void DisplaySearchedItems()
        {
            Console.Clear();
            Console.WriteLine("WYNIKI WYSZUKIWANIA:");
            Console.WriteLine("-----------------------------------");
            foreach (var item in AllClothingItems)
            {
                if ((string.IsNullOrEmpty(answer_type) || item.Type.ToLower() == answer_type.ToLower()) &&
                    (string.IsNullOrEmpty(answer_color) || item.Color.ToLower() == answer_color.ToLower()) &&
                    (string.IsNullOrEmpty(answer_size) || item.Size.ToLower() == answer_size.ToLower()))
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, Color: {item.Color}, Size: {item.Size}, Price: {item.Price}, Status: {item.Status}");
                }
            }
        }

        public void SearchItemScreen()
        {
            Console.Clear();
            Console.WriteLine("WYBIERZ KRYTERIUM WYSZUKIWANIA:");
            Console.WriteLine("1. Rodzaj");
            Console.WriteLine("2. Kolor");
            Console.WriteLine("3. Rozmiar");
            answer = Console.ReadLine();

            if (answer == "1")
            {
                TypeScreen();
                DisplaySearchedItems();
            }
            else if (answer == "2")
            {
                ColorScreen();
                DisplaySearchedItems();
            }
            else if (answer == "3")
            {
                SizeScreen();
                DisplaySearchedItems();
            }
            else
            {
                Console.WriteLine("NIEPRAWIDŁOWY WYBÓR!");
            }
        }

        public void DisplayLists()
        {
            Console.Clear();
            Console.WriteLine("LISTA KLIENTÓW:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Id | Imię i nazwisko");
            foreach (var clients in AllClients)
            {
                Console.WriteLine($"{clients.Id} | {clients.FirstName} {clients.LastName}");
            }
            Console.WriteLine();
            Console.WriteLine("LISTA PRODUKTÓW:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Id | Nazwa | Rodzaj | Kolor | Rozmiar | Cena | Status");
            foreach (var item in AllClothingItems)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Type} | {item.Color} | {item.Size} | {item.Price} | {item.Status}");
            }
        }

        public List<ClothingItem> AllClothingItems { get; set; }
        public List<Client> AllClients { get; set; }

        private void CreateClients()
        {
            var path = $"{Directory.GetCurrentDirectory()}//clients.json";
            var json = File.ReadAllText(path);
            AllClients = JsonConvert.DeserializeObject<List<Client>>(json);
        }

        private void SaveClients()
        {
            var path = $"{Directory.GetCurrentDirectory()}//clients.json";
            var json = JsonConvert.SerializeObject(AllClients, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private void CreateClothingItems()
        {
            var path = $"{Directory.GetCurrentDirectory()}//clothingItems.json";
            var json = File.ReadAllText(path);
            AllClothingItems = JsonConvert.DeserializeObject<List<ClothingItem>>(json);
        }

        private void SaveClothingItems()
        {
            var path = $"{Directory.GetCurrentDirectory()}//clothingItems.json";
            var json = JsonConvert.SerializeObject(AllClothingItems, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private string GenerateNewClientId()
        {
            int maxId = AllClients.Max(c => int.Parse(c.Id));
            return (maxId + 1).ToString();
        }

        private string GenerateNewProductId()
        {
            int maxId = AllClothingItems.Max(i => int.Parse(i.Id));
            return (maxId + 1).ToString();
        }
    }
}

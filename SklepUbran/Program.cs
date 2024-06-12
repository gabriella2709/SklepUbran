using SklepUbran;
var message = new Message();

while (true)
{
    message.WelcomeScreen();

    switch (message.answer)
    {
        case "1":
            message.DisplayLists();
            break;
        case "2":
            message.SearchItemScreen();
            break;
        case "3":
            message.NewClientScreen();
            break;
        case "4":
            message.NewProductScreen();
            break;
        case "5":
            message.DeleteClientScreen();
            break;
        case "6":
            message.DeleteProductScreen();
            break;
        case "7":
            message.ModifyClientScreen();
            break;
        case "8":
            message.ModifyProductScreen();
            break;
        case "9":
            return;
        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NIEPRAWIDŁOWY WYBÓR");
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
}
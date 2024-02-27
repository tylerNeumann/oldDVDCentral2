
using TN.DVDCentral.ConsoleApp;

internal class Program
{
    private static string DrawMenu()
    {
        Console.WriteLine("Which operation do you wish to perform?");
        Console.WriteLine("connect to a channel (c)");
        Console.WriteLine("send a message to the channel (s)");
        Console.WriteLine("Exit (x)");
        string operation = Console.ReadLine();
        return operation;
    }
    private static void Main(string[] args)
    {
        string user = "Neumann";
       // string hubAddress = "https://fvtcdp.azurewebsites.net/GameHub";
       //TODO: Finish fixing api and get the local host port
        string hubAddress = "https://localhost:0000/BingoHub";
        string operation = DrawMenu();

        var signalRConnection = new SignalRConnection(hubAddress);

        while(operation != "x") 
        {
            switch (operation)
            {
                case "c":
                    signalRConnection.ConnectToChannel(user);
                    break;
                case "s":
                    break;
                case "x":
                    break; 
            }

            operation = DrawMenu();
        }
    }
}
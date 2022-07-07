using Opc.UaFx.Client;

namespace OpcUa {

    public class Program {

        public static void Main() {
            string url = "opc.tcp://localhost:4840/";
            string dp = "ns=2;s=Temperature";

            try {
                Console.WriteLine("OPC UA sample client started successfully.");
                Console.WriteLine("Trying to connect to: " + url);
                using (var client = new OpcClient(url)) {
                    client.Connected += (s, e) => Console.WriteLine("Successfully connected to server!");
                    client.Disconnected += (s, e) => Console.WriteLine("Disconnected from server..");
                    client.Connect();

                    Console.WriteLine("Listening for datapoint: " + dp);
                    while (true) {
                        var value = client.ReadNode(dp);
                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " - " + value);

                        Thread.Sleep(1000);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            } finally {
                Console.WriteLine("Exiting..");
                Console.ReadKey();
            }
        }
    }
}
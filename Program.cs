    using System.Net;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.Json;

    namespace Serialization_and_RAF
    {
        public class Program
        {
            static void Main(string[] args)
            {
               //this is to give the current direactory.
                string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
               // created three different base in order to full-fill the requirements in the quesiton
                string pathTxt = basePath + "/event.txt";
                string pathNewTxt = basePath + "/newevent.txt";
                string pathJson = basePath + "/event.json";
                //Create event1
                Event event1 = new Event()
                {
                    EventNumber = 1,
                    Location = "Calgary"
                };
                // created list of events
                List<Event> events = new List<Event>()    
                {
                    new Event{ EventNumber =1 , Location = "Calgary"},
                    new Event{ EventNumber = 2, Location = "Toronto"},
                    new Event{ EventNumber = 3, Location = "Vancouver"},
                    new Event{ EventNumber = 4, Location = "Montreal"},
                    new Event{ EventNumber = 5,Location = "Banff"}
                };
                //Calling of functions is below!
                SerlizeEventUsingBinary(event1 ,pathTxt);
                DeSerlizeEventUsingBinary(pathTxt);
                SerlizationWithJson(events, pathJson);
                DeSerlizationWithJson(pathJson);
                ReadFromFile(pathNewTxt);
            }
            //Using Serlization
            public static void SerlizeEventUsingBinary(Event e , string path)
            {
                //Uusing BinaryFormatter
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using(FileStream fs = new FileStream(path , FileMode.Create))
                {
                    binaryFormatter.Serialize(fs, e);
                }
                //If you want to make sure that serialization is done , uncomment below line!
                //Console.WriteLine("Binary Serialization Done!");
            }
            //Deserlization in order to display the outcome
            public static void DeSerlizeEventUsingBinary(string path)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Event e1 =(Event)binaryFormatter.Deserialize(fs);
                    Console.WriteLine(e1.EventNumber +" \n"+ e1.Location);
                }
                //If you want to make sure that deserialization is done , uncomment below line!
                //Console.WriteLine("Binary deSerialization Done!");
            }
            //Serliaztion with Json File
            public static void SerlizationWithJson(List<Event> E ,string path)
            {
                string e = JsonSerializer.Serialize(E );
                File.WriteAllText(path, e);
                //If you want to make sure SerlizationwithJson is done, uncomment below line!
                //Console.WriteLine("Json Serlize done!");
            }
            //DeseerlziationWithJSon File
            public static void DeSerlizationWithJson(string path)
            {
                List<Event> E = JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(path));
                Console.WriteLine("Tech Competition");
                //If I don't Use for loop the it just shows some weird thing , I guess maye the location of the file
                //So using for loop to display every item in the file
                foreach (var item in E)
                {
                    Console.WriteLine(item);
                }
                //If you want to make sure that deserialization is done , uncomment below line!
                //Console.WriteLine("Json deSerialization Done!");
            }   
            //I don't know why is this called read form file, just solving question 5 and following the instructions
            public static void ReadFromFile(string path)
            {
                //Writng into file using StreamWriter
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Hackathon");
                }
                //Using file stream in order to get the desired outcome 
                //here FileAcess is read
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    Console.WriteLine("In Word: Hackathon ");

                    fs.Seek(0, SeekOrigin.Begin);
                    int FirstBytw = fs.ReadByte();
                    char firstchar = (char)FirstBytw;
                    Console.WriteLine("The First character is : " +   firstchar);

                    fs.Seek(4, SeekOrigin.Begin);
                    int secondBytw = fs.ReadByte();
                    char Seconfchar = (char)secondBytw;
                    Console.WriteLine("The Middle character is : " + Seconfchar);

                    fs.Seek(8, SeekOrigin.Begin);
                    int thirdBytw = fs.ReadByte();
                    char Thirdtchar = (char)thirdBytw;
                    Console.WriteLine("The last character is : " + Thirdtchar);
                };
            }
        }
    }

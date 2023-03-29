using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using ConsoleAppIntermediate.AbstractRuntimePolymorphismForDBConnection;
using ConsoleAppIntermediate.CommuncationChannelInterface;
using ConsoleAppIntermediate.InterfaceWithDependencyInjection;
using ConsoleAppIntermediate.LINQ;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ConsoleAppIntermediate.API;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleAppIntermediate
{
    public class Program
    {
        private delegate int Calculate(int number1, int number2);
        static void Main(string[] args)
        {
            

        }
        static void UseDelegate()
        {
            Program objProgram = new Program();
            Calculate addCalculate = new Calculate(objProgram.add);
            Calculate substractCalculate = new Calculate(objProgram.Subtract);
            Calculate multiplyCalculate = new Calculate(objProgram.multiply);
            Calculate divisionCalculate = new Calculate(objProgram.divide);
            Calculate allCalculate = addCalculate + substractCalculate + multiplyCalculate + divisionCalculate;

            Console.WriteLine($"Addition (456,230): {addCalculate(456, 230)}");
            Console.WriteLine($"Substarction (456,230): {substractCalculate(456, 230)}");
            Console.WriteLine($"Multiply (456,230): {multiplyCalculate(456, 230)}");
            Console.WriteLine($"Division (456,230): {divisionCalculate(456, 230)}");

            Console.WriteLine();
          
            Console.WriteLine("END");
           
        }
        private int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }
        private int add(int number1, int number2)
        {
            return number1 + number2;
        }

        private int multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        private int divide(int number1, int number2)
        {
            return number1 / number2;
        }
        static async Task USeHttpClient()
        {
            var accessToken = await UseHttpClientPostGetAccessToken();

            if (accessToken != null)
            {
                IEnumerable<User>? users = await UseHttpClientGetGraphUsers(accessToken);
                if (users != null)
                {
                    foreach (User user in users)
                    {
                        await Console.Out.WriteLineAsync("Display Name: " + user.displayName);
                        await Console.Out.WriteLineAsync("Given Name: " + user.givenName);
                        await Console.Out.WriteLineAsync("User Principal Name: " + user.userPrincipalName);
                        await Console.Out.WriteLineAsync("-----------------------------------------------------------------------");
                    }
                }
            }
        }
        static async Task<IEnumerable<User>?> UseHttpClientGetGraphUsers(string accessToken)
        {

            var getUsersUrl = "https://graph.microsoft.com/v1.0/users";
            IEnumerable<User>? users = null;

            try
            {

                using (HttpClient httpClient = new())
                {

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var resMsg = await httpClient.GetAsync(getUsersUrl);
                    var contentResult = await resMsg.Content.ReadAsStringAsync();

                    var userResult = JsonConvert.DeserializeObject<UserResult>(contentResult);
                    if (userResult != null)
                    {
                        users = userResult.value;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return users;
        }
        static async Task<string?> UseHttpClientPostGetAccessToken()
        {
            var client_id = "e83c56a6-1c63-41eb-99e3-c38a66707f98";
            var grant_type = "client_credentials";
            var client_secret = ".0l8Q~XFwsWltpshzjczWWbV~49kre~rf4OlXaXL";
            var scope = "https://graph.microsoft.com/.default";
            var getTokenUri = "https://login.microsoftonline.com/0eb01f43-ff72-45e6-bf9e-824093921fd6/oauth2/v2.0/token";

            string? accessToken;

            try
            {

                using (HttpClient httpClient = new())
                {
                    List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("client_id", client_id),
                        new KeyValuePair<string, string>("grant_type", grant_type),
                        new KeyValuePair<string, string>("client_secret", client_secret),
                        new KeyValuePair<string, string>("scope", scope)
                    };

                    HttpContent httpContent = new FormUrlEncodedContent(keyValuePairs);
                    var resMsg = await httpClient.PostAsync(getTokenUri, httpContent);
                    var contentResult = await resMsg.Content.ReadAsStringAsync();

                    AccessToken? objectAccessToken = JsonConvert.DeserializeObject<AccessToken>(contentResult);

                    accessToken = objectAccessToken != null ? objectAccessToken.access_token : null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                accessToken = null;
            }
            return accessToken;
        }
        static async Task<IEnumerable<Item>?> UseHttpClientSimpleGet()
        {
            IList<Item>? posts = null;
            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "https://jsonplaceholder.typicode.com/posts";

                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.RequestUri = new Uri(url);
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    Task<HttpResponseMessage> resMsg = httpClient.SendAsync(httpRequestMessage);

                    HttpResponseMessage content = resMsg.Result;
                    Task<string> contentResult = content.Content.ReadAsStringAsync();

                    if (contentResult != null)
                    {

                        posts = JsonConvert.DeserializeObject<List<Item>>(contentResult.Result);
                        if (posts != null)
                        {
                            await Console.Out.WriteLineAsync("Count : " + posts.Count);
                            foreach (Item post in posts)
                            {
                                await Console.Out.WriteLineAsync("Title : " + post.Title);
                            }

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                posts = null;
            }

            return posts;

        }
        static void DownloadWebpage(string url)
        {
            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            var html = httpClient.Send(httpRequest);
            Console.WriteLine(html.Content.ToString());

        }
        static void UseAsynchronous()
        {

        }
        static void UseLinq()
        {
            var bookRepository = new BookRepository();
            foreach (var book in bookRepository.GetBooks())
            {
                Console.WriteLine("Book : {0} | Price : {1}", book.Title, book.Price);
            }

            Console.WriteLine("Book Cheaper then 500.00");

            foreach (var book in (bookRepository.GetBooks()).Where(b => b.Price < 500))
            {
                Console.WriteLine("Book : {0} | Price : {1}", book.Title, book.Price);
            }

            Console.WriteLine("C# books");

            foreach (var book in (bookRepository.GetBooks()).Where(b => b.Title.Contains("C#")))
            {
                Console.WriteLine("Book : {0} | Price : {1}", book.Title, book.Price);
            }

            Console.WriteLine("Books by price");

            foreach (var book in (bookRepository.GetBooks()).OrderBy(b => b.Price))
            {
                Console.WriteLine("Book : {0} | Price : {1}", book.Title, book.Price);
            }

            var books = bookRepository.GetBooks();

            var bs = books.SingleOrDefault(b => b.Title == "ADO.Net Basic");
            if (bs != null)
                Console.WriteLine(bs.Title + "|" + bs.Price + "|");

            var totalBookCount = books.Select(b => b.Price).Sum();
            Console.WriteLine(totalBookCount.ToString());
        }
        static void UseWorkflowEngine()
        {
            WorkflowEngine wfEngine = new WorkflowEngine();
            wfEngine.AddActivity(new UploadVideo("Video Uploading"));
            wfEngine.AddActivity(new WFVideoEncoder("Video Encoder"));
            wfEngine.AddActivity(new NotifyVideoProcessing("Video Notify"));
            wfEngine.AddActivity(new ChangeVideoStatus("Video Status Change"));

            wfEngine.Run();
        }
        static void UseCommuncationChannelInterface()
        {
            Video video = new Video();

            VideoEncoder encoder = new VideoEncoder();
            encoder.AddChannel(new SMSServiceChannel());
            encoder.AddChannel(new MailServiceChannel());
            encoder.AddChannel(new TeamserviceChannel());

            encoder.Encode(video);
        }
        static void UseInterfaceWithDependencyInjection()
        {
            DbMigrator dbMigrator = new DbMigrator(new ConsoleLoger());
            dbMigrator.Migration();

            DbMigrator dbMigratorWithFile = new DbMigrator(new FileLoger("D:\\log.txt"));
            dbMigratorWithFile.Migration();
        }
        static void UseAbstractRuntimePolymorphismForDBConnection()
        {
            SqlConnection sqlDbConnection = new SqlConnection("(local)\\MSSQLSERVER;Database=HHelloWorld");
            DbCommand dbCommandSql = new DbCommand(sqlDbConnection, "Select * from TestEmployee");
            dbCommandSql.Execute();

            OracleConnection oracleDbConnection = new OracleConnection("(local)\\OracleSERVER;Database=HHelloWorld");
            DbCommand dbCommandOracle = new DbCommand(oracleDbConnection, "Select * from TestEmployee");
            dbCommandOracle.Execute();

            ManogDBConnection mangoDbConnection = new ManogDBConnection("(local)\\MangoSERVER;Database=HHelloWorld");
            DbCommand dbCommandManogo = new DbCommand(mangoDbConnection, "Select * from TestEmployee");
            dbCommandManogo.Execute();

        }
        static void UseStack()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            //stack.Push(null);

            Console.WriteLine(stack.Pop());

            stack.Push(3);
            stack.Push("Somnath sing");
            Console.WriteLine(stack.Pop());
            stack.Push(new Shape { Height = 1, Width = 2, X = 3, Y = 4 });
            stack.Push(true);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
        static void UseUpcastingDowncasting()
        {

            Shape shape = new Text();

            Text text = (Text)shape;

            shape.X = 10;
            shape.Y = 11;
            shape.Width = 100;
            shape.Height = 110;
            text.FontName = "Test";

            Console.WriteLine(text.X);
            Console.WriteLine(text.Y);
            Console.WriteLine(text.Width);
            Console.WriteLine(text.Height);
            Console.WriteLine(text.FontName);
        }
        static void UseConstructorInheritance()
        {
            var car = new Car("XYZ1234");
        }
        static void UsePost()
        {
            var post = new Post(1, "Rest get API threhold limit", "Have 5000 items threshold limit");

            post.UpVote();
            post.DownVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.DownVote();
            post.UpVote();
            post.DownVote();
            post.CurrentVoteValue();
        }
        static void UseStopWatch()
        {
            var stopWatch = new StopWatch();
            stopWatch.Start();
            Thread.Sleep(5000);
            stopWatch.Start();
            stopWatch.Stop();
            stopWatch.Stop();
            stopWatch.Stop();
            stopWatch.Start();
            stopWatch.Start();
            Thread.Sleep(2300);
            stopWatch.Stop();
        }
        static void UseIndexer()
        {
            var httpCookie = new HttpCookie();
            httpCookie.Expiry = DateTime.Now.AddHours(23);

            httpCookie["Name"] = "Test";

            Console.WriteLine("Expiry : " + httpCookie.Expiry.ToString());
            Console.WriteLine("Cookie Name : " + httpCookie["Name"]);
        }
        static void UseCustomer()
        {
            var customer = new Customer();
            customer.Id = 1;
            customer.Name = "Somnath Singh";
            customer.Address = "Bhagatpara";
            customer.Country = "India";
            customer.Region = "Jharkhand";
            customer.City = "Pakur";
            customer.Phone = "1234567890";
            customer.PostalCode = "12345";

            customer.Orders.Add(new Order
            {
                Id = 1,
                OrderName = "Test",
                Description = "Test"
            });

            Console.WriteLine(customer.Name);
        }
        static void UsePerson()
        {
            var person = new Person(new DateTime(1990, 12, 09))
            {
                Name = "Raji"
            };
            Console.WriteLine("Person Name : " + person.Name);
            Console.WriteLine("Person Age : " + person.Age);

        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GolfClub.Models;

namespace GolfClient
{
    class Program
    {
        static async Task GetsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62925/api/GolfClub/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                // GET: api/GolfClub/all
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfers = await response.Content.ReadAsAsync<IEnumerable<Golfer>>(); // add from Console line
                    Console.WriteLine("*** Complete Golfer List ***");
                    foreach (Golfer g in returnedGolfers)
                    {
                        Console.WriteLine(g);
                    }
                }

                // GET: api/GolfClub/GetByGUI/11111111
                response = await client.GetAsync("GetByGUI/11111111");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfer = await response.Content.ReadAsAsync<Golfer>(); // add from Console line
                    Console.WriteLine("\n*** Golfer with GUI of 11111111 is ***");
                    Console.WriteLine(returnedGolfer);
                }


                // POST: api/GolfClub/AddMember
                Golfer g1 = new Golfer() { GUI = 55555555, FirstName = "Andrew", Surname = "Breen", Handicap = 45, DateJoined = new DateTime(2020, 02, 02), Membership = MemberType.Patron, YearlyFees = 2000 };
                response = client.PostAsJsonAsync("AddMember", g1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golfer: " + g1.FirstName + " " + g1.Surname); 
                }


                // PUT: api/GolfClub/UpdateMember/11111111
                Golfer g2 = new Golfer() { GUI = 11111111, FirstName = "Rick", Surname = "Ross", Handicap = 3, DateJoined = new DateTime(2020, 02, 02), Membership = MemberType.Patron, YearlyFees = 2000 };
                response = client.PutAsJsonAsync("UpdateMember/11111111", g2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golfer: " + g2.FirstName + " " + g2.Surname);
                }


                // DELETE: api/GolfClub/DeleteMember/33333333
                response = await client.GetAsync("GetByGUI/33333333");
                var returnGolfer = await response.Content.ReadAsAsync<Golfer>();

                response = client.DeleteAsync("DeleteMember/33333333").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golfer: "+ returnGolfer.FirstName + " " + returnGolfer.Surname);
                }
            }
        }

        static void Main()
        {
            GetsAsync().Wait();
            Console.ReadLine();
        }
    }
}

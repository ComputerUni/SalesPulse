using Dapper;
using Microsoft.Data.SqlClient;

namespace SalesPulse.DataSeeder
{
    public class CustomerSeeder
    {
        public static async Task CustomerSeederAsync(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Müşteriler üretiliyor...");

            var firstNames = new[] {
                "Ahmet","Mehmet","Mustafa","Ali","Hüseyin","Hasan","İbrahim","İsmail","Ömer","Yusuf",
                "Ayşe","Fatma","Emine","Hatice","Zeynep","Elif","Merve","Esra","Büşra","Selin",
                "Murat","Emre","Burak","Serkan","Tolga","Cem","Berk","Kaan","Furkan","Eren",
                "Gamze","Derya","Özlem","Sibel","Pınar","Gül","Nur","Yıldız","Aslı","Ceren"
            };

            var lastNames = new[] {
                "Yılmaz","Kaya","Demir","Çelik","Şahin","Yıldız","Yıldırım","Öztürk","Aydın","Özdemir",
                "Arslan","Doğan","Kılıç","Aslan","Çetin","Kara","Koç","Kurt","Özkan","Şimşek",
                "Polat","Erdoğan","Güneş","Akın","Çakır","Bulut","Korkmaz","Kaplan","Acar","Aktaş"
            };

            var random = new Random();
            var customers = new List<object>();

            for (int i = 1; i <= 100000; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                string username = $"{firstName.ToLower()}{lastName.ToLower()}{i}";
                string email = $"{username}@mail.com";
                string imageUrl = $"https://avatars.dicebear.com/api/initials/{firstName}-{lastName}.svg";
                int cityId = random.Next(1, 82);

                if (random.Next(100) < 30)
                    cityId = new[] { 34, 35, 6, 7, 16, 41, 27, 38, 55, 42 }[random.Next(10)];

                customers.Add(new
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Username = username,
                    ImageUrl = imageUrl,
                    CityId = cityId,
                    CreatedAt = DateTime.Now.AddDays(-random.Next(1, 1825))
                });
            }

            await connection.ExecuteAsync(
                "INSERT INTO Customers (FirstName, LastName, Email, Username, ImageUrl, CityId, CreatedAt) VALUES (@FirstName, @LastName, @Email, @Username, @ImageUrl, @CityId, @CreatedAt)",
                customers);

            Console.WriteLine("100.000 müşteri eklendi.");
        }
    }
}

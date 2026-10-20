using Dapper;
using Microsoft.Data.SqlClient;

namespace SalesPulse.DataSeeder
{
    public class ProductSeeder
    {
        public static async Task ProductSeederAsync(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Ürünler üretiliyor...");

            var productTypes = new Dictionary<int, string[]>
            {
                {1, new[]{"Kulaklık","Hoparlör","Şarj Aleti","Kablo","Adaptör"}},
                {2, new[]{"Laptop","Tablet","Klavye","Mouse","Monitör"}},
                {3, new[]{"Telefon Kılıfı","Ekran Koruyucu","Şarj Kablosu","Powerbank","Telefon"}},
                {4, new[]{"LED TV","OLED TV","Projeksiyon","Soundbar","Kumanda"}},
                {5, new[]{"Bulaşık Makinesi","Çamaşır Makinesi","Buzdolabı","Fırın","Davlumbaz"}},
                {6, new[]{"Tost Makinesi","Blender","Süpürge","Ütü","Hava Fryer"}},
                {7, new[]{"Koltuk","Masa","Sandalye","Yatak","Dolap"}},
                {8, new[]{"Nevresim","Yastık","Battaniye","Havlu","Perde"}},
                {9, new[]{"Tencere","Tava","Bıçak Seti","Bardak","Tabak"}},
                {10, new[]{"Çim Biçme","Hortum","Bahçe Eldiveni","Kürek","Sulama"}},
                {11, new[]{"Koşu Ayakkabısı","Spor Çanta","Dumbbell","Yoga Matı","Bisiklet"}},
                {12, new[]{"Roman","Ders Kitabı","Çocuk Kitabı","Ansiklopedi","Dergi"}},
                {13, new[]{"Lego","Bebek","Araba","Puzzle","Oyun Seti"}},
                {14, new[]{"Tişört","Gömlek","Pantolon","Elbise","Mont"}},
                {15, new[]{"Spor Ayakkabı","Bot","Topuklu","Çanta","Cüzdan"}},
                {16, new[]{"Parfüm","Krem","Şampuan","Makyaj","Serum"}},
                {17, new[]{"Bebek Arabası","Mama Sandalyesi","Biberon","Bez","Oyuncak"}},
                {18, new[]{"Motor Yağı","Araba Kılıfı","Oto Parfüm","Lastik","Aksesuar"}},
                {19, new[]{"Kalem","Defter","Dosya","Zımba","Hesap Makinesi"}},
                {20, new[]{"Kahve","Çay","Kuruyemiş","Çikolata","Atıştırmalık"}},
                {21, new[]{"Kedi Maması","Köpek Maması","Kafes","Tasma","Oyuncak"}},
                {22, new[]{"Kol Saati","Kolye","Bileklik","Yüzük","Küpe"}},
                {23, new[]{"Gitar","Piyano","Tuval","Boya Seti","Müzik Seti"}},
                {24, new[]{"PlayStation","Xbox","Nintendo","Oyun CD","Joystick"}},
                {25, new[]{"Film DVD","Müzik CD","Vinyl","Blu-ray","Kaset"}},
                {26, new[]{"Antivirüs","Office","Windows","Tasarım Yazılımı","Eğitim Yazılımı"}},
                {27, new[]{"DSLR Fotoğraf Makinesi","Lens","Tripod","Flaş","Hafıza Kartı"}},
                {28, new[]{"Vitamin","Protein Tozu","Takviye","Medikal Cihaz","Masaj Aleti"}},
                {29, new[]{"Avize","Abajur","LED Panel","Spot","Gece Lambası"}},
                {30, new[]{"Boya","Çimento","Ahşap Panel","Vida Seti","Boru"}}
            };

            var categoryBrands = new Dictionary<int, string[]>
            {
                {1, new[]{"Samsung","Sony","JBL","Huawei","Xiaomi","Anker","Philips"}},
                {2, new[]{"Asus","HP","Dell","Lenovo","Apple","Huawei","MSI"}},
                {3, new[]{"Samsung","Apple","Huawei","Xiaomi","Anker","Spigen"}},
                {4, new[]{"Samsung","LG","Sony","Vestel","Arçelik","Philips"}},
                {5, new[]{"Bosch","Arçelik","Beko","Vestel","Samsung","LG"}},
                {6, new[]{"Tefal","Philips","Bosch","Arçelik","Dyson","Karaca"}},
                {7, new[]{"Ikea","Bellona","İstikbal","Mondi","Doğtaş"}},
                {8, new[]{"Karaca","Ikea","English Home","Özdilek","Taç"}},
                {9, new[]{"Karaca","Tefal","Ikea","Korkmaz","Schafer"}},
                {10, new[]{"Bosch","Husqvarna","Fiskars","Ikea","Wolf"}},
                {11, new[]{"Nike","Adidas","Puma","Decathlon","Under Armour"}},
                {12, new[]{"İş Bankası Kültür","Yapı Kredi Yayınları","Pegasus","Tudem","Can Yayınları"}},
                {13, new[]{"Lego","Mattel","Fisher Price","Hasbro","Dolu"}},
                {14, new[]{"Zara","Mavi","LC Waikiki","Koton","Defacto","Nike","Adidas"}},
                {15, new[]{"Nike","Adidas","Zara","Steve Madden","Kinetix"}},
                {16, new[]{"L'Oreal","Nivea","Maybelline","Mac","Flormar"}},
                {17, new[]{"Chicco","Graco","Bebetto","Maxi-Cosi","Pampers"}},
                {18, new[]{"Bosch","Castrol","Shell","Michelin","Pirelli"}},
                {19, new[]{"Pilot","Staedtler","Casio","Pentel","Kraf"}},
                {20, new[]{"Ülker","Nestle","Jacobs","Doğadan","Tadım"}},
                {21, new[]{"Royal Canin","Purina","Hills","Whiskas","Pedigree"}},
                {22, new[]{"Casio","Fossil","Swatch","Michael Kors","Atasay"}},
                {23, new[]{"Yamaha","Gibson","Fender","Roland","Pearl"}},
                {24, new[]{"Sony","Microsoft","Nintendo","Razer","Logitech"}},
                {25, new[]{"Sony","Warner","Universal","Disney","EMI"}},
                {26, new[]{"Microsoft","Kaspersky","Adobe","Corel","Eset"}},
                {27, new[]{"Canon","Nikon","Sony","Fujifilm","Olympus"}},
                {28, new[]{"Now","Orzax","Solgar","Doctor's Best","Nutraxin"}},
                {29, new[]{"Philips","Osram","Ledvance","Eglo","Trio"}},
                {30, new[]{"Knauf","Weber","Hilti","Makita","Bosch"}}
            };

            var categoryPrices = new Dictionary<int, (int Min, int Max)>
            {
                {1, (50, 3000)},
                {2, (3000, 50000)},
                {3, (50, 5000)},
                {4, (1000, 40000)},
                {5, (2000, 30000)},
                {6, (200, 5000)},
                {7, (500, 20000)},
                {8, (100, 2000)},
                {9, (100, 3000)},
                {10, (50, 2000)},
                {11, (100, 5000)},
                {12, (20, 200)},
                {13, (50, 1000)},
                {14, (50, 2000)},
                {15, (100, 3000)},
                {16, (30, 1000)},
                {17, (50, 5000)},
                {18, (100, 5000)},
                {19, (10, 500)},
                {20, (10, 500)},
                {21, (20, 500)},
                {22, (100, 10000)},
                {23, (200, 10000)},
                {24, (200, 10000)},
                {25, (20, 200)},
                {26, (50, 3000)},
                {27, (500, 30000)},
                {28, (30, 1000)},
                {29, (50, 3000)},
                {30, (20, 2000)}
            };


            var random = new Random();
            var usedNames = new HashSet<string>();
            var products = new List<(string Name, int Stock, decimal Price, int CategoryId, bool IsActive)>();

            while (products.Count < 5000)
            {
                int categoryId = random.Next(1, 31);
                string brand = categoryBrands[categoryId][random.Next(categoryBrands[categoryId].Length)];
                string type = productTypes[categoryId][random.Next(productTypes[categoryId].Length)];
                string model = $"{(char)('A' + random.Next(26))}{random.Next(100, 999)}";
                string name = $"{brand} {type} {model}";

                if (usedNames.Contains(name)) continue;
                usedNames.Add(name);

                int stock = random.Next(1, 501);
                var (minPrice, maxPrice) = categoryPrices[categoryId];
                decimal price = Math.Round((decimal)(random.Next(minPrice, maxPrice) + random.NextDouble()), 2);
                bool isActive = random.Next(10) > 1;

                products.Add((name, stock, price, categoryId, isActive));
            }

            await connection.ExecuteAsync(
                "INSERT INTO Products (Name, Stock, Price, CategoryId, IsActive) VALUES (@Name, @Stock, @Price, @CategoryId, @IsActive)",
                products.Select(p => new { p.Name, p.Stock, p.Price, p.CategoryId, p.IsActive }).ToList());

            Console.WriteLine("5000 ürün eklendi.");
        }
    }
}

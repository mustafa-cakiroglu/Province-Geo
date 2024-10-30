using System.Text.Json;
using ProvinceTest;
using ProvinceTest.Model;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string filePath = "C:\\Users\\MustafaÇakıroğlu\\Desktop\\v\\turkey-geo.json";
        var proviceJsonList = DeserializeJsonFile(filePath);

        if (proviceJsonList == null || !proviceJsonList.Any())
        {
            Console.WriteLine("JSON verisi boş veya hatalı.");
            return;
        }

        try
        {
            using (var context = new ApplicationDbContext())
            {
                var provinceList = context.Provinces.ToList();
                InsertDistrictsAndNeighborhoods(context, provinceList, proviceJsonList);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }
    }

    private static List<Root> DeserializeJsonFile(string filePath)
    {
        try
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Root>>(jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JSON dosyası okunamadı: {ex.Message}");
            return null;
        }
    }

    private static void InsertDistrictsAndNeighborhoods(ApplicationDbContext context, List<Province> provinceList, List<Root> proviceJsonList)
    {
        var districtsToAdd = new List<District>();
        var neighborhoodsToAdd = new List<Neighborhood>();

        foreach (var province in provinceList)
        {
            var districtList = proviceJsonList.FirstOrDefault(x => x.PlateNumber == province.Id);

            if (districtList == null) continue;

            foreach (var districtModel in districtList.Districts)
            {
                var district = new District
                {
                    Name = districtModel.District,
                    ProvinceId = province.Id,
                    IsDeleted = false
                };
                districtsToAdd.Add(district);
                context.Districts.Add(district);

                foreach (var town in districtModel.Towns)
                {
                    foreach (var neighbourhoodName in town.Neighbourhoods)
                    {
                        var neighborhood = new Neighborhood
                        {
                            DistrictId= district.Id,
                            Name = neighbourhoodName,
                            IsDeleted = false
                        };
                        neighborhoodsToAdd.Add(neighborhood);
                    }
                }
            }
        }

        // Toplu olarak ekleme ve kaydetme
        context.Districts.AddRange(districtsToAdd);
        context.Neighborhoods.AddRange(neighborhoodsToAdd);

        context.SaveChanges();
        Console.WriteLine("Tüm veriler başarıyla eklendi!");
    }
}

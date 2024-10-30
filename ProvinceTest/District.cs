namespace ProvinceTest
{
    public class Root
    {
        public string Province { get; set; }
        public int PlateNumber { get; set; }
        public string Coordinates { get; set; }
        public List<DistrictModel> Districts { get; set; }
    }

    public class DistrictModel
    {
        public string District { get; set; }
        public string Coordinates { get; set; }
        public List<TownModel> Towns { get; set; }
    }

 

    public class TownModel
    {
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public List<string> Neighbourhoods { get; set; }
    }
}

namespace AppCore.DTO
{
    public class NewsFilter
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int Page { get; set; } = 1;
    }
}

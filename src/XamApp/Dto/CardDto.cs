namespace XamApp.Dto
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CVV2 { get; set; }
    }
}

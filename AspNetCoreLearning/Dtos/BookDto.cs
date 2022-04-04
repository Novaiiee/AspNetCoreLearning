namespace AspNetCoreLearning.Dtos
{
    public record BookDto
    {
        public string Name { get; set; }  
        public string Id { get; set; }  
        public decimal Price { get; set; }  
    }
}

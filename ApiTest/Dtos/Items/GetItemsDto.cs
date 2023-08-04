namespace ApiTest.Dtos.Items
{
    public class GetItemsDto
    {
        public int Id { get; set; }

        public string? ItemDescription { get; set; }

        public bool? ItemState { get; set; }
    }
}

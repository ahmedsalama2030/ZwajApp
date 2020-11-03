namespace ZwajApp.API.Dtos
{
    public class PhotoForDetailsDTO
    {
        public int id{get;set;}
        public string  Url { get; set; }
        public string  Description { get; set; }
        public string  DateAdded { get; set; }
        public string  IsMain { get; set; }
    }
}
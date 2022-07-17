namespace IranCafe.Application.Contract
{
    public class EntityBaseDto
    {
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}
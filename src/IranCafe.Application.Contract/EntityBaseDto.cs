namespace IranCafe.Application.Contract
{
    public class EntityBaseDto
	{
        public Guid Id { get; private set; }
        public bool IsDelete { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime DeletionDate { get; private set; }
    }
}
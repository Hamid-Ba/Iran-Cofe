using System;
using Framework.Domain;

namespace IranCafe.Domain.CafeAgg
{
	public class MenuItem : EntityBase
	{
        public Guid CafeId { get;private set; }
        public Guid CategoryId { get;private set; }
        public string ImageName { get;private set; }
        public string Title { get;private set; }
        public string ShortDesc { get;private set; }
        public double Price { get;private set; }
        public bool IsActive { get;private set; }
    }
}


using System;
using Framework.Domain;

namespace IranCafe.Domain.CafeAgg
{
	public class Category : EntityBase
	{
        public string Title { get;private set; }
        public string Slug { get;private set; }
        public string ShortDesc { get;private set; }

        //List Of Items
    }
}


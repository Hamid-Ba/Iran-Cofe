using System.ComponentModel.DataAnnotations;

namespace Framework.Domain.Cafe
{
    public enum CafeStatus
	{
        [Display(Name = "رد شده")]
		Reject,
		[Display(Name = "در حال بررسی")]
		Pending,
		[Display(Name = "تایید شده")]
		Confirmed
	}
}


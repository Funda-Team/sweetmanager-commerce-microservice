using System;
using System.Collections.Generic;

namespace CommerceService;

public partial class PaymentOwner
{
    public int Id { get; set; }

    public int? OwnersId { get; set; }

    public string? Description { get; set; }

    public decimal? FinalAmount { get; set; }
}

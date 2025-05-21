using System;
using System.Collections.Generic;

namespace CommerceService;

public partial class PaymentCustomer
{
    public int Id { get; set; }

    public int? CustomersId { get; set; }

    public decimal? FinalAmount { get; set; }
}

using System;
using System.Collections.Generic;

namespace CommerceService;

public partial class ContractOwner
{
    public int Id { get; set; }

    public int? SubscriptionsId { get; set; }

    public int? OwnersId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public string? State { get; set; }

    public virtual Subscription? Subscriptions { get; set; }
}

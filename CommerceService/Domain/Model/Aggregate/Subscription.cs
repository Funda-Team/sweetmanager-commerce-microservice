using System;
using System.Collections.Generic;

namespace CommerceService;

public partial class Subscription
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? HotelId { get; set; }

    public string? State { get; set; }

    public virtual ICollection<ContractOwner> ContractOwners { get; set; } = new List<ContractOwner>();
}

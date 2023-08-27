using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Models;

public record UpdateOrderDto(
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantity);

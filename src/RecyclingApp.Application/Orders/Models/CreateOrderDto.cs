using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.Orders.Models;

public record CreateOrderDto(
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantities);
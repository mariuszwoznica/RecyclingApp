using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.RequestParamiters;

public record CreateOrderDto(
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantity);
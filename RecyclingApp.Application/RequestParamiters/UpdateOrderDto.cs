using System;
using System.Collections.Generic;

namespace RecyclingApp.Application.RequestParamiters;

public record UpdateOrderDto(
    IReadOnlyCollection<Guid> ProductIds,
    IReadOnlyCollection<int> Quantity);

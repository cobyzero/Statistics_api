using System;
using System.Collections.Generic;

namespace statistics_api.Src.Core.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

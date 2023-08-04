using System;
using System.Collections.Generic;

namespace ApiTest.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? ItemDescription { get; set; }

    public bool? ItemState { get; set; }
}

using System;
using System.Collections.Generic;

namespace efscaffold;

public partial class Todo
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public decimal Priority { get; set; }
}

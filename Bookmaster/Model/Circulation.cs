using System;
using System.Collections.Generic;

namespace Bookmaster.Model;

public partial class Circulation
{
    public int Id { get; set; }

    public string BookId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public DateOnly DateOfIssue { get; set; }

    public DateOnly DateOfReturn { get; set; }

    public int AdministratorId { get; set; }

    public virtual Administrator Administrator { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}

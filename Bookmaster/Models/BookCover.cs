﻿using System;
using System.Collections.Generic;

namespace Bookmaster.Model;

public partial class BookCover
{
    public int BookCoverId { get; set; }

    public string BookId { get; set; } = null!;

    public int CoverId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Cover Cover { get; set; } = null!;
}

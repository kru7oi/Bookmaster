using System;
using System.Collections.Generic;

namespace Bookmaster.Model;

public partial class Cover
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public virtual ICollection<BookCover> BookCovers { get; set; } = new List<BookCover>();
}

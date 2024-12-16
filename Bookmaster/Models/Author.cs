﻿using System;
using System.Collections.Generic;

namespace Bookmaster.Model;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? DeathDate { get; set; }

    public string? Wikipedia { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}

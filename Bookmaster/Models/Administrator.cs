﻿using System;
using System.Collections.Generic;

namespace Bookmaster.Model;

public partial class Administrator
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Circulation> Circulations { get; set; } = new List<Circulation>();
}

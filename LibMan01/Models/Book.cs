using System;
using System.Collections.Generic;

namespace LibMan01.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int? Availability { get; set; } = null!;
}

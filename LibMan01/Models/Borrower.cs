using System;
using System.Collections.Generic;

namespace LibMan01.Models;

public partial class Borrower
{
    public int BorrowerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int TotalBorrowedBooks { get; set; }
}

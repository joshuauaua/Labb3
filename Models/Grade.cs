using System;
using System.Collections.Generic;

namespace EFTest.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public DateOnly Date { get; set; }

    public int Grade1 { get; set; }

    public int FkStudentId { get; set; }

    public int FkStaffId { get; set; }

    public virtual Staff FkStaff { get; set; } = null!;

    public virtual Student FkStudent { get; set; } = null!;
}

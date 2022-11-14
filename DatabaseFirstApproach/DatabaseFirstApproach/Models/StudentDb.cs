using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models;

public partial class StudentDb
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? Department { get; set; }

    public string? Course { get; set; }
}

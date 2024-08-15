using System;
using System.Collections.Generic;

namespace WebAPICrud.Models.Data;

public partial class EmployeeDetail
{
    public long EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string EmpPhone { get; set; } = null!;

    public string? EmpAddress { get; set; }

    public string? EmpRegion { get; set; }

    public string EmployeeEmail { get; set; } = null!;
}

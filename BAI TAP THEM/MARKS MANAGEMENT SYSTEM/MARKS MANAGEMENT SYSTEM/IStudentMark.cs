using System;
using System.Collections.Generic;
using System.Text;

namespace MARKS_MANAGEMENT_SYSTEM
{
    interface IStudentMark
    {
        string FullName { get; set; }
        int Id { get; set; }
        string Class { get; set; }
        int Semester { get; set; }
        float AverageMark { get; }
    }
}

using MindXLiveCodeGen8.Domain.Base;

namespace MindXLiveCodeGen8.Domain.Entities;

public class ResumeEducation : EntityBase<int>
{
    public string University { get; set; }
    public string Faculty { get; set; }
    public double Gpa { get; set; }
    public Resume Resume { get; set; }
}
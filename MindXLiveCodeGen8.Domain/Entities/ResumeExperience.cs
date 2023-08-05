using MindXLiveCodeGen8.Domain.Base;

namespace MindXLiveCodeGen8.Domain.Entities;

public class ResumeExperience : EntityBase<int>
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string JobDescription { get; set; }
    public Resume Resume { get; set; }
}
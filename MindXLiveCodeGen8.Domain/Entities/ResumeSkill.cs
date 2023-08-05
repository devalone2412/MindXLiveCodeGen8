using MindXLiveCodeGen8.Domain.Base;

namespace MindXLiveCodeGen8.Domain.Entities;

public class ResumeSkill : EntityBase<int>
{
    public string Name { get; set; }
    public ICollection<Resume> Resumes { get; set; }
}
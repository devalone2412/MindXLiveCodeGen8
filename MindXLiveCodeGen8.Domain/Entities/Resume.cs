using MindXLiveCodeGen8.Domain.Base;

namespace MindXLiveCodeGen8.Domain.Entities;

public class Resume : EntityBase<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Github { get; set; }
    public string LinkedIn { get; set; }
    public string Summary { get; set; }
    public ICollection<ResumeExperience> ResumeExperiences { get; set; }
    public ICollection<ResumeEducation> ResumeEducations { get; set; }
    public ICollection<ResumeSkill> ResumeSkills { get; set; }
    public Account Account { get; set; }
}
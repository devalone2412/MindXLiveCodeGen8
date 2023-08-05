using MindXLiveCodeGen8.Domain.Base;

namespace MindXLiveCodeGen8.Domain.Entities;

public class Account : EntityBase<int>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public ICollection<Resume> Resumes { get; set; }
}
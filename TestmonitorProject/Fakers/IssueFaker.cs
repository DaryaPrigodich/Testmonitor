using Bogus;
using TestmonitorProject.Models;

namespace TestmonitorProject.Fakers;

public class IssueFaker : Faker<Issue>
{
    private const int MinIssueCategoryId = 1;
    private const int MaxIssueCategoryId = 7;
    
    private const int MinIssueStatusId = 1;
    private const int MaxIssueStatusId = 5;

    public IssueFaker()
    {
        RuleFor(c => c.Name, f => f.Lorem.Word());
        RuleFor(c => c.Description, f => f.Lorem.Word());
        RuleFor(c => c.IssueCategoryId, f => f.Random.Number(MinIssueCategoryId, MaxIssueCategoryId));
        RuleFor(c => c.IssueStatusId, f => f.Random.Number(MinIssueStatusId, MaxIssueStatusId));
    }
}

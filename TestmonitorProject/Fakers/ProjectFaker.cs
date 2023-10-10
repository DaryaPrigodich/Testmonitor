using Bogus;
using TestmonitorProject.Models;

namespace TestmonitorProject.Fakers;

public class ProjectFaker : Faker<Project>
{
    private const int MinCodeLength = 1;
    private const int MaxCodeLength = 11;

    public ProjectFaker()
    {
        RuleFor(c => c.Name, f => f.Lorem.Word());
        RuleFor(c => c.SymbolId, f => f.Random.Number(MinCodeLength, MaxCodeLength));
    }
}

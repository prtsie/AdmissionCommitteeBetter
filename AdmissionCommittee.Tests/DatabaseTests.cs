using AdmissionCommittee.DB;
using AdmissionCommittee.Models;
using Ahatornn.TestGenerator;
using FluentAssertions;
using Xunit;

namespace AdmissionCommittee.Tests;

public class DatabaseTests
{
    private readonly CommitteeContext context = InMemoryContextProvider.GetDbContext();
    private IDataStorage storage;

    public DatabaseTests()
    {
        storage = context;
    }

    [Fact]
    private void GetListShouldReturnEntities()
    {
        //arrange
        var applicant1 = TestEntityProvider.Shared.Create<Applicant>();
        var applicant2 = TestEntityProvider.Shared.Create<Applicant>();
        context.Applicants.Add(applicant1);
        context.Applicants.Add(applicant2);
        context.SaveChanges();

        var applicants = storage.GetList<Applicant>();

        applicants.Should().BeEquivalentTo(new List<Applicant> { applicant1, applicant2 });
    }

    [Fact]
    private void GetListShouldReturnEmpty()
    {

        var applicants = storage.GetList<Applicant>();

        applicants.Should().BeEmpty();
    }

    [Fact]
    private void AddShouldWork()
    {
        var applicant = TestEntityProvider.Shared.Create<Applicant>();

        storage.Add(applicant);
        storage.Save();

        context.Applicants.ToList().Should().BeEquivalentTo(new List<Applicant> { applicant });
    }

    [Fact]
    private void RemoveShouldWork()
    {
        var applicant = TestEntityProvider.Shared.Create<Applicant>();
        context.Applicants.Add(applicant);
        context.SaveChanges();

        storage.Remove(applicant);
        storage.Save();

        context.Applicants.ToList().Should().BeEmpty();
    }

    [Fact]
    private void UpdateShouldWork()
    {
        var applicant = TestEntityProvider.Shared.Create<Applicant>(a => a.MathScore = 50);
        context.Applicants.Add(applicant);
        context.SaveChanges();

        var applicantFromStorage = storage.GetList<Applicant>().First();
        applicantFromStorage.MathScore = 70;
        storage.Update(applicantFromStorage);
        storage.Save();

        context.Applicants.ToList().First().Should().BeEquivalentTo(applicantFromStorage);
    }
}

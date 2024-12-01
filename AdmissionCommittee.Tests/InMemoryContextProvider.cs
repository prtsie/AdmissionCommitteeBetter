using AdmissionCommittee.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdmissionCommittee.Tests
{
    public static class InMemoryContextProvider
    {
        private readonly static DbContextOptions<CommitteeContext> opts = new DbContextOptionsBuilder<CommitteeContext>()
            .UseInMemoryDatabase("committeeTestDB")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        public static CommitteeContext GetDbContext()
        {
            var result = new CommitteeContext(opts);
            return result;
        }
    }
}

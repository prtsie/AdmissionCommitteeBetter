using Microsoft.EntityFrameworkCore;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.DB
{
    public sealed class CommitteeContext : DbContext, IDataStorage
    {
        public CommitteeContext(DbContextOptions<CommitteeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Applicant> Applicants { get; set; } = null!;

        public List<T> GetList<T>() where T : class, IDatabaseEntity => Set<T>().ToList();

        public void Save() => SaveChanges();

        void IDataStorage.Add<T>(T entity) => Set<T>().Add(entity);

        void IDataStorage.Remove<T>(T entity) => Set<T>().Remove(entity);

        void IDataStorage.Update<T>(T entity) => Set<T>().Update(entity);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.DB
{
    internal sealed class CommitteeContext : DbContext, IDataStorage
    {
        public DbSet<Applicant> Applicants { get; set; } = null!;

        public List<T> GetList<T>() where T : class, IDatabaseEntity => Set<T>().ToList();
        public void Save() => SaveChanges();
        void IDataStorage.Add<T>(T entity) => Set<T>().Add(entity);
        void IDataStorage.Remove<T>(T entity) => Set<T>().Remove(entity);
        void IDataStorage.Update<T>(T entity) => Set<T>().AddOrUpdate(entity);
    }
}

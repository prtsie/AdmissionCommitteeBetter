using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Serilog;
using AdmissionCommittee.DB;
using AdmissionCommittee.Forms;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee
{
    static internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Log.Logger = new LoggerConfiguration().WriteTo.Seq("http://localhost:5341/").WriteTo.File("log.txt").CreateLogger();
            Log.Information("Программу открыли");
            ApplicationConfiguration.Initialize();
            Application.Run(new ApplicantListForm());
            Log.Information("Программу закрыли");
            Log.CloseAndFlush();
        }

        /// <summary>Âîçâðàùàåò <see cref="DisplayAttribute.Name"/> ó ÷ëåíà <paramref name="memberName"/> òèïà <paramref name="type"/></summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetMemberDisplayName(Type type, string memberName)
        {
            var member = type.GetMember(memberName).FirstOrDefault() ?? throw new NullReferenceException();
            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute)).Cast<DisplayAttribute>();
            foreach (var attribute in attributes)
            {
                if (attribute.Name != null)
                {
                    return attribute.Name;
                }
            }
            throw new InvalidOperationException(!attributes.Any() ? "У значения нет атрибута Display" : "У атрибута Display не задано свойство Name");
        }

        public static IDataStorage GetDataStorage()
            => new CommitteeContext(
                new DbContextOptionsBuilder<CommitteeContext>().
                    UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=committeeDB;Integrated Security=true").Options);
    }
}

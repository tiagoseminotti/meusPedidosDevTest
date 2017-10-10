using System;
using System.Data.Entity;
using MeusPedidos.DevTest.Models;
using MeusPedidos.DevTest.WebAPI.Contexts;
using System.Threading.Tasks;

namespace MeusPedidos.DevTest.WebAPI.Tests.Contexts
{
    public class TestWebApiContext : IMeusPedidosDevTestContext
    {
        public TestWebApiContext()
        {
            this.UserEvaluation = new TestUserEvaluationDbSet();
        }

        public DbSet<UserEvaluation> UserEvaluation { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(UserEvaluation item) { }
        public void Dispose() { }
    }
}

using MeusPedidos.DevTest.Models;
using System;
using System.Data.Entity;

namespace MeusPedidos.DevTest.WebAPI.Contexts
{
    public class MeusPedidosDevTestContext : DbContext, IMeusPedidosDevTestContext
    {
        public MeusPedidosDevTestContext()
            : base("name=MeusPedidosAzureDb")
        { }

        public virtual DbSet<UserEvaluation> UserEvaluation { get; set; }

        public void MarkAsModified(UserEvaluation item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }

    public interface IMeusPedidosDevTestContext : IDisposable
    {
        DbSet<UserEvaluation> UserEvaluation { get; }
        int SaveChanges();
        void MarkAsModified(UserEvaluation item);
    }
}
using System;
using System.Linq;
using MeusPedidos.DevTest.Models;

namespace MeusPedidos.DevTest.WebAPI.Tests.Contexts
{
    class TestUserEvaluationDbSet : TestDbSet<UserEvaluation>
    {
        public override UserEvaluation Find(params object[] keyValues)
        {
            return this.SingleOrDefault(uEval => uEval.CD_USEREVALUATION == (Guid)keyValues.Single());
        }
    }
}

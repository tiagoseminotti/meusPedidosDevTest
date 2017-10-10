using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusPedidos.DevTest.WebAPI.BLL;
using MeusPedidos.DevTest.Models;

namespace MeusPedidos.DevTest.WebAPI.Tests.BLL
{
    [TestClass]
    public class UserEvaluationBLLTest
    {
        [TestMethod]
        public void CheckApplicantScores()
        {
            UserEvaluation userEval = new UserEvaluation() { DS_EMAIL = "tiago.seminotti@gmail.com", DS_NAME = "Tiago Seminotti", NR_EVAL_HTML = 5, NR_EVAL_CSS = 4, NR_EVAL_JAVASCRIPT = 3, NR_EVAL_PYTHON = 6, NR_EVAL_DJANGO = 5, NR_EVAL_IOS = 8, NR_EVAL_ANDROID = 2 };

            UserEvaluationBLL.CheckApplicantScores(userEval);
        }
    }
}

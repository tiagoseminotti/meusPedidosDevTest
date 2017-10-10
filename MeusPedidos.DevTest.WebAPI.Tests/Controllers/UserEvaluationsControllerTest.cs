using MeusPedidos.DevTest.Models;
using MeusPedidos.DevTest.WebAPI.Controllers;
using MeusPedidos.DevTest.WebAPI.Tests.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http.Results;

namespace MeusPedidos.DevTest.WebAPI.Tests.Controllers
{
    /// <summary>
    /// Unit tests for user evaluations controller
    /// </summary>
    [TestClass]
    public class UserEvaluationsControllerTest
    {
        /// <summary>
        /// Tests if the default user was created (Post)
        /// </summary>
        [TestMethod]
        public void PostUE_ShouldReturnSame()
        {
            var controller = new UserEvaluationsController(new TestWebApiContext());

            var item = GetDefaultUserEval();

            var result = controller.PostUserEvaluation(item) as CreatedAtRouteNegotiatedContentResult<UserEvaluation>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.CD_USEREVALUATION);
            Assert.AreEqual(result.Content.DS_EMAIL, item.DS_EMAIL);
            Assert.AreEqual(result.Content.DS_NAME, item.DS_NAME);
        }

        /// <summary>
        /// Tests if the user returned has the same id (Get by id)
        /// </summary>
        [TestMethod]
        public void GetUE_ShouldReturnWithSameID()
        {
            var context = new TestWebApiContext();
            context.UserEvaluation.Add(GetDefaultUserEval());

            var controller = new UserEvaluationsController(context);
            var result = controller.GetUserEvaluation(new Guid("07FDE199-1B05-4244-9988-517CF8F3936A")) as OkNegotiatedContentResult<UserEvaluation>;

            Assert.IsNotNull(result);
            Assert.AreEqual(new Guid("07FDE199-1B05-4244-9988-517CF8F3936A"), result.Content.CD_USEREVALUATION);
        }

        /// <summary>
        /// Tests if all users added to the context are returned (Get all users)
        /// </summary>
        [TestMethod]
        public void GetUE_ShouldReturnAll()
        {
            var context = new TestWebApiContext();
            context.UserEvaluation.Add(new UserEvaluation { DS_EMAIL = "test1.usereval@gmail.com", DS_NAME = "Test User 1" });
            context.UserEvaluation.Add(new UserEvaluation { DS_EMAIL = "test2.usereval@gmail.com", DS_NAME = "Test User 2" });
            context.UserEvaluation.Add(new UserEvaluation { DS_EMAIL = "test3.usereval@gmail.com", DS_NAME = "Test User 3" });

            var controller = new UserEvaluationsController(context);
            var result = controller.GetUserEvaluation() as TestUserEvaluationDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        /// <summary>
        /// Returns a default user for tests
        /// </summary>
        /// <returns></returns>
        UserEvaluation GetDefaultUserEval()
        {
            return new UserEvaluation() { CD_USEREVALUATION = new Guid("07FDE199-1B05-4244-9988-517CF8F3936A"), DS_EMAIL = "test.usereval@gmail.com", DS_NAME = "Test User" };
        }
    }
}

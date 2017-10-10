using MeusPedidos.DevTest.Models;
using MeusPedidos.DevTest.WebAPI.BLL;
using MeusPedidos.DevTest.WebAPI.Contexts;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace MeusPedidos.DevTest.WebAPI.Controllers
{
    /// <summary>
    /// Controller for user evaluation entity
    /// </summary>
    public class UserEvaluationsController : ApiController
    {
        private IMeusPedidosDevTestContext db = new MeusPedidosDevTestContext();

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserEvaluationsController() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public UserEvaluationsController(IMeusPedidosDevTestContext context)
        {
            db = context;
        }

        /// <summary>
        /// Lists all user evaluations
        /// </summary>
        /// <returns></returns>
        // GET: api/UserEvaluations
        public IQueryable<UserEvaluation> GetUserEvaluation()
        {
            return db.UserEvaluation;
        }

        /// <summary>
        /// Gets a specific user evaluation
        /// </summary>
        /// <param name="id">User evaluation code</param>
        /// <returns></returns>
        // GET: api/UserEvaluations/5
        [ResponseType(typeof(UserEvaluation))]
        public IHttpActionResult GetUserEvaluation(Guid id)
        {
            UserEvaluation userEvaluation = db.UserEvaluation.Find(id);
            if (userEvaluation == null)
            {
                return NotFound();
            }

            return Ok(userEvaluation);
        }

        /// <summary>
        /// Adds a new user evaluation
        /// </summary>
        /// <param name="userEvaluation">Model with user evaluation data</param>
        /// <returns>
        /// Code for user evaluation in case of success
        /// Conflict in case of existing evaluation for an e-mail
        /// BadRequest in case of invalid model
        /// </returns>
        // POST: api/UserEvaluations
        [ResponseType(typeof(UserEvaluation))]
        public IHttpActionResult PostUserEvaluation(UserEvaluation userEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Checks if a evaluation for the e-mail entered already exists
            if (UserEvaluationExists(userEvaluation.DS_EMAIL))
            {
                return Conflict();
            }
            else
            {
                //Creates a new id
                userEvaluation.CD_USEREVALUATION = Guid.NewGuid();

                db.UserEvaluation.Add(userEvaluation);

                try
                {
                    db.SaveChanges();

                    //Check scores and send e-mail
                    UserEvaluationBLL.CheckApplicantScores(userEvaluation);
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userEvaluation.CD_USEREVALUATION }, userEvaluation);
        }

        /// <summary>
        /// Disposing method
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Checks if a evaluation exists for the e-mail
        /// </summary>
        /// <param name="pDsEmail">E-mail</param>
        /// <returns>
        /// True if it already exists
        /// False if not
        /// </returns>
        private bool UserEvaluationExists(string pDsEmail)
        {
            return db.UserEvaluation.Count(e => e.DS_EMAIL == pDsEmail) > 0;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyPlayground.Controllers
{
    using System;
    using System.Web.Mvc;

    using Castle.Core;

    using MyPlayground.Plumbing.Interceptors;

    /// <summary>
    /// TODO The home controller.
    /// </summary>
    [Interceptor(typeof(LogAspect))]
    [Interceptor(typeof(ExceptionAspect))]
    public class HomeController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO The about.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public ActionResult About()
        {
            throw new Exception("Test me");
            this.ViewBag.Message = "Your application description page.";
            return this.View();
        }

        /// <summary>
        /// TODO The contact.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        /// <summary>
        /// TODO The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        #endregion
    }
}
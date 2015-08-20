using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Awdk.Skus.Framework.Service.Data.Interface;
using Awdk.Skus.Framework.WebAPI.DTO.EventDTO;

namespace Awdk.Skus.Framework.WebAPI.Controllers.Api
{

    /// <summary>
    /// Web API Controller for events
    /// </summary>
    public class EventController : ApiController
    {

        public const string GetEventByUserIdRouteName = "GetEventByUserId";
        public const string GetEventByCurrentUserRouteName = "GetEventByCurrentUser";
        public const string GetEventByJobIdRouteName = "GetEventByJobId";
        public IEventService eventService;
        private readonly IPrincipleProvider principleProvider;


        public EventController(IEventService eventService, IPrincipleProvider principleProvider)
        {
            this.eventService = eventService;
            this.principleProvider = principleProvider;
        }

        /// <summary>
        /// Get all event of login user
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>an array of event information</returns>
        [HttpGet]
        [Route("events/this", Name = GetEventByUserIdRouteName)]
        [ResponseType(typeof(IEnumerable<EventDto>))]
        public IHttpActionResult EventsByCurrentLoginUser()
        {
            var eventDtos = eventService.GetEventsByCurrentLoginUser(principleProvider.CurrentUserAlias);
            return Ok(eventDtos);
        }

        /// <summary>
        /// Get all event of one user
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>an array of event information</returns>
        [HttpGet]
        [Route("events/{userId}", Name = GetEventByUserIdRouteName)]
        [ResponseType(typeof(IEnumerable<EventDto>))]
        public IHttpActionResult EventsByUserId(int userId)
        {
            var eventDtos = eventService.GetEventsByUserId(userId);
            return Ok(eventDtos);
        }

        ///// <summary>
        ///// Get all event of job Id
        ///// </summary>
        ///// <param name="jobId">jobId</param>
        ///// <returns>an array of event information</returns>
        //[HttpGet]
        //[Route("")]
        //[ResponseType(typeof(IEnumerable<EventDto>))]
        //public IHttpActionResult EventsByJobId(int jobId)
        //{
        //    var eventDtos = eventService.GetEventsByJobId(jobId);
        //    return Ok(eventDtos);
        //}


        private static bool InvalidInput(string userName, string clientName)
        {
            return string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(clientName);
        }
    }
}

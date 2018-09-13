using Microsoft.AspNet.Identity;
using Models.TrailModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParksAndTech.WebApi.Controllers
{
    [Authorize]
    public class TrailController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TrailService trailService = CreateTrailService();
            var trails = trailService.GetTrail();
            return Ok(trails);
        }

        public IHttpActionResult Get(int id)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByID(id);
            return Ok(trail);
        }

        public IHttpActionResult Post(TrailCreate trail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
​
            var service = CreateTrailService();
​
            if (!service.CreateTrail(trail))
                return InternalServerError();
​
            return Ok();
        }

        public IHttpActionResult Put(TrailEdit trail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
​
            var service = CreateTrailService();
​
            if (!service.UpdateTrail(trail))
                return InternalServerError();
​
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTrailService();
​
            if (!service.DeleteTrail(id))
                return InternalServerError();
​
            return Ok();
        }

        private TrailService CreateTrailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var trailService = new TrailService(userId);
            return trailService;
        }
        
    }
}

using Microsoft.AspNet.Identity;
using Models.ParkModels;
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
    public class ParkController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ParkService parkService = CreateParkService();
            var parks = parkService.GetPark();
            return Ok(parks);
        }

        public IHttpActionResult Get (int id)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByID(id);
            return Ok(park);
        }

        public IHttpActionResult Post(ParkCreate park)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateParkService();

            if (!service.CreatePark(park))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ParkEdit park)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateParkService();

            if (!service.UpdatePark(park))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateParkService();

            if (!service.DeletePark(id))
                return InternalServerError();

            return Ok();
        }

        private ParkService CreateParkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var parkService = new ParkService(userId);
            return parkService;
        }
    }
}

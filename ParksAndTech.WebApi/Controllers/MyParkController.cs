using Microsoft.AspNet.Identity;
using Models.MyParkModels;
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
    public class MyParkController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MyParkService myParkService = CreateMyParkService();
            var myParks = myParkService.GetMyPark();
            return Ok(myParks);
        }

        public IHttpActionResult Get (int id)
        {
            MyParkService myParkService = CreateMyParkService();
            var myPark = myParkService.GetMyParkByID(id);
            return Ok(myPark);
        }

        public IHttpActionResult Post(MyParkCreate myPark)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMyParkService();

            if (!service.CreateMyPark(myPark))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(MyParkEdit myPark)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMyParkService();

            if (!service.UpdateMyPark(myPark))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMyParkService();

            if (!service.DeleteMyPark(id))
                return InternalServerError();

            return Ok();
        }

        private MyParkService CreateMyParkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var myParkService = new MyParkService(userId);
            return myParkService;
        }
    }
}

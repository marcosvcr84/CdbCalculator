using CdbApiCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CdbApiCalculator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CdbCalculatorController : ApiController
    {
        // POST: api/CdbCalculator
        public IHttpActionResult Calculate(CdbInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grossValue = input.InitialValue;
            for (int i = 0; i < input.Months; i++)
            {
                grossValue *= (decimal)(1 + (0.9 / 100 * 1.08));
            }

            var tax = input.Months <= 6 ? 0.225m :
                      input.Months <= 12 ? 0.20m :
                      input.Months <= 24 ? 0.175m : 0.15m;
            var netValue = grossValue * (1 - tax);

            return Ok(new CdbResult
            {
                GrossValue = grossValue,
                NetValue = netValue
            });
        }
    }
}
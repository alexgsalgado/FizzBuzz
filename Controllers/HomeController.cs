using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult RunFizzBuzz(string UserInput)
        {
            //Separate each individual component from the collection that was passed in
            var inputs = UserInput.Split(',');
            var outputs = new List<string>();
            for (int i = 0; i < inputs.Length; i++)
            {
                //We need to try and parse each individual input as an integer. I used Int64 to expand the range of numbers that would be in scope for testing
                long tempNumber = 0;
                bool isNumber = Int64.TryParse(inputs[i], out tempNumber);
                if (isNumber)
                {
                    //Check if the input is divisible by 15, if not check 3, if not check 5. If it's not divisible by 3 or 5 then add the 'Divided X by 3' 'Divided X by 5' lines to the output
                    if (tempNumber % 15 == 0)
                        outputs.Add("FizzBuzz");
                    else if (tempNumber % 3 == 0)
                        outputs.Add("Fizz");
                    else if (tempNumber % 5 == 0)
                        outputs.Add("Buzz");
                    else
                        outputs.Add($"Divided {tempNumber} by 3<br />Divided {tempNumber} by 5");             
                }
                else
                {
                    //input is not a number, add output of "Invalid Item"
                    outputs.Add("Invalid Item");
                }

            }

            var returnInfo = new
            {
                fizzBuzzItems = inputs,
                results = outputs
            };

            return Json(returnInfo, JsonRequestBehavior.AllowGet);
        }
    }
}
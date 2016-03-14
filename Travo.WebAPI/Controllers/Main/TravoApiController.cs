using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Travo.ViewModels;

namespace Travo.Controllers.Main
{
    public class TravoApiController : ApiController
    {
        protected ErrorActionResult Error(ModelStateDictionary ms)
        {
            return new ErrorActionResult(ms);
        }

        public static List<string> GetModelStateErrors(ModelStateDictionary ms)
        {
            var errors = new List<string>();
            foreach (var state in ms)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
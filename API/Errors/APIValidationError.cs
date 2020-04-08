using System.Collections.Generic;

namespace API.Errors
{
    public class APIValidationError : APIResponse
    {
        public APIValidationError() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set;}
    }
}
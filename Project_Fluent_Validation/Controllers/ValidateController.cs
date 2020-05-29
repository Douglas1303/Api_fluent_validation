using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Fluent_Validation.Models;

namespace Project_Fluent_Validation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase

    { 

        private readonly IValidator<EntityToValidate> _entityToValidateValidator; 
        public ValidateController(IValidator<EntityToValidate> entityToValidateValidator)
        {
            _entityToValidateValidator = entityToValidateValidator; 
        }

        [HttpPost("PostWitchFluentValidate")]
        public List<string> PostWitchFluentValidate([FromBody] EntityToValidate entity)
        {
            List<string> response = new List<string>();

            var validationResult = _entityToValidateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    response.Add(error.ToString()); 
                }
            }
            else
            {
                response.Add("All is Ok"); 
            }

            return response; 
        }
    }
}

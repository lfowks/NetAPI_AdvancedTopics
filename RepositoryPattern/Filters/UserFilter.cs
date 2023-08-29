using Domain;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RepositoryPattern.Validators;
using System.Security.Principal;

namespace RepositoryPattern.Filters
{
    public class UserFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
           User user = (User) context.ActionArguments.SingleOrDefault(p => p.Value is User).Value;

            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(user);

            if (!result.IsValid)
            {
                context.Result = new BadRequestObjectResult("msjError")
                {
                    Value = result.Errors,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}

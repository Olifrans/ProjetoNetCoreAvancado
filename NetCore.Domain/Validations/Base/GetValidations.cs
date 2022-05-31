using FluentValidation.Results;

namespace NetCore.Domain.Validations.Base
{
    public static class GetValidations
    {
        public static Response GetErrors(this ValidationResult result)
        {
            var response = new Response();

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    response.Reports.Add(new Reports()
                    {
                        Code = error.PropertyName,
                        Message = error.ErrorMessage
                    });
                }
                return response;
            }
            return response;
        }
    }
}
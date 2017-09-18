using System.ComponentModel.DataAnnotations.Schema;

namespace OnionPattern.Domain.Validation
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}

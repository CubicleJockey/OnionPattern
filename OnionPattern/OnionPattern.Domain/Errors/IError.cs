using Newtonsoft.Json;

namespace OnionPattern.Domain.Errors
{
    public interface IError
    {
        ErrorResponse ErrorResponse { get; set; }

        [JsonIgnore]
        int? StatusCode { get; set; }
    }
}
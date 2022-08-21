using Newtonsoft.Json;

namespace Betting.Application.Common.Exceptions;
public class ErrorResponseWrapper<T>
{
    [JsonProperty("error")]
    public T Error { get; set; }
}

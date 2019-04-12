using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MindTheMango.Mind.Api.WebApi.Model.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class SignInResponseModel
    {
        /// <summary>
        /// Auth Token to use with Bearer auth scheme.
        /// </summary>
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }
    }
}
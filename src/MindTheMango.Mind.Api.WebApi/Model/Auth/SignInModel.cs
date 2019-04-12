namespace MindTheMango.Mind.Api.WebApi.Model.Auth
{
    /// <summary>
    /// Model of the request for signing in a user.
    /// </summary>
    public class SignInModel
    {
        /// <summary>
        /// Email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
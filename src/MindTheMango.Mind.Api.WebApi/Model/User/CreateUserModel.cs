namespace MindTheMango.Mind.Api.WebApi.Model.User
{
    /// <summary>
    /// Model for creating a new user.
    /// </summary>
    public class CreateUserModel
    {
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname of the user.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Username of the user.
        /// </summary>
        public string Username { get; set; }
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
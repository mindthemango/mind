using System;

namespace MindTheMango.Mind.Application.Contract.Dto
{
    public class UserDto
    {
        /// <summary>
        /// Id of the User
        /// </summary>
        public Guid Id { get; set; }
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
        /// Represents the registration date of the user.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Represents the last time a change was made to this user.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
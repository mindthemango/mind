using System;

namespace MindTheMango.Mind.Domain.Entity
{
    public class User
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
        /// Registration date of the user.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Represents the last time a change was made to this user.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
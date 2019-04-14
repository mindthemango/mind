using System;

namespace MindTheMango.Mind.Application.Contract.Dto
{
    public class NoteDto
    {
        /// <summary>
        /// Id of the note.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title of the note.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Content of the note.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Represents the creation date of the note
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Represents the last time a change was made to this note.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
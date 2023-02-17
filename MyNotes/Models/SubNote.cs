using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using MyNotes.Models;

namespace MyNotes.Models
{
    public class SubNote
    {
        [Key]
        public int SubNoteId { get; set; }

        public string? NoteName { get; set; }

        [ForeignKey("Note")]
        public int NoteId { get; set; }

        [ValidateNever]
        public Note Note { get; set; }
    }
}

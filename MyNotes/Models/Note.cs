using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNotes.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        public string? NoteName { get; set; }
        public int? AltId { get; set; }
    }
}

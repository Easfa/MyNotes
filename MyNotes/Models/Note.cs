using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        public string? NoteName { get; set; }

        public int? NoteSubId { get; set; }
    }
}

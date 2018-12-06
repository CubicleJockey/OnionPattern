using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using OnionPattern.Domain.Validation;

namespace OnionPattern.Domain
{
    public abstract class VideoGameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped, JsonIgnore]
        public bool IsValid { get; set; }

        [NotMapped, JsonIgnore]
        public ICollection<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    }
}

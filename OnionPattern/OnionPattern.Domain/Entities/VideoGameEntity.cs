using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OnionPattern.Domain.Validation;

namespace OnionPattern.Domain.Entities
{
    public abstract class VideoGameEntity
    {
        public int Id { get; set; }

        [NotMapped]
        public bool IsValid { get; set; }

        [NotMapped]
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Game.Domain.Entities
{
    public class PersonEntity : BaseEntity, IComparable<PersonEntity>
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public double Mass { get; set; }
        [Range(0, double.MaxValue)]
        public int Wins { get; set; }

        public int CompareTo(PersonEntity other)
        {
            return Mass.CompareTo(other.Mass);
        }
    }
}

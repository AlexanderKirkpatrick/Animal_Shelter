using System;

namespace Animal_Shelter.Models
{
     public class Animal
  {
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Breed { get; set; }
    public DateTime EntryDate { get; set; }
    public int TypeId { get; set; }
    public virtual Category Type { get; set; }
  }
}

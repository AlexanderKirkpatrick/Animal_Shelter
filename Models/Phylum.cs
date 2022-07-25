using System.Collections.Generic;

namespace Animal_Shelter.Models
{
  public class Phylum
  {
    public Phylum()
    {
      this.Animals = new HashSet<Animal>();
    }

    public int PhylumId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Animal> Animals { get; set; }
  }
}
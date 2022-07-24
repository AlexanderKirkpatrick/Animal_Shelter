using System.Collections.Generic;

namespace Animal_Shelter.Models
{
  public class Type
  {
    public Type()
    {
      this.Animals = new HashSet<Animal>();
    }

    public int TypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Animal> Animals { get; set; }
  }
}
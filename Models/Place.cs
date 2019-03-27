using System.Collections.Generic;

namespace AdventureTimeAPI.Models
{
  public class Place
  {
    public int id { get; set; }
    public string name { get; set; }
    public string greatestAlly { get; set; }
    public string currentRuler { get; set; }
    public string typeOfGovernment { get; set; }

    // navigation
    public List<Character> Characters { get; set; } = new List<Character>();
  }
}
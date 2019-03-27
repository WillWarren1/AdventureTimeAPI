namespace AdventureTimeAPI.Models
{
  public class Character
  {
    public int id { get; set; }
    public string name { get; set; }
    public string placeOfOrigin { get; set; }
    public string allegiance { get; set; }
    public int? age { get; set; }
    public string species { get; set; }

    // navigation
    public int PlaceId { get; set; }
    public Place Place { get; set; }

  }

}
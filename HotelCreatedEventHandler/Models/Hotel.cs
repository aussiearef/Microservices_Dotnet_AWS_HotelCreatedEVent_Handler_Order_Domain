using Amazon.DynamoDBv2.DataModel;

namespace HotelCreatedEventHandler.Models;

[DynamoDBTable("Hotels_Order_Domain")]
public class Hotel
{
    [DynamoDBHashKey("userId")] public string? UserId { get; set; }

    [DynamoDBRangeKey("Id")] public string? Id { get; set; }

    public string? Name { get; set; }
    public string? CityName { get; set; }
    public int Price { get; set; }
    public int Rating { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string? FileName { get; set; }
}
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.Lambda.SNSEvents;
using HotelCreatedEventHandler.Models;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace HotelCreatedEventHandler;

public class HotelCreatedEventHandler
{
    /*
    *   Implement Idempotent Consumer pattern here.
    */

    public async Task Handler(SNSEvent snsEvent)
    {
        var dbClient = new AmazonDynamoDBClient();
        using var dbContext = new DynamoDBContext(dbClient);

        foreach (var eventRecord in snsEvent.Records)
        {
            var hotel = JsonSerializer.Deserialize<Hotel>(eventRecord.Sns.Message);
            await dbContext.SaveAsync(hotel);
        }
    }
}
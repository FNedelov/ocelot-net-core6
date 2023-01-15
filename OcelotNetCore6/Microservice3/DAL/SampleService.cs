namespace Microservice3.DAL
{
    public class SampleService : ISampleService
    {
        public async Task<IResult> GetData()
        {
            await Task.Delay(1);
            return Results.Ok("Successful get data called");
        }

        public async Task<IResult> PostData(int id)
        {
            await Task.Delay(1);
            return Results.Ok($"Posted value was: {id}");
        }
    }
}
namespace Microservice3.DAL
{
    public interface ISampleService
    {
        Task<IResult> GetData();
        Task<IResult> PostData(int id);
    }
}
namespace Microservice2.MinimalAPIs
{
    public static class MinAPI1
    {
        public static void MinAPIMethod1(this WebApplication app)
        {
            app.MapGet("api/MinAPI1/MinAPIMethod1", async() =>
            {
                await Task.Delay(1);
                return "Called MinAPIMethod1";
            });
        }

        public static void MinAPIMethod2(this WebApplication app)
        {
            app.MapGet("api/MinAPI1/MinAPIMethod2", async() =>
            {
                await Task.Delay(1);
                return "Called MinAPIMethod2";
            });
        }
    }
}
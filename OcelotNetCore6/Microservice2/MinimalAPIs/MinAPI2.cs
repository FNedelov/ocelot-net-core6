namespace Microservice2.MinimalAPIs
{
    public static class MinAPI2
    {
        public static void MinAPIMethod3(this WebApplication app)
        {
            app.MapGet("api/MinAPI2/MinAPIMethod3", async () =>
            {
                await Task.Delay(1);
                return "Called MinAPIMethod3";
            });
        }

        public static void MinAPIMethod4(this WebApplication app)
        {
            app.MapGet("api/MinAPI2/MinAPIMethod4", async () =>
            {
                await Task.Delay(1);
                return "Called MinAPIMethod4";
            });
        }
    }
}
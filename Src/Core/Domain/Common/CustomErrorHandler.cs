namespace Domain.Common
{
    public class CustomErrorHandler
    {
        public CustomErrorHandler()
        {
        }

        public CustomErrorHandler(string? errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }

        public bool HasError { get; set; } = false;
        public string? ErrorMessage { get; set; }

    }
}

namespace Application.Common.Models;

public class ServiceResult
{
    public ServiceResult()
    {
        IsError = false;
        ErrorMessage = null;
    }

    public ServiceResult(string errorMessage)
    {
        IsError = true;
        ErrorMessage = errorMessage;
    }

    public bool IsError { get; set; }

    public string? ErrorMessage { get; set; }

}
using Microsoft.AspNetCore.Mvc;

namespace Obqvi_API.ViewModels.ResponseModels
{
    public class BaseResponseVM 
    {
        public bool HasError { get; set; }

        public string? ErrorMess { get; set; }

        public object Data { get; set; } = default!;
    }
}

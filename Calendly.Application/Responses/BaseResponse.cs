using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message, bool success)
        {
            Message = message;
            Success = success;

        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string>  Errors { get; set; }
    }
}

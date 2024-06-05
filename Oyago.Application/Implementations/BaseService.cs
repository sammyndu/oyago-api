using Oyago.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Application.Implementations
{
    public class BaseService
    {
        public ServerResponse<T> SetErrorResponse<T>(string message, string code)
        {
            var result = new ServerResponse<T>();

            result.ErrorResponse = new ErrorResponse
            {
                ResponseCode = code,
                ResponseDescription = message,
                ResponseMessage = message
            };
            return result;
        }
    }
}

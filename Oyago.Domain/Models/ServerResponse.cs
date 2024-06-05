using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Domain.Models
{
    public class ServerResponse<T>
    {
        public ServerResponse(bool success = false)
        {
            IsSuccessful = success;
        }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public ErrorResponse ErrorResponse { get; set; }
        public T Data { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }
        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }
        [JsonProperty("responseDescription")]
        public string ResponseDescription { get; set; }
    }
}

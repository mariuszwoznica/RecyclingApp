using System;

namespace RecyclingApp.Application.Models
{
    [Obsolete] //TODO: remove
    public class Response<T>
    {
        public T Data { get; set; }

        public Response() { }
        public Response(T response)
        {
            Data = response;
        }
    }
}

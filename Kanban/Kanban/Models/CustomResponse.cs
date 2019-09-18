using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Kanban.Models
{
    public class CustomResponse<T> where T : class 
    {
        public T Data { get; set; }
        public HttpResponseMessage Response { get; set; }
    }
}

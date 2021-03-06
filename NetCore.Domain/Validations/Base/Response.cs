using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Validations.Base
{
    public class Response
    {
        public Response()
        {
            Reports = new List<Reports>();
        }

        public Response(List<Reports> reports)
        {
            Reports = reports ?? new List<Reports>();
        }

        public Response(Reports reports) : this(new List<Reports>() { reports })
        {

        }

        public List<Reports> Reports { get; }

        public static Response<T> Ok<T>(T data) => new Response<T>(data);
        public static Response Ok() => new Response();
        public static Response Unprocessable(List<Reports> reports) => new Response(reports);
        public static Response Unprocessable(Reports reports) => new Response(reports);
        public static Response<T> Unprocessable<T>(List<Reports> reports)
        {
            return new Response<T>(reports);
        }

    }

    public class Response<T> : Response
    {
        public Response()
        {
        }

        public Response(List<Reports> reports) : base(reports)
        {
        }

        public Response(T data, List<Reports> reports = null) : base(reports)
        {
            Data = data;
        }

        public T Data { get; set; }

    }
}

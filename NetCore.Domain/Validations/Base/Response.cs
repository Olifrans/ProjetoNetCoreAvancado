namespace NetCore.Domain.Validations.Base;

public class Response
{
    public Response()
    {
        Reports = new List<Reports>();
    }

    public Response(List<Reports> reports)
    {
        Reports = reports;
    }

    public Response(Reports reports) : this(new List<Reports>() { reports })
    {
    }

    public List<Reports> Reports { get; }
}
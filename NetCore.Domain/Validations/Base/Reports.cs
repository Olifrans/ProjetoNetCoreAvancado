namespace NetCore.Domain.Validations.Base
{
    public class Reports
    {
        public Reports()
        {
        }

        public Reports(string message)
        {
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }

        public static Reports Create(string message) => new Reports(message);
    }
}
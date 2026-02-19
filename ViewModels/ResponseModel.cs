namespace BankAccountManagmentSystemApi.ViewModels
{
    public class ResponseModel<T>
    {
        public List<T> List { get; set; } = new List<T>();
        public T? Object { get; set; }
        public string Msg { get; set; } = string.Empty;
        public bool Error { get; set; } = false;
        public int StatusCode { get; set; } = 200;
    }
}

namespace BankAccountManagmentSystemApi.ViewModels
{
public class ResponseModel<T>
    {
        /// <summary>
        /// لیست داده‌ها (مثلاً چند حساب بانکی)
        /// </summary>
        public List<T> List { get; set; } = new List<T>();

        /// <summary>
        /// یک شیء منفرد (مثلاً یک حساب بانکی خاص)
        /// </summary>
        public T? Object { get; set; }

        /// <summary>
        /// پیام خطا یا وضعیت
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// آیا عملیات موفق بود یا نه
        /// </summary>
        public bool Error { get; set; } = false;

        /// <summary>
        /// می‌توانید فیلدهای اضافی هم اضافه کنید مثل کد وضعیت
        /// </summary>
        public int StatusCode { get; set; } = 200;
    }
}

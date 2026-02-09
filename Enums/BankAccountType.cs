namespace BankAccountManagmentSystemApi.Enums
{
    public enum BankAccountType
    {
        Current = 1,           // حساب جاری
        Savings = 2,           // حساب پس‌انداز قرض‌الحسنه
        ShortTermDeposit = 3,  // سپرده کوتاه مدت
        LongTermDeposit = 4,   // سپرده بلند مدت
        Loan = 5,              // حساب تسهیلات
        Credit = 6,            // حساب اعتباری
        Corporate = 7,         // حساب حقوقی
        Joint = 8,             // حساب مشترک
        ForeignCurrency = 9    // حساب ارزی
    }
}

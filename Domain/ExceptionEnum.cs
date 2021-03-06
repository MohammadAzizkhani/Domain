using System.ComponentModel;

namespace Domain
{
    public enum LoginException
    {
        [Description("نام کاربری یا رمز عبور صحیح نمی باشد.")]
        UserNotFound = 0,
        [Description("کاربر غیر فعال می باشد .")]
        UserIsInactive = 1
    }

    public enum CreateUserException
    {
        [Description("ساخت کاربر با مشکل رو برو شد.")]
        Failed = 0
    }

    public enum ChangePasswordException
    {
        [Description("تغییر رمز کاربر با مشکل رو برو شد.")]
        Failed = 0
    }

    public enum CreatePersonException
    {
        [Description("شخصی با این کد ملی وجود دارد.")]
        AlreadyExist = 0
    }

    public enum CreateProjectException
    {
        [Description("Max Amount Must be Greater than Min")]
        MaxAmountMustBeGreaterThanMin = 0
    }
    public enum CreateCustomerException
    {
        [Description("شخصی با این کد پسنی و صنف وجود دارد.")]
        AlreadyExist = 0
    }

    public enum GeneralException
    {
        [Description("مشتری با این کد وجود ندارد.")]
        NotFound = 0,
        [Description("Already Exist !")]
        AlreadyExist = 1
    }

    public enum EditIbanRequestException
    {
        [Description("فقط یک حساب باید اصلی باشد .")]
        InvalidMainAccount = 0,
        
    }
}

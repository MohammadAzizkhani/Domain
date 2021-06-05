using System.ComponentModel;

namespace Domain
{
    public enum LoginException
    {
        [Description("عملیات لاگین موفقیت آمیز نبود.")]
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
}

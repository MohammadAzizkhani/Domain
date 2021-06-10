namespace Domain.Enums
{
    public enum RequestTypeEnum : byte
    {
        MerchantRegister = 1,
        ChangeIban = 2,
        ChangeGuild = 3,
        ChangePostalCode = 4,
        TerminalDeactivation = 5,
        TerminalActivation = 6,
        ChangeCustomer = 7,
    }
}

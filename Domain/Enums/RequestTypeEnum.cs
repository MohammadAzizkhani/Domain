namespace Domain.Enums
{
    public enum RequestTypeEnum : byte
    {
        MerchantRegister = 1,
        ChangeCustomer = 2,
        ChangeIban = 3,
        ChangeGuild = 4,
        ChangePostalCode = 5,
        TerminalActivation = 6,
        TerminalDeactivation = 7
    }
}

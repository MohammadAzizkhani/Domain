namespace Domain.Enums
{
    public enum RequestTypeEnum : byte
    {
        MerchantRegister = 1,
        IbanRegister = 2,
        ChangeCustomer = 3,
        ChangeIban = 4,
        ChangeGuild = 5,
        ChangePostalCode = 6,
        TerminalActivation = 7,
        TerminalDeactivation = 8
    }
}

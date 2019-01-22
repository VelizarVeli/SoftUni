namespace Eventures.Common
{
    public static class ErrorMessages
    {
        public const string NotUniqueUsername = "There is already user with that username.";

        public const string NotAllowedUsernameChars = "The username must consists of only alphanumeric charactes, dashes, underscores, dots, asterisks and tilders.";
               
        public const string UsernameLength = "The username must be at least 3 symbols long.";

        public const string NotUniqueEmail = "There is already user with that email.";

        public const string NotUniqueUCN = "UCN must be unique. There is already registerd user with such UCN.";

        public const string UcnLenght = "UCN must exactly 10 numbers long.";

        public const string PasswordLenght = "The password must be at least 5 and at max 20 characters";

        public const string PasswordsNotMatch = "The passwords do not match";

        public const string EventNameLenght = "The name should be at least 10 symbols long.";
        
        public const string StartDateEarlierThanToday = "The start date should not be earlier than today.";

        public const string EndDateLaterThanStartDate = "The end date should be after the start date.";

        public const string InvalidLogin = "XA-XA-XA Invalid login.";

        public const string NotEnoughTickets = "Only {0} tickets left.";

    }
}

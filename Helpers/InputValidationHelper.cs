namespace e_parking_garage.Helpers
{
    public static class InputValidationHelper
    {
        public static bool TryGetValidatedId(out long id)
        {
            var input = Console.ReadLine();

            if (!StringExtensions.TryParseToLong(input, out id))
                throw new FormatException("Input is not valid.");

            return true;
        }
    }
}

namespace Testing
{
    public interface INameMatchService
    {
        /*
         * True if and only if the customer is flying on that flight
         * The name must match name parts in any order and be case-insensitive
         * EXample: "DMITRY NOVIK" macthes "NOVIK DMITRY" matches "Novik Dmitry" ...
         */
        bool IsFlying(Customer customer, string flightNumber);
    }
}
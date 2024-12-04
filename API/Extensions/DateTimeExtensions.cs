using System.Runtime.CompilerServices;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dob)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            var age = today.Year - dob.Year;

            //have not yet had their birthday
            if (dob > today.AddYears(-1)) age--;

            return age;
        }
    }
}

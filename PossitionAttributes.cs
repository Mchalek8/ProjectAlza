using System;

namespace ProjectAlza
{
    class PossitionAttributes
    {
        public static void checkIfPositionIsForStudents(bool forStudentsAvailability)
        {
            if (forStudentsAvailability)
            {
                Console.WriteLine("The position is available for students.");
            }
            else
            {
                Console.WriteLine("The position is not available for students.");
            }
        }
    }
}

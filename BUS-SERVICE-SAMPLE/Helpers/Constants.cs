namespace BUS_SERVICE_SAMPLE.CommonConstants
{
    public static class Constants
    {
        /// <summary>
        /// User Roles
        /// </summary>
        public static class UserRole
        {
            public static int SUPER_USER = 99;
            public static int ADMIN = 9;
            public static int STUDENT = 1;
        }
        public static class Status
        {
            public static string Pending = "PENDING";
            public static string Accepted = "ACCEPTED";
            public static string Approved = "APPROVED";
            public static string Rejected = "REJECTED";
        }
    }
}

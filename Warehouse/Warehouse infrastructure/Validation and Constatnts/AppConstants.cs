using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public static class AppConstants
    {
        public static class Alert
        {
            public const string NO_OR_NULL_EMPLOYEE = "There are no employee. First, you need to hire it";
            public const string UNKNOWN_COMMAND = "Unknown command";
        }
        public static class Command
        {
            public const string ENTER_YOUR_CHOICE = "Enter your choice: ";
            public const string RETURN_TO_MAIN_MENU = "Return to 'Main Menu'";
        }
    }
}

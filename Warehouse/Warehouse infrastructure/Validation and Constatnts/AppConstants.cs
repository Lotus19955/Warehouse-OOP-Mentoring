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
            public const string OBJECT_SAVED = "Object saved";
            public const string NEW_OBJECT_WAREHOUSE_CREATED = "New object 'Warehouse' created";
            public const string PROGRAM_IS_RUNNING = "Program is running";
            public const string DATA_DOWNLOAD_COMPLITED = "Data download cpmplited";
            public const string ADDED_NEW_EMPLOYEE_WITH_ID = "Added new employee with id: ";
        }
        public static class Command
        {
            public const string ENTER_YOUR_CHOICE = "Enter your choice: ";
            public const string RETURN_TO_MAIN_MENU = "Return to 'Main Menu'";
            public const string RETURN = "Return";
        }

    }
}
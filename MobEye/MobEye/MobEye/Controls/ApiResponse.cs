using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Controls
{
    public class ApiResponse
    {
        public bool IsSuccessful => ErrorMessage == null; //If error is null, then api response was successful, else if error is not null, then api response was unsuccessful

        public String ErrorMessage
        {
            get;
            set;
        }

        public String JsonResponse
        {
            get;
            set;
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomIdentity.Utilities
{
    public static class Helper
    {

        public static string Admin = "Admin";
        public static string SuperAdmin = "SuperAdmin";
        public static string Operator = "Operator";
        public static string User = "User";

        //Response Messages
        
        //Status Code 
        public static int success_code = 1;
        public static int failure_code = 0;

        public static List<SelectListItem> GetRoleforDropDown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value = Helper.Admin,Text=Helper.Admin },
                    new SelectListItem{Value = Helper.User,Text=Helper.User },
                    new SelectListItem{Value = Helper.Operator,Text=Helper.Operator }
                };
            }
            else
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value = Helper.User,Text=Helper.User },
                    new SelectListItem{Value = Helper.Operator,Text = Helper.Operator }
                };
            }
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr 30 min" });
                minute = minute + 30;
            }
            return duration;
        }
    }
}

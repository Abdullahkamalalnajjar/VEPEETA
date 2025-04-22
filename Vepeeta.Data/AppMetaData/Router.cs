﻿namespace Vepeeta.Data.AppMetaData
{

    public static class Router
    {
        private const string SingleRoute = "{id}";
        private const string ListRoute = "List";


        private const string root = "Api";
        private const string version = "V1";
        private const string Rule = root + "/" + version;



        public static class StudentRouting
        {
            private const string Prefix = Rule + "/" + "Student/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class DepartmentRouting
        {
            private const string Prefix = Rule + "/" + "Department/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class UserRouting
        {
            private const string Prefix = Rule + "/" + "AppUser/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class DoctorRouting
        {
            private const string Prefix = Rule + "/" + "Doctor/";
            public const string List = Prefix + ListRoute;
            public const string NearestDoctor = Prefix + "NearestDoctor";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class RateRouting
        {
            private const string Prefix = Rule + "/" + "Rateing/";
            public const string List = Prefix + ListRoute;
            public const string NearestDoctor = Prefix + "NearestDoctor";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class ClinicRouting
        {
            private const string Prefix = Rule + "/" + "Clinic/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class VanRouting
        {
            private const string Prefix = Rule + "/" + "MobileVan/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class AuthenticationRouting
        {
            private const string Prefix = Rule + "/" + "Authentication/";
            public const string SginIn = Prefix + "SginIn";
        }
        public static class AuthorizationRouting
        {
            private const string Prefix = Rule + "/" + "Authorization/";
            public const string CreateRole = Prefix + "CreateRole";
            public const string MangeUserRoles = Prefix + "mange-user-roles/{userId}";
            public const string UpdateRole = Prefix + "UpdateRole";

        }
    }
}

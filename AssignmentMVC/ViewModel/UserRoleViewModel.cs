namespace AssignmentMVC.ViewModel
{
    public class UserRoleViewModel
    {


        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public IList<string> Roles { get; set; }
    }
}

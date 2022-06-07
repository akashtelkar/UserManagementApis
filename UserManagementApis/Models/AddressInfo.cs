namespace UserManagementApis.Models
{
    public class AddressInfo
    { 
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GioInfo geo { get; set; } = new GioInfo();
    }
}

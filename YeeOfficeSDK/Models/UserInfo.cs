using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Models
{
    public class UserInfo : BaseModel
    {
        public string Email { get; set; }
        public string Remark { get; set; }
        public bool Deleted { get; set; }
        public string PassWord { get; set; }
        public bool IsAdmin { get; set; }
        public string Extends1 { get; set; }
        public string Extends2 { get; set; }
        public string Extends3 { get; set; }
        public int JobGrade { get; set; }
        public long CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public DateTime LastLoginTime { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime LatestHireDate { get; set; }
        public string Mobile { get; set; }
        public string EmployeeNo { get; set; }
        public Dictionary<string, string> Attrs { get; set; }
        public string OfficeAddress { get; set; }
        public long TenantID { get; set; }
        public long AccountID { get; set; }
        public string Name_CN { get; set; }
        public string Name_EN { get; set; }
        public string SPAccount { get; set; }
        public UserStatusEnum Status { get; set; }
        public string SPAccount_Short { get; set; }
        public long DepartmentID { get; set; }
        public long LineManager { get; set; }
        public long LocationID { get; set; }
        public string Photo { get; set; }
        public string JobTitle { get; set; }
        public string Telephone { get; set; }
        public string Phone { get; set; }
    }
    public enum UserStatusEnum
    {
        Enabled = 1,
        Disabled = 2,
        Deleted = 4
    }
}

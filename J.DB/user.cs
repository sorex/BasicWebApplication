//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace J.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.user_loginlogs = new HashSet<user_loginlog>();
            this.uploadfiles = new HashSet<uploadfile>();
        }
    
        public string GUID { get; set; }
        public string ShowName { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
    
        public virtual ICollection<user_loginlog> user_loginlogs { get; set; }
        public virtual ICollection<uploadfile> uploadfiles { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllShowMVCApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEMBER
    {
        public MEMBER()
        {
            this.MEMBERLISTs = new HashSet<MEMBERLIST>();
            this.SHOPs = new HashSet<SHOP>();
        }
    
        public int memno { get; set; }
        public string mememail { get; set; }
        public string mempwd { get; set; }
        public string memdiminutive { get; set; }
        public string memname { get; set; }
        public string memsex { get; set; }
        public string memtel { get; set; }
        public string memaddress { get; set; }
        public string mempic { get; set; }
        public string memaccountstate { get; set; }
        public string memchecknumber { get; set; }
        public System.DateTime memcreatedate { get; set; }
        public Nullable<System.DateTime> memupdatedate { get; set; }
        public Nullable<System.DateTime> membirth { get; set; }
    
        public virtual ICollection<MEMBERLIST> MEMBERLISTs { get; set; }
        public virtual ICollection<SHOP> SHOPs { get; set; }
    }
}

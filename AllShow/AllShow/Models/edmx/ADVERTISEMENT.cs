//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllShow.Models.edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADVERTISEMENT
    {
        public int adNo { get; set; }
        public int shNo { get; set; }
        public int empNo { get; set; }
        public string adTitle { get; set; }
        public System.DateTime adApplyDate { get; set; }
        public System.DateTime adStartDate { get; set; }
        public double adTime { get; set; }
        public double adPrice { get; set; }
        public string adPic { get; set; }
        public string adURL { get; set; }
        public string adCheckState { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual SHOP SHOP { get; set; }
    }
}

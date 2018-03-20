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
    
    public partial class SHOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOP()
        {
            this.ADVERTISEMENTs = new HashSet<ADVERTISEMENT>();
            this.FAVORITESHOPLISTs = new HashSet<FAVORITESHOPLIST>();
            this.PRODUCTs = new HashSet<PRODUCT>();
            this.PRODUCTCLASSes = new HashSet<PRODUCTCLASS>();
            this.SHOPORDERs = new HashSet<SHOPORDER>();
        }
    
        public int shno { get; set; }
        public int empno { get; set; }
        public string shthepic { get; set; }
        public string shname { get; set; }
        public Nullable<int> shclassno { get; set; }
        public string shaccount { get; set; }
        public string shpwd { get; set; }
        public string shboss { get; set; }
        public string shcontact { get; set; }
        public string shaddress { get; set; }
        public string shtel { get; set; }
        public string shemail { get; set; }
        public string shabout { get; set; }
        public string shlogopic { get; set; }
        public string shurl { get; set; }
        public string shadstate { get; set; }
        public string shadtitle { get; set; }
        public string shadpic { get; set; }
        public string shpopshop { get; set; }
        public string shcheckstate { get; set; }
        public Nullable<System.DateTime> shstartdate { get; set; }
        public Nullable<System.DateTime> shenddate { get; set; }
        public Nullable<System.DateTime> shcheckdate { get; set; }
        public string shpwdstate { get; set; }
        public Nullable<System.DateTime> shstoprightstartdate { get; set; }
        public Nullable<System.DateTime> shstoprightenddate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADVERTISEMENT> ADVERTISEMENTs { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAVORITESHOPLIST> FAVORITESHOPLISTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTCLASS> PRODUCTCLASSes { get; set; }
        public virtual SHCLASS SHCLASS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOPORDER> SHOPORDERs { get; set; }
    }
}
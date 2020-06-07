//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfSer4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.AcceptanceSets = new HashSet<AcceptanceSet>();
        }
    
        public int Id { get; set; }
        public Nullable<bool> IsRequestOpen { get; set; }
        public Nullable<bool> IsAcceptedAR { get; set; }
        public bool IsPaid { get; set; }
        public bool IsSentACEmail { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcceptanceSet> AcceptanceSets { get; set; }
    }
}
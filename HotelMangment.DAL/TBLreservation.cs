//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelMangment.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLreservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLreservation()
        {
            this.TBLroomReservations = new HashSet<TBLroomReservation>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> fromDate { get; set; }
        public Nullable<System.DateTime> toDate { get; set; }
        public Nullable<int> noOFpeople { get; set; }
        public Nullable<int> typeReservation { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> customerId { get; set; }
    
        public virtual TBLcustomer TBLcustomer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLroomReservation> TBLroomReservations { get; set; }
    }
}

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
    
    public partial class TBLroom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLroom()
        {
            this.TBLroomReservations = new HashSet<TBLroomReservation>();
        }
    
        public int id { get; set; }
        public string roomNumber { get; set; }
        public Nullable<int> typeRoom { get; set; }
        public Nullable<int> noOFbed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLroomReservation> TBLroomReservations { get; set; }
    }
}

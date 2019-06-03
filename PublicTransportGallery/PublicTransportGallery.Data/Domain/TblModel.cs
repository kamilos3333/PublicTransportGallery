//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicTransportGallery.Data.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblModel()
        {
            this.TblImages = new HashSet<TblImage>();
        }
    
        public int ModelId { get; set; }
        public int ProducentId { get; set; }
        public string NameModel { get; set; }
        public int TypeId { get; set; }
        public int YearProduction { get; set; }
        public Nullable<int> YearProductionEnd { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblImage> TblImages { get; set; }
        public virtual TblProducent TblProducent { get; set; }
        public virtual TblTypeTransport TblTypeTransport { get; set; }
    }
}

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
    
    public partial class TblComment
    {
        public int CommentId { get; set; }
        public string ContentText { get; set; }
        public System.DateTime DateAdd { get; set; }
        public string UserId { get; set; }
        public int ImageId { get; set; }
    
        public virtual TblImage TblImage { get; set; }
    }
}

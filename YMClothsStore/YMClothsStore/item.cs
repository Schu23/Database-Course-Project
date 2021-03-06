//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YMClothsStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class item
    {
        public item()
        {
            this.applyDetail = new HashSet<applyDetail>();
            this.checkDetail = new HashSet<checkDetail>();
            this.image = new HashSet<image>();
            this.inDetail = new HashSet<inDetail>();
            this.orderDetail = new HashSet<orderDetail>();
            this.outDetail = new HashSet<outDetail>();
            this.stock = new HashSet<stock>();
        }
    
        public string itemId { get; set; }
        public string itemName { get; set; }
        public string itemSize { get; set; }
        public string itemColor { get; set; }
        public decimal itemStatus { get; set; }
        public decimal itemPrice { get; set; }
        public Nullable<System.DateTime> itemDate { get; set; }
    
        public virtual ICollection<applyDetail> applyDetail { get; set; }
        public virtual ICollection<checkDetail> checkDetail { get; set; }
        public virtual ICollection<image> image { get; set; }
        public virtual ICollection<inDetail> inDetail { get; set; }
        public virtual ICollection<orderDetail> orderDetail { get; set; }
        public virtual ICollection<outDetail> outDetail { get; set; }
        public virtual ICollection<stock> stock { get; set; }
    }
}

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
    
    public partial class address
    {
        public address()
        {
            this.shop = new HashSet<shop>();
        }
    
        public string addressId { get; set; }
        public string addressName { get; set; }
        public string addressDetail { get; set; }
        public Nullable<decimal> addressX { get; set; }
        public Nullable<decimal> addressY { get; set; }
    
        public virtual ICollection<shop> shop { get; set; }
    }
}

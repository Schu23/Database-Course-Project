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
    
    public partial class inBase
    {
        public inBase()
        {
            this.inDetail = new HashSet<inDetail>();
        }
    
        public string inId { get; set; }
        public string shopId { get; set; }
        public string staffId { get; set; }
        public Nullable<System.DateTime> inTime { get; set; }
    
        public virtual shop shop { get; set; }
        public virtual staff staff { get; set; }
        public virtual ICollection<inDetail> inDetail { get; set; }
    }
}

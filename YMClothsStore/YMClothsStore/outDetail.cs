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
    
    public partial class outDetail
    {
        public string outId { get; set; }
        public string itemId { get; set; }
        public Nullable<decimal> outAmount { get; set; }
    
        public virtual item item { get; set; }
        public virtual @out @out { get; set; }
    }
}

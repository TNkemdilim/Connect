//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Connect.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Data_Usage_Log
    {
        public int iD_U_Lid { get; set; }
        public int iFKBuyer_User_DetailsId { get; set; }
        public decimal dDataUsed { get; set; }
        public System.DateTime dtDateUsed { get; set; }
        public int iFKSellers_LoginId { get; set; }
    
        public virtual User_Details User_Details { get; set; }
        public virtual Sellers_Login Sellers_Login { get; set; }
    }
}

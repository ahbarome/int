//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INT.Service.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_DetalleMaquinaOnLine
    {
        public int Id { get; set; }
        public int NumeroMaquina { get; set; }
        public int IdSensor { get; set; }
    
        public virtual Tbl_SensorMaquinaOnline Tbl_SensorMaquinaOnline { get; set; }
        public virtual Tbl_MaquinaOnLine Tbl_MaquinaOnLine { get; set; }
    }
}

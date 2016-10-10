﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IntellisoftEntities : DbContext
    {
        public IntellisoftEntities()
            : base("name=IntellisoftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Scheduler> Scheduler { get; set; }
        public virtual DbSet<CurrentDevice> CurrentDevice { get; set; }
        public virtual DbSet<LoadTrace> LoadTrace { get; set; }
    
        public virtual int LoadDeviceData(string server, string ipAddress, string enrollmentNumber, Nullable<System.DateTime> registerDate)
        {
            var serverParameter = server != null ?
                new ObjectParameter("Server", server) :
                new ObjectParameter("Server", typeof(string));
    
            var ipAddressParameter = ipAddress != null ?
                new ObjectParameter("IpAddress", ipAddress) :
                new ObjectParameter("IpAddress", typeof(string));
    
            var enrollmentNumberParameter = enrollmentNumber != null ?
                new ObjectParameter("EnrollmentNumber", enrollmentNumber) :
                new ObjectParameter("EnrollmentNumber", typeof(string));
    
            var registerDateParameter = registerDate.HasValue ?
                new ObjectParameter("RegisterDate", registerDate) :
                new ObjectParameter("RegisterDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LoadDeviceData", serverParameter, ipAddressParameter, enrollmentNumberParameter, registerDateParameter);
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JGarciaProagroEntities : DbContext
    {
        public JGarciaProagroEntities()
            : base("name=JGarciaProagroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Georreferencia> Georreferencias { get; set; }
    
        public virtual int PermisosAdd(Nullable<int> idUsuario, Nullable<int> idEstado)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("idEstado", idEstado) :
                new ObjectParameter("idEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PermisosAdd", idUsuarioParameter, idEstadoParameter);
        }
    
        public virtual int PermisosDelete(Nullable<int> idUsuario, Nullable<int> idEstado)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("idEstado", idEstado) :
                new ObjectParameter("idEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PermisosDelete", idUsuarioParameter, idEstadoParameter);
        }
    
        public virtual ObjectResult<PermisosGetById_Result> PermisosGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PermisosGetById_Result>("PermisosGetById", idUsuarioParameter);
        }
    
        public virtual int PermisosUpdate(Nullable<int> idUsuario, Nullable<int> idEstado)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("idEstado", idEstado) :
                new ObjectParameter("idEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PermisosUpdate", idUsuarioParameter, idEstadoParameter);
        }
    
        public virtual int UsuarioAdd(string password, string nombre, Nullable<System.DateTime> fecharegistro, string rfc)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var fecharegistroParameter = fecharegistro.HasValue ?
                new ObjectParameter("fecharegistro", fecharegistro) :
                new ObjectParameter("fecharegistro", typeof(System.DateTime));
    
            var rfcParameter = rfc != null ?
                new ObjectParameter("rfc", rfc) :
                new ObjectParameter("rfc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", passwordParameter, nombreParameter, fecharegistroParameter, rfcParameter);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string password, string nombre, Nullable<System.DateTime> fecharegistro, string rfc)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var fecharegistroParameter = fecharegistro.HasValue ?
                new ObjectParameter("fecharegistro", fecharegistro) :
                new ObjectParameter("fecharegistro", typeof(System.DateTime));
    
            var rfcParameter = rfc != null ?
                new ObjectParameter("rfc", rfc) :
                new ObjectParameter("rfc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, passwordParameter, nombreParameter, fecharegistroParameter, rfcParameter);
        }
    
        public virtual int GeorreferenciasAdd(Nullable<int> idEstado, Nullable<double> latitud, Nullable<double> longitud)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            var latitudParameter = latitud.HasValue ?
                new ObjectParameter("latitud", latitud) :
                new ObjectParameter("latitud", typeof(double));
    
            var longitudParameter = longitud.HasValue ?
                new ObjectParameter("longitud", longitud) :
                new ObjectParameter("longitud", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeorreferenciasAdd", idEstadoParameter, latitudParameter, longitudParameter);
        }
    
        public virtual int GeorreferenciasDelete(Nullable<int> idGeorreferencias)
        {
            var idGeorreferenciasParameter = idGeorreferencias.HasValue ?
                new ObjectParameter("idGeorreferencias", idGeorreferencias) :
                new ObjectParameter("idGeorreferencias", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeorreferenciasDelete", idGeorreferenciasParameter);
        }
    
        public virtual ObjectResult<GeorreferenciasGetById_Result> GeorreferenciasGetById(Nullable<int> idGeorreferencias)
        {
            var idGeorreferenciasParameter = idGeorreferencias.HasValue ?
                new ObjectParameter("IdGeorreferencias", idGeorreferencias) :
                new ObjectParameter("IdGeorreferencias", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GeorreferenciasGetById_Result>("GeorreferenciasGetById", idGeorreferenciasParameter);
        }
    
        public virtual int GeorreferenciasUpdate(Nullable<int> idGeorreferencias, Nullable<int> idEstado, Nullable<double> latitud, Nullable<double> longitud)
        {
            var idGeorreferenciasParameter = idGeorreferencias.HasValue ?
                new ObjectParameter("idGeorreferencias", idGeorreferencias) :
                new ObjectParameter("idGeorreferencias", typeof(int));
    
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("idEstado", idEstado) :
                new ObjectParameter("idEstado", typeof(int));
    
            var latitudParameter = latitud.HasValue ?
                new ObjectParameter("latitud", latitud) :
                new ObjectParameter("latitud", typeof(double));
    
            var longitudParameter = longitud.HasValue ?
                new ObjectParameter("longitud", longitud) :
                new ObjectParameter("longitud", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GeorreferenciasUpdate", idGeorreferenciasParameter, idEstadoParameter, latitudParameter, longitudParameter);
        }
    
        public virtual ObjectResult<GeorreferenciasGetAll_Result> GeorreferenciasGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GeorreferenciasGetAll_Result>("GeorreferenciasGetAll");
        }
    
        public virtual ObjectResult<EstadoGetAll_Result> EstadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetAll_Result>("EstadoGetAll");
        }
    
        public virtual ObjectResult<PermisosGetAll_Result> PermisosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PermisosGetAll_Result>("PermisosGetAll");
        }
    
        public virtual ObjectResult<UsuarioDDL_Result> UsuarioDDL()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioDDL_Result>("UsuarioDDL");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class Permisos
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query = context.PermisosGetAll().ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Permisos permisos = new ML.Permisos();
                            permisos.Usuario = new ML.Usuario();
                            permisos.Estado = new ML.Estado();

                            permisos.Usuario.IdUsuario = item.IdUsuario;
                            permisos.Usuario.Nombre = item.Nombre;
                            permisos.Estado.IdEstado = item.IdEstado;
                            permisos.Estado.Estado1 = item.Estado;

                            result.Objects.Add(permisos);
                        }
                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query= context.PermisosGetById(IdUsuario).SingleOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Permisos permisos= new ML.Permisos();
                        permisos.Usuario.IdUsuario = query.IdUsuario.Value;
                        permisos.Estado.IdEstado= query.IdEstado.Value;

                        result.Object = permisos;

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Permisos permisos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var rowAffected = context.PermisosAdd(
                        permisos.Usuario.IdUsuario,
                        permisos.Estado.IdEstado);

                    if(rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al Agregar";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Permisos permisos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.PermisosUpdate(
                        permisos.Usuario.IdUsuario,
                        permisos.Estado.IdEstado
                        );

                    if(rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al alactualizar";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario, int IdEstado)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.PermisosDelete( IdUsuario, IdEstado );

                    if(rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;  
        }
    }
}

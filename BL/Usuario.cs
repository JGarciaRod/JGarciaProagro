using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query = context.UsuarioGetAll().ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Passwoord = item.Password;
                            usuario.Nombre = item.Nombre;
                            usuario.FechaIngreso = item.FechaRegistro.Value;
                            usuario.RFC = item.RFC;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
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
                    var query = context.UsuarioGetById(IdUsuario).SingleOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Passwoord = query.Password;
                        usuario.Nombre = query.Nombre;
                        usuario.FechaIngreso = query.FechaRegistro.Value;
                        usuario.RFC = query.RFC;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result  = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.UsuarioAdd(
                        usuario.Passwoord,
                        usuario.Nombre,
                        usuario.FechaIngreso,
                        usuario.RFC
                        );
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al incertar";
                    }
                }
            }
            catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.UsuarioUpdate(usuario.IdUsuario,
                        usuario.Passwoord,
                        usuario.Nombre,
                        usuario.FechaIngreso,
                        usuario.RFC);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.UsuarioDelete(IdUsuario);

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
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result DropDownList()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query = context.UsuarioDDL().ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;

                            result.Objects.Add(usuario);
                            
                        }
                    result.Correct = true;
                    }
                }
            }
            catch (Exception e)
            {
               result.Correct= false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
    }
}

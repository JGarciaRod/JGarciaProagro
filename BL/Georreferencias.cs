using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Georreferencias
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query = context.GeorreferenciasGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Georreferencias georreferencias = new ML.Georreferencias();
                            georreferencias.Estado = new ML.Estado();

                            georreferencias.IdGeorreferencias = item.IdGeorreferencias;
                            georreferencias.Estado.IdEstado = item.IdEstado;
                            georreferencias.Estado.Estado1 = item.Estado;
                            georreferencias.Latitud =  double.Parse(item.Latitud.ToString());
                            georreferencias.Longitud = double.Parse(item.Longitud.ToString());

                            result.Objects.Add(georreferencias);
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

        public static ML.Result GetById(int IdGeorreferencias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query = context.GeorreferenciasGetById(IdGeorreferencias).SingleOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Georreferencias georreferencias = new ML.Georreferencias();
                        georreferencias.Estado =new ML.Estado();
                        georreferencias.IdGeorreferencias = query.IdGeorreferencias;
                        georreferencias.Estado.IdEstado = query.IdEstado.Value;
                        georreferencias.Latitud = double.Parse(query.Latitud.ToString());
                        georreferencias.Longitud = double.Parse(query.Longitud.ToString());

                        result.Object = georreferencias;

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

        public static ML.Result Add(ML.Georreferencias georreferencias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.GeorreferenciasAdd(
                        georreferencias.Estado.IdEstado, georreferencias.Latitud , georreferencias.Longitud);

                    if(rowAffected > 0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "Error al incertar";
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

        public static ML.Result Update(ML.Georreferencias georreferencias)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.GeorreferenciasUpdate(
                        georreferencias.IdGeorreferencias,
                        georreferencias.Estado.IdEstado,
                        georreferencias.Latitud,
                        georreferencias.Longitud);
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
            catch(Exception ex)
            {
                result.Correct = false; 
                result.ErrorMessage = ex.Message; 
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdGeorreferencias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    int rowAffected = context.GeorreferenciasDelete(IdGeorreferencias);

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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}

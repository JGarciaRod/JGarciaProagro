using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaProagroEntities context = new DL.JGarciaProagroEntities())
                {
                    var query = context.EstadoGetAll().ToList();
                    if(query!=null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            
                            estado.IdEstado = item.IdEstado;
                            estado.Estado1 = item.Estado;

                            result.Objects.Add(estado);
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
    }
}

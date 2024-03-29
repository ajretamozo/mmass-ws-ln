﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebAppMmassImport.Clases;
using WebApi.Helpers;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;


namespace WebAppMmassImport
{
    /// <summary>
    /// Descripción breve de wsimport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsimport : System.Web.Services.WebService
    {
        [WebMethod]
        public string addContacto(contactos registro)
        {
            resultado res = registro.grabarContacto();
            return res.id.ToString() + res.rdo + res.descripcion;
        }
        [WebMethod]
        public respuesta addOrden(orden_publicitaria registro)
        {
            respuesta resp = new respuesta();
            resp.Estado = "VALIDACION";
            resp.Id = registro.IdOPMMASS;
            bool error = false;

            int update = registro.IdOPMMASS;
            var jsonString = new JavaScriptSerializer();
            var jsonStringResult = jsonString.Serialize(registro);

            if (registro.NroOP == "")
            {
                resp.Descripcion += " - Debe enviar un Nro de OP";
                error = true;
            }

            if (registro.IdOPMMASS < 0)
            {
                resp.Descripcion += " - Debe enviar un IdOPMMASS";
                error = true;
            }

            if (registro.IdOPMMASS == 0)
            {
                int idOPExistente = registro.comprobarNroOP();
                if (idOPExistente > 0)
                {
                    resp.Descripcion += "La OP nº: " + registro.NroOP + " que intenta crear, ya existe con el idOPMMASS: " + idOPExistente;
                    error = true;
                }
            }
            else
            {
                if (!registro.comprobarIdOrden())
                {
                    resp.Descripcion += "El IdOPMMASS enviado no existe";
                    error = true;
                }
            }

            if (registro.getIdEmpresa(registro.Empresa) == 0)
            {
                resp.Descripcion += " - La Empresa enviada no existe";
                error = true;
            }

            if (registro.getIdMedio(registro.Sennal) == 0)
            {
                resp.Descripcion += " - El Medio enviado no existe";
                error = true;
            }

            if (registro.comprobarContacto(registro.CUIAgencia) == 0 && registro.RazSocAgencia == "")
            {
                resp.Descripcion += " - Debe enviar la Razón Social de la Agencia";
                error = true;
            }

            if (registro.comprobarContacto(registro.CUIAnunciante) == 0 && registro.RazSocAnunciante == "")
            {
                resp.Descripcion += " - Debe enviar la Razón Social del Anunciante";
                error = true;
            }

            if (registro.MarcaDescripcion == "")
            {
                resp.Descripcion += " - Debe enviar un Producto";
                error = true;
            }

            if (registro.comprobarProducto(registro.MarcaDescripcion) == 0)
            {
                if (registro.getIdCompetitivo(registro.CompetitivoDescripcion) == 0)
                {
                    resp.Descripcion += " - El Competitivo enviado no existe";
                    error = true;
                }
            }

            if (registro.Estado != 3 && registro.Estado != 4 && registro.Estado != 5)
            {
                resp.Descripcion += " - El Estado enviado no existe";
                error = true;
            }

            if (registro.ResponsableOrden == "")
            {
                resp.Descripcion += " - Debe enviar un Responsable";
                error = true;
            }

            if (registro.FechaVencimiento == "")
            {
                resp.Descripcion += " - Debe enviar una Fecha de Vencimiento";
                error = true;
            }

            if (registro.Estado == 4 && registro.comprobarMenLevantadas() == true)
            {
                resp.Descripcion += " - No se puede anular la OP porque contiene Menciones en Rutina";
                error = true;
            }

            int contErr = 0;
            int contErr2 = 0;
            int contErr3 = 0;
            int contErr4 = 0;
            int contErr5 = 0;
            int contErr6 = 0;
            int contErr7 = 0;
            int contErr8 = 0;
            int contErr9 = 0;

            string rengErr = "";
            string rengErr2 = "";
            string rengErr3 = "";
            string rengErr4 = "";
            string rengErr5 = "";
            string rengErr6 = "";
            string rengErr7 = "";
            string rengErr8 = "";
            string rengErr9 = "";          


            foreach (renglon elem in registro.Renglones)
            {
                int contErr10 = 0;
                string rengErr10 = "";

                if (elem.TemaMaterialusar == "")
                {
                    contErr2++;
                    if (contErr2 < 2)
                    {
                        rengErr2 = elem.NroDeRenglon.ToString();
                    }
                    else
                    {
                        rengErr2 += ", " + elem.NroDeRenglon;
                    }
                    error = true;
                }

                if (registro.getIdCategoria(elem.TipoPublicidad) == 0)
                {
                    contErr++;
                    if (contErr < 2)
                    {
                        rengErr = elem.NroDeRenglon.ToString();
                    }
                    else
                    {
                        rengErr += ", " + elem.NroDeRenglon;
                    }                 
                    error = true;
                }

                if (elem.Duracion < 1)
                {
                    contErr3++;
                    if (contErr3 < 2)
                    {
                        rengErr3 = elem.NroDeRenglon.ToString();
                    }
                    else
                    {
                        rengErr3 += ", " + elem.NroDeRenglon;
                    }
                    error = true;
                }

                //if (elem.PrecioSegundo < 0 || elem.PrecioSegundo >= 1000000)
                if (elem.PrecioSegundo < 0)
                {
                    contErr4++;
                    if (contErr4 < 2)
                    {
                        rengErr4 = elem.NroDeRenglon.ToString();
                    }
                    else
                    {
                        rengErr4 += ", " + elem.NroDeRenglon;
                    }
                    error = true;
                }

                if (elem.CodigoMaterial == "")
                {
                    contErr5++;
                    if (contErr5 < 2)
                    {
                        rengErr5 = elem.NroDeRenglon.ToString();
                    }
                    else
                    {
                        rengErr5 += ", " + elem.NroDeRenglon;
                    }
                    error = true;
                }

                if (elem.ProgramaDescripcion != "")
                {
                    int idProg = registro.comprobarPrograma(elem.ProgramaDescripcion);
                    if (idProg == 0)
                    {
                        contErr6++;
                        if (contErr6 < 2)
                        {
                            rengErr6 = elem.NroDeRenglon.ToString();
                        }
                        else
                        {
                            rengErr6 += ", " + elem.NroDeRenglon;
                        }
                        error = true;
                    }

                    //COMENTADO PORQUE ESTA VALIDACIÓN YA LA HACEN DESDE NOTABLES
                    //else 
                    //{
                    //    if (elem.HoraDesdeCompraBloqHorario != "" && elem.HoraHastaCompraBloqHorario != "")
                    //    {
                    //        if(registro.getEmision(idProg, elem.HoraDesdeCompraBloqHorario, elem.HoraHastaCompraBloqHorario) == 0)
                    //        {
                    //            contErr9++;
                    //            if (contErr9 < 2)
                    //            {
                    //                rengErr9 = elem.NroDeRenglon.ToString();
                    //            }
                    //            else
                    //            {
                    //                rengErr9 += ", " + elem.NroDeRenglon;
                    //            }
                    //            error = true;
                    //        }                     
                    //    }
                    //    else
                    //    {
                    //        contErr8++;
                    //        if (contErr8 < 2)
                    //        {
                    //            rengErr8 = elem.NroDeRenglon.ToString();
                    //        }
                    //        else
                    //        {
                    //            rengErr8 += ", " + elem.NroDeRenglon;
                    //        }
                    //        error = true;
                    //    }
                    //}

                    foreach (mencion men in elem.Menciones)
                    {
                        DateTime diaEmision = Convert.ToDateTime(men.DiaDEEmision);
                        if (diaEmision > DateTime.Today)
                        {
                            bool existe = registro.verificarEmision(men.DiaDEEmision, elem.HoraDesdeCompraBloqHorario, elem.HoraHastaCompraBloqHorario, idProg);

                            if (existe == false)
                            {
                                contErr10++;
                                if (contErr10 < 2)
                                {
                                    rengErr10 = men.DiaDEEmision;
                                }
                                else
                                {
                                    rengErr10 += ", " + men.DiaDEEmision;
                                }
                                error = true;
                            }
                        }    
                    }
                    if (contErr10 == 1)
                    {
                        resp.Descripcion += " - No se encontraron Emisiones del Programa enviado para la Mención " + rengErr10 + " del Renglón " + elem.NroDeRenglon.ToString();
                    }
                    else if (contErr10 > 1)
                    {
                        resp.Descripcion += " - No se encontraron Emisiones del Programa enviado para las Menciones " + rengErr10 + " del Renglón " + elem.NroDeRenglon.ToString();
                    }
                }

                //Modificado para que valide que manden horarios si o si

                //if (elem.ProgramaDescripcion == "" && (elem.HoraDesdeCompraBloqHorario == "" || elem.HoraHastaCompraBloqHorario == ""))
                //{
                //        contErr7++;
                //        if (contErr7 < 2)
                //        {
                //            rengErr7 = elem.NroDeRenglon.ToString();
                //        }
                //        else
                //        {
                //            rengErr7 += ", " + elem.NroDeRenglon;
                //        }
                //        error = true;
                //}

                if (elem.HoraDesdeCompraBloqHorario == "" || elem.HoraHastaCompraBloqHorario == "")
                {
                    contErr7++;
                    if (contErr7 < 2)
                    {
                        rengErr7 = elem.NroDeRenglon.ToString();
                    }
                    else
                    {
                        rengErr7 += ", " + elem.NroDeRenglon;
                    }
                    error = true;
                }
            }

            if (contErr2 == 1)
            {
                resp.Descripcion += " - Debe enviar un Tema en el Renglón " + rengErr2;
            }
            else if (contErr2 > 1)
            {
                resp.Descripcion += " - Debe enviar un Tema en los Renglones " + rengErr2;
            }
            if (contErr == 1)
            {
                resp.Descripcion += " - El Tipo de Publicidad enviado en el Renglón " + rengErr + " no existe";
            }
            else if (contErr > 1)
            {
                resp.Descripcion += " - El Tipo de Publicidad enviado en los Renglones " + rengErr + " no existe";
            }
            if (contErr3 == 1)
            {
                resp.Descripcion += " - La Duración enviada en el Renglón " + rengErr3 + " debe ser mayor a 0";
            }
            else if (contErr3 > 1)
            {
                resp.Descripcion += " - La Duración enviada en los Renglones " + rengErr3 + " debe ser mayor a 0";
            }
            //if (contErr4 == 1)
            //{
            //    resp.Descripcion += " - El Precio enviado en el Renglón " + rengErr4 + " debe ser mayor o igual a 0 y menor a 1 Millón";
            //}
            //else if (contErr4 > 1)
            //{
            //    resp.Descripcion += " - El Precio enviado en los Renglones " + rengErr4 + " debe ser mayor o igual a 0 y menor a 1 Millón";
            //}
            if (contErr4 == 1)
            {
                resp.Descripcion += " - El Precio enviado en el Renglón " + rengErr4 + " debe ser mayor o igual a 0";
            }
            else if (contErr4 > 1)
            {
                resp.Descripcion += " - El Precio enviado en los Renglones " + rengErr4 + " debe ser mayor o igual a 0";
            }
            if (contErr5 == 1)
            {
                resp.Descripcion += " - Debe enviar un Código de Material en el Renglón " + rengErr5;
            }
            else if (contErr5 > 1)
            {
                resp.Descripcion += " - Debe enviar un Código de Material en los Renglones " + rengErr5;
            }
            if (contErr6 == 1)
            {
                resp.Descripcion += " - El Programa enviado en el Renglón " + rengErr6 + " no existe o hay más de uno";
            }
            else if (contErr6 > 1)
            {
                resp.Descripcion += " - El Programa enviado en los Renglones " + rengErr6 + " no existe o hay más de uno";
            }
            //if (contErr7 == 1)
            //{
            //    resp.Descripcion += " - Debe enviar Horarios y/o Programa en el Renglón " + rengErr7;
            //}
            //else if (contErr7 > 1)
            //{
            //    resp.Descripcion += " - Debe enviar Horarios y/o Programa en los Renglones " + rengErr7;
            //}
            if (contErr7 == 1)
            {
                resp.Descripcion += " - Debe enviar Horarios en el Renglón " + rengErr7;
            }
            else if (contErr7 > 1)
            {
                resp.Descripcion += " - Debe enviar Horarios en los Renglones " + rengErr7;
            }
            if (contErr8 == 1)
            {
                resp.Descripcion += " - Debe enviar Horarios para el Programa en el Renglón " + rengErr8;
            }
            else if (contErr8 > 1)
            {
                resp.Descripcion += " - Debe enviar Horarios para el Programa en los Renglones " + rengErr8;
            }
            if (contErr9 == 1)
            {
                resp.Descripcion += " - El Horario enviado en el Renglón " + rengErr9 + " debe estar contenido en por lo menos una de las emisiones del Programa enviado";
            }
            else if (contErr9 > 1)
            {
                resp.Descripcion += " - Los Horarios enviados en los Renglones " + rengErr9 + " deben estar contenidos en por lo menos una de las emisiones de los Programas enviados";
            }


            if (error == false)
            {
                resp = registro.saveOrden();

                // Se graba LOG con el XML recibido en la tabla 'auditoria'
                registro.grabarLog(update, resp.Id, jsonStringResult);
            }
            return resp;
        }

        [WebMethod]
        public respuestaMenciones consultarMenciones(string fechaDesde, string fechaHasta)
        {
            respuestaMenciones respuesta = new respuestaMenciones();

            if (fechaDesde == "" || fechaHasta == "")
            {
                respuesta.Estado = "VALIDACION";
                respuesta.Descripcion = "Debe ingresar valores para 'fechaDesde' y 'fechaHasta'";
                return respuesta;
            }
            else
            {
                DateTime fechaD = Convert.ToDateTime(fechaDesde);
                DateTime fechaH = Convert.ToDateTime(fechaHasta);
                if (fechaD > fechaH)
                {
                    respuesta.Estado = "VALIDACION";
                    respuesta.Descripcion = "La 'fechaHasta' debe ser posterior a la 'fechaDesde'";
                    return respuesta;
                }
                else
                {
                   return respuesta = orden_publicitaria.consulMenciones(fechaDesde, fechaHasta);
                }
            }
        }

    }
}

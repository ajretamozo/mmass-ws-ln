using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApi.Helpers;
using System.Transactions;

namespace WebAppMmassImport.Clases
{
    public class respuesta
    {
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int Id { get; set; }
    }

    public class montos
    {
        public double monto { get; set; }
        public int segundos { get; set; }
    }

    public class mencion
    {
        public string DiaDEEmision { get; set; }
        public string Ubicacion { get; set; }
        public int UbicacionManualOrden { get; set; }
        public int TotalMenciones { get; set; }
    }
    public class renglon
    {
        public int NroDeRenglon { get; set; }
        public string ProgramaDescripcion { get; set; }
        public string HoraDesdeCompraBloqHorario { get; set; }
        public string HoraHastaCompraBloqHorario { get; set; }
        public int Duracion { get; set; }
        public double PrecioSegundo { get; set; }
        public string CodigoMaterial { get; set; }
        public string TemaMaterialusar { get; set; }
        public string TipoPublicidad { get; set; }
        public List<mencion> Menciones;
    }

    public class orden_publicitaria
    {
        public string Empresa { get; set; } 
        public int Estado { get; set; } 
        public string CUIAgencia { get; set; } 
        public string RazSocAgencia { get; set; } 
        public string CUIAnunciante { get; set; } 
        public string RazSocAnunciante { get; set; } 
        public int Periodo { get; set; } 
        public string Sennal { get; set; } 
        public string NroOP { get; set; } 
        public string NroOrden { get; set; } 
        public int IdOPMMASS { get; set; } 
        public string MarcaDescripcion { get; set; } 
        public string CompetitivoDescripcion { get; set; } 
        public string ResponsableOrden { get; set; } 
        public string Comentarios { get; set; } 
        public int TotalGralMenciones { get; set; }
        public string FechaVencimiento { get; set; }
        public List<renglon> Renglones; 


        public respuesta saveOrden()
        {
            respuesta resp = new respuesta();
            try
            {               
                string sql = "";
                string periodoStg = Periodo.ToString();
                int Anio = int.Parse(periodoStg.Substring(0, 4));
                int Mes = int.Parse(periodoStg.Substring(4));
                int nro_orden = 0;
                bool esUpdate = false;
                //para strings con apóstrofe
                RazSocAgencia = RazSocAgencia.Replace("'", @"''");
                RazSocAnunciante = RazSocAnunciante.Replace("'", @"''");
                Sennal = Sennal.Replace("'", @"''");
                MarcaDescripcion = MarcaDescripcion.Replace("'", @"''");
                Comentarios = Comentarios.Replace("'", @"''");

                // Si es nuevo va insert, sino update
                if (IdOPMMASS == 0)
                {
                    DB.Execute("if not exists(select * from numerador_op WHERE anio = " + Anio + " and mes = " + Mes + ") insert into numerador_op(anio, mes, nro_orden) values(" + Anio + ", " + Mes + ", 0)");

                    DataTable dt = DB.Select("SELECT Isnull(MAX(IsNull(nro_orden, 0)), 0) + 1 as ultimo FROM numerador_op WHERE anio = " + Anio + " and mes = " + Mes);
                    if (dt.Rows.Count == 1)
                    {
                        nro_orden = int.Parse(dt.Rows[0]["ultimo"].ToString());
                    }
                    DB.Execute("UPDATE numerador_op SET nro_orden = " + nro_orden + "  WHERE anio = " + Anio + " and mes = " + Mes);

                    sql = "insert into orden_pub_ap (id_op, anio, mes, nro_orden, id_empresa, id_medio, fecha, fecha_expiracion, id_agencia, id_anunciante, id_producto, " +
                            " observ, es_anulada, fecha_anulada, nro_orden_imp, parairradiar, fecha_alta, id_concepto_negocio, id_moneda, id_condpagoap, id_tipoorden, id_representacion, " +
                            "tipo_orden, nro_orden_ag, estadoaprobcred, es_preventa)" +
                            " values (@id_op, @anio, @mes, @nro_orden, @id_empresa, @id_medio, @fecha, @fecha_expiracion, @id_agencia, @id_anunciante, @id_producto, " +
                            " @observ, @es_anulada, @fecha_anulada, @nro_orden_imp, @parairradiar, @fecha_alta, @id_concepto_negocio, @id_moneda, 1, 1, 1, 0, @nro_orden_ag, 1, 0)";

                    DataTable t = DB.Select("select IsNull(max(id_op),0) as ultimo from orden_pub_ap");
                    if (t.Rows.Count == 1)
                    {
                        IdOPMMASS = int.Parse(t.Rows[0]["ULTIMO"].ToString()) + 1;
                        if (IdOPMMASS == 1)
                            IdOPMMASS = 5001;
                    }
                }

                else
                {
                    esUpdate = true;
                    DataTable dt = DB.Select("SELECT nro_orden FROM orden_pub_ap WHERE id_op = " + IdOPMMASS);
                    if (dt.Rows.Count == 1)
                    {
                        nro_orden = int.Parse(dt.Rows[0]["nro_orden"].ToString());
                    }

                    sql = "update orden_pub_ap set nro_orden = @nro_orden, id_empresa = @id_empresa, id_medio = @id_medio, fecha = @fecha, fecha_expiracion = @fecha_expiracion, " +
                          "id_agencia = @id_agencia, id_anunciante = @id_anunciante, id_producto = @id_producto, observ = @observ, es_anulada = @es_anulada, fecha_anulada = @fecha_anulada, " +
                          "nro_orden_imp = @nro_orden_imp, parairradiar = @parairradiar, fecha_alta = @fecha_alta, id_concepto_negocio=@id_concepto_negocio, id_moneda=@id_moneda, " +
                          "id_condpagoap=1, id_tipoorden=1, id_representacion=1, tipo_orden=0, nro_orden_ag=@nro_orden_ag, estadoaprobcred=1, es_preventa=0 " +
                          "where id_op = @id_op";
                }

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter() { ParameterName = "@id_op", SqlDbType = SqlDbType.Int, Value = IdOPMMASS });
                if (Anio != 0)
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@anio", SqlDbType = SqlDbType.Int, Value = Anio });
                }
                if (Mes != 0)
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@mes", SqlDbType = SqlDbType.Int, Value = Mes });
                }

                parametros.Add(new SqlParameter() { ParameterName = "@nro_orden", SqlDbType = SqlDbType.Int, Value = DB.DInt(nro_orden) });

                if (NroOrden == "")
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@nro_orden_ag", SqlDbType = SqlDbType.NVarChar, Value = "0" });
                }
                else
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@nro_orden_ag", SqlDbType = SqlDbType.NVarChar, Value = NroOrden });
                }

                int Id_empresa = getIdEmpresa(Empresa);
                parametros.Add(new SqlParameter() { ParameterName = "@id_empresa", SqlDbType = SqlDbType.Int, Value = Id_empresa });

                int Id_medio = getIdMedio(Sennal);
                if (DB.DInt(Id_medio) == 0)
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@id_medio", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
                }
                else
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@id_medio", SqlDbType = SqlDbType.Int, Value = DB.DInt(Id_medio) });
                }
        
                DateTime Fecha = new DateTime(Anio,Mes,01);
                DateTime fechaVen = DateTime.Parse(FechaVencimiento);

                parametros.Add(new SqlParameter() { ParameterName = "@fecha", SqlDbType = SqlDbType.DateTime, Value = Fecha });
                parametros.Add(new SqlParameter() { ParameterName = "@fecha_expiracion", SqlDbType = SqlDbType.DateTime, Value = fechaVen });

                int Id_agencia = comprobarContacto(CUIAgencia);
                bool agenNueva = false;
                if (Id_agencia == 0)
                {  
                    resultado res = new resultado();
                    contactos con = new contactos();
                    con.razon_social = RazSocAgencia;
                    con.rfc = CUIAgencia;
                    con.rol = "AGENCIA";
                    res = con.grabarContacto();
                    Id_agencia = res.id;
                    agenNueva = true;
                }
                    parametros.Add(new SqlParameter() { ParameterName = "@id_agencia", SqlDbType = SqlDbType.Int, Value = Id_agencia });              

                int Id_anunciante = comprobarContacto(CUIAnunciante);
                bool anunNuevo = false;
                if (Id_anunciante == 0)
                {
                    resultado res = new resultado();
                    contactos con = new contactos();
                    con.razon_social = RazSocAnunciante;
                    con.rfc = CUIAnunciante;
                    con.rol = "ANUNCIANTE";
                    res = con.grabarContacto();
                    Id_anunciante = res.id;
                    anunNuevo = true;

                    //vincular anunciante nuevo con agencia
                    vincularContactos(Id_agencia, Id_anunciante);
                }
                else
                {
                    if (agenNueva == true)
                    {
                        //vincular agencia nueva con anunciante existente
                        vincularContactos(Id_agencia, Id_anunciante);
                    }
                }
                    parametros.Add(new SqlParameter() { ParameterName = "@id_anunciante", SqlDbType = SqlDbType.Int, Value = Id_anunciante });       

                int Id_producto = comprobarProducto(MarcaDescripcion);
                if (Id_producto == 0)
                {
                    int Id_competitivo = getIdCompetitivo(CompetitivoDescripcion);
                    Id_producto = saveProducto(Id_competitivo, MarcaDescripcion, Id_anunciante);
                }
                if (Id_producto != 0)
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@id_producto", SqlDbType = SqlDbType.Int, Value = Id_producto });
                    
                    if (anunNuevo == true)
                    {
                        //vincular producto con anunciante nuevo
                        vincularProducto(Id_producto, Id_anunciante);
                    }
                }
                else
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@id_producto", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
                }    

                    parametros.Add(new SqlParameter() { ParameterName = "@observ", SqlDbType = SqlDbType.NVarChar, Value = Comentarios });

                if (Estado == 3)
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@parairradiar", SqlDbType = SqlDbType.Int, Value = 1 });
                    parametros.Add(new SqlParameter() { ParameterName = "@es_anulada", SqlDbType = SqlDbType.Int, Value = 0 });
                    parametros.Add(new SqlParameter() { ParameterName = "@fecha_anulada", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });
                }
                else if (Estado == 4) 
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@parairradiar", SqlDbType = SqlDbType.Int, Value = 0 });
                    parametros.Add(new SqlParameter() { ParameterName = "@es_anulada", SqlDbType = SqlDbType.Int, Value = 1 });
                    parametros.Add(new SqlParameter() { ParameterName = "@fecha_anulada", SqlDbType = SqlDbType.DateTime, Value = DateTime.Today });
                }
                else if (Estado == 5)
                {
                    parametros.Add(new SqlParameter() { ParameterName = "@parairradiar", SqlDbType = SqlDbType.Int, Value = 1 });
                    parametros.Add(new SqlParameter() { ParameterName = "@es_anulada", SqlDbType = SqlDbType.Int, Value = 0 });
                    parametros.Add(new SqlParameter() { ParameterName = "@fecha_anulada", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });
                }
      
                    parametros.Add(new SqlParameter() { ParameterName = "@nro_orden_imp", SqlDbType = SqlDbType.NVarChar, Value = NroOP });         

                DateTime Fecha_alta = DateTime.Now;
                parametros.Add(new SqlParameter() { ParameterName = "@fecha_alta", SqlDbType = SqlDbType.DateTime, Value = Fecha_alta });

                int idConcepto = getIdConcepto("TV");
                parametros.Add(new SqlParameter() { ParameterName = "@id_concepto_negocio", SqlDbType = SqlDbType.Int, Value = idConcepto }); // 4 = TV

                parametros.Add(new SqlParameter() { ParameterName = "@id_moneda", SqlDbType = SqlDbType.Int, Value = 1 });

                using (TransactionScope transaccion = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(0, 5, 0)))
                {
                    // Grabo Cabecera...
                    DB.Execute(sql, parametros);

                    // Grabo tabla orden_pub_pagos
                    DB.Execute("delete from orden_pub_pagos where id_op = " + IdOPMMASS.ToString());
                    sql = "insert into orden_pub_pagos (id_op, anio, mes, nro_orden, id_formapago, porcentaje, PorcCanje, xCliente) " +
                              "values (@id_op, @anio, @mes, @nro_orden, 1, 100, 0, 0)";

                    List<SqlParameter> parametroso = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                            new SqlParameter()
                            { ParameterName="@anio",SqlDbType = SqlDbType.Int, Value = Anio },
                            new SqlParameter()
                            { ParameterName="@mes",SqlDbType = SqlDbType.Int, Value = Mes },
                            new SqlParameter()
                            { ParameterName="@nro_orden",SqlDbType = SqlDbType.Int, Value = DB.DInt(nro_orden) }
                        };
                    DB.Execute(sql, parametroso);

                    // Grabo los Renglones...
                    //foreach (renglon elem in Renglones)
                    //{
                    //    DB.Execute("delete from menciones where id_detalle = " + elem.NroDeRenglon.ToString() + "and id_op = " + IdOPMMASS.ToString());
                    //}
                    DB.Execute("delete from menciones where fecharutina > GETDATE() and id_op = " + IdOPMMASS.ToString());
                    // Limpio Renglones que no tengan Menciones...
                    String sqlDet = "select id_detalle from orden_pub_as where id_op = " + IdOPMMASS.ToString();
                    List<int> detalles = new List<int>();
                    int idDetalle;
                    DataTable tDet = DB.Select(sqlDet);

                    foreach (DataRow item in tDet.Rows)
                    {
                        idDetalle = DB.DInt(item["id_detalle"].ToString());
                        
                        string sqlCommand = "select id_menciones from menciones where id_op =" + IdOPMMASS.ToString() + " and id_detalle =" + idDetalle.ToString();
                        DataTable t = DB.Select(sqlCommand);
                        if (t.Rows.Count == 0)
                        {
                            DB.Execute("delete from orden_pub_as where id_op = " + IdOPMMASS.ToString() + " and id_detalle =" + idDetalle.ToString());
                        }
                    }

                    montos mon = new montos();
                    double montoTotal = 0;
                    int segPag = 0;

                    foreach (renglon elem in Renglones)
                    {
                        elem.ProgramaDescripcion = elem.ProgramaDescripcion.Replace("'", @"''");
                        mon = saveRenglon(elem, Anio, Mes, Id_producto, Id_anunciante, Id_medio, Fecha, fechaVen, nro_orden, Id_empresa, esUpdate);
                        montoTotal += mon.monto;
                        segPag += mon.segundos;
                    }

                    string sqlOp2 = "update orden_pub_ap set monto_bruto=@monto_bruto, primer_neto=@primer_neto, seg_neto=@seg_neto, tercer_neto=@tercer_neto, " +
                                    "seg_pagados=@seg_pagados where id_op = @id_op";
                    List<SqlParameter> parametrosOp2 = new List<SqlParameter>()
                {
                    new SqlParameter()
                    { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                    new SqlParameter()
                    { ParameterName="@monto_bruto",SqlDbType = SqlDbType.Decimal, Value = montoTotal },
                    new SqlParameter()
                    { ParameterName="@primer_neto",SqlDbType = SqlDbType.Decimal, Value = montoTotal },
                    new SqlParameter()
                    { ParameterName="@seg_neto",SqlDbType = SqlDbType.Decimal, Value = montoTotal },
                    new SqlParameter()
                    { ParameterName="@tercer_neto",SqlDbType = SqlDbType.Decimal, Value = montoTotal },
                    new SqlParameter()
                    { ParameterName="@seg_pagados",SqlDbType = SqlDbType.Int, Value = segPag }
                };
                    DB.Execute(sqlOp2, parametrosOp2);

                    // Ejecutivos
                    int Id_ejecutivo = comprobarEjecutivo(ResponsableOrden);

                    if (Id_ejecutivo == 0)
                    {
                        resultado res = new resultado();
                        contactos con = new contactos();
                        con.razon_social = ResponsableOrden;
                        con.rol = "EJECUTIVO";
                        res = con.grabarContacto();
                        Id_ejecutivo = res.id;
                    }

                    DB.Execute("delete from orden_pub_agentes where id_op = " + IdOPMMASS.ToString());
                    sql = "insert into orden_pub_agentes (id_op, id_agente, anio, mes, nro_orden, nro_agente_op, tipo_rol, porcentaje, tipo_agente, tipo_rol_padre) " +
                              "values (@id_op, @id_agente, @anio, @mes, @nro_orden, @nro_agente_op, @tipo_rol, @porcentaje, @tipo_agente, @tipo_rol_padre)";
             
                        List<SqlParameter> parametrose = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                            new SqlParameter()
                            { ParameterName="@id_agente",SqlDbType = SqlDbType.Int, Value = Id_ejecutivo },
                            new SqlParameter()
                            { ParameterName="@anio",SqlDbType = SqlDbType.Int, Value = Anio },
                            new SqlParameter()
                            { ParameterName="@mes",SqlDbType = SqlDbType.Int, Value = Mes },
                            new SqlParameter()
                            { ParameterName="@nro_orden",SqlDbType = SqlDbType.Int, Value = DB.DInt(nro_orden) },
                            new SqlParameter()
                            { ParameterName="@nro_agente_op",SqlDbType = SqlDbType.Int, Value = 1 },
                            new SqlParameter()
                            { ParameterName="@tipo_rol",SqlDbType = SqlDbType.Int, Value = 2 },
                            new SqlParameter()
                            { ParameterName="@porcentaje",SqlDbType = SqlDbType.Float, Value = 0 },
                            new SqlParameter()
                            { ParameterName="@tipo_agente",SqlDbType = SqlDbType.Int, Value = 0 },
                            new SqlParameter()
                            { ParameterName="@tipo_rol_padre",SqlDbType = SqlDbType.Int, Value = 1 }
                        };
                        DB.Execute(sql, parametrose);
              
                    transaccion.Complete();
                }
                resp.Estado = "OK";
                if (Estado == 4)
                {
                    resp.Descripcion = "La Orden se anuló con exito";
                }
                else
                {
                    resp.Descripcion = "La Orden se envió con exito";
                }                
                resp.Id = IdOPMMASS;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resp.Estado = "ERROR";
                resp.Descripcion = "Se produjo un error al enviar la Orden: " + ex.Message;
                resp.Id = IdOPMMASS;
            }
            return resp;
        }

        public int getIdEmpresa(string razon)
        {
            string sqlCommand = "select id_empresa from empresa where razon_social like '" + razon + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_empresa"].ToString());
            }
            return resultado;
        }

        public int getIdMedio(string nombre)
        {
            string sqlCommand = "select id_medio from medios where desc_medio like '" + nombre + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_medio"].ToString());
            }
            return resultado;
        }

        public int comprobarContacto(string cui)
        {
            string sqlCommand = "select id_contacto from contactos where id_contactoenlace like '" + cui + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_contacto"].ToString());
            }
            return resultado;
        }

        public int comprobarProducto(string desc)
        {
            string sqlCommand = "select id_producto from productos where desc_producto like '" + desc + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_producto"].ToString());
            }
            return resultado;
        }

        public static int comprobarEjecutivo(string nombre)
        {
            string sqlCommand = "select id_contacto from contactos where nombre_com like '" + nombre + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_contacto"].ToString());
            }
            return resultado;
        }

        public int getIdCompetitivo(string desc)
        {
            string sqlCommand = "select id_competitivo from competitivos where desc_competitivo like '" + desc + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_competitivo"].ToString());
            }
            return resultado;
        }

        public int saveProducto(int idComp, string descProd, int idAnun)
        {
            String sqlId = "select max(id_producto) as maximo from productos";
            int nuevoId = 0;
            DataTable t = DB.Select(sqlId);           

            if (t.Rows.Count == 1)
            {
                nuevoId = DB.DInt(t.Rows[0]["maximo"].ToString());
                nuevoId++;
            }
            
            string sql = "insert into productos(id_producto, id_competitivo, desc_producto, es_borrado, fecha_modificacion) " +
                         "values (@id_producto, @id_competitivo, @desc_producto, 0, @fecha_modificacion)";
   

            List<SqlParameter> parametrosP = new List<SqlParameter>()
            {
                            new SqlParameter()
                            { ParameterName="@id_producto",SqlDbType = SqlDbType.Int, Value = nuevoId },
                            new SqlParameter()
                            { ParameterName="@id_competitivo",SqlDbType = SqlDbType.Int, Value = idComp },
                            new SqlParameter()
                            { ParameterName="@desc_producto",SqlDbType = SqlDbType.NVarChar, Value = descProd },
                            new SqlParameter()
                            { ParameterName="@fecha_modificacion",SqlDbType = SqlDbType.DateTime, Value = DateTime.Today }
            };

            try
            {
                DB.Execute(sql, parametrosP);
                vincularProducto(nuevoId, idAnun);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return nuevoId;
        }

 
        public montos saveRenglon(renglon reng, int anio, int mes, int idProd, int idAnun, int idMedio, DateTime fechaD, DateTime fechaH, int nro_orden, int idEmpresa, bool esUpdate)
        {
            montos mon = new montos();

            string sqlCommand1 = "select id_detalle from orden_pub_as where id_op = " + IdOPMMASS + " and id_detalle = " + reng.NroDeRenglon;

            bool esUpdateRen = false;
            DataTable t1 = DB.Select(sqlCommand1);

            if (t1.Rows.Count == 1)
            {
                esUpdateRen = true;
            }

            string sql = "";

            if (esUpdateRen == false)
            {
                sql = "insert into orden_pub_as(id_op, anio, mes, nro_orden, id_detalle, id_programa, id_producto, hs_desde, hs_hasta, duracion, id_anunciante, id_medio, imp_tarifa, cod_material, " +
                      "id_tema, es_pnt, tipo_sel_ubicacion, fecha_desde, fecha_hasta, id_categoria, id_categoria_ubi, tipo_tarifa, clase_tarifa, id_tarifa, tipo_suger, id_duracion, formausotarifa, " +
                      "id_empresa, id_estadoaprobacion, id_usuario_aprob, fecha_aprob, tar_formauso, id_emisiones_pgma) " +
                      "values (@id_op, @anio, @mes, @nro_orden, @id_detalle, @id_programa, @id_producto, @hs_desde, @hs_hasta, @duracion, @id_anunciante, @id_medio, @imp_tarifa, @cod_material," +
                      " @id_tema, @es_pnt, 0, @fecha_desde, @fecha_hasta, @id_categoria, @id_categoria_ubi, 3, 0, 1, @tipo_suger, 1, 0, @id_empresa, 4, 1, @fecha_aprob, 0, @id_emisiones_pgma)";
            }
            else
            {
                sql = "update orden_pub_as set id_programa=@id_programa, id_producto=@id_producto, " +
                      "hs_desde=@hs_desde, hs_hasta=@hs_hasta, duracion=@duracion, id_anunciante=@id_anunciante, id_medio=@id_medio, imp_tarifa=@imp_tarifa, cod_material=@cod_material, " +
                      "id_tema=@id_tema, es_pnt=@es_pnt, tipo_sel_ubicacion=0, fecha_desde=@fecha_desde, fecha_hasta=@fecha_hasta, id_categoria=@id_categoria, id_categoria_ubi=@id_categoria_ubi, " +
                      "tipo_tarifa=3, clase_tarifa=0, id_tarifa=1, tipo_suger=@tipo_suger, id_duracion=1, formausotarifa=0, " +
                      "id_empresa=@id_empresa, id_estadoaprobacion=4, id_usuario_aprob=1, fecha_aprob=@fecha_aprob, tar_formauso=0, id_emisiones_pgma=@id_emisiones_pgma " +
                      "where id_op = " + IdOPMMASS + " and id_detalle = " + reng.NroDeRenglon ;
            }


            int idProg = comprobarPrograma(reng.ProgramaDescripcion);
            int idEmi = 0;

            if (idProg != 0)
            {
                idEmi = getEmision(idProg, reng.HoraDesdeCompraBloqHorario, reng.HoraHastaCompraBloqHorario);
            }

            DateTime horaD = DateTime.Parse(reng.HoraDesdeCompraBloqHorario);
            DateTime horaH = DateTime.Parse(reng.HoraHastaCompraBloqHorario);

            int idTipoMat = getIdCompetitivo(CompetitivoDescripcion);
            int idTema = comprobarTema(idProd, reng.CodigoMaterial, reng.Duracion);
            int idCategoria = getIdCategoria(reng.TipoPublicidad);
            
            string sqlCommand = "select es_pnt from categorias where id_categoria = " + idCategoria;

            int esPnt = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                esPnt = DB.DInt(t.Rows[0]["es_pnt"].ToString());
            }

            if (idTema == 0)
            {               
                idTema = saveTema(idProd, reng.TemaMaterialusar, idTipoMat, reng.Duracion, reng.CodigoMaterial, idMedio);
            }

            List<SqlParameter> parametrosR = new List<SqlParameter>()
            {
                            new SqlParameter()
                            { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                            new SqlParameter()
                            { ParameterName="@anio",SqlDbType = SqlDbType.Int, Value = anio },
                            new SqlParameter()
                            { ParameterName="@mes",SqlDbType = SqlDbType.Int, Value = mes },
                            new SqlParameter()
                            { ParameterName="@nro_orden",SqlDbType = SqlDbType.Int, Value = nro_orden },
                            new SqlParameter()
                            { ParameterName="@id_detalle",SqlDbType = SqlDbType.Int, Value = reng.NroDeRenglon },
                            new SqlParameter()
                            { ParameterName="@duracion",SqlDbType = SqlDbType.Int, Value = reng.Duracion },
                            new SqlParameter()
                            { ParameterName="@id_anunciante",SqlDbType = SqlDbType.Int, Value = idAnun },
                            new SqlParameter()
                            { ParameterName="@imp_tarifa",SqlDbType = SqlDbType.Decimal, Value = reng.PrecioSegundo },
                            new SqlParameter()
                            { ParameterName="@cod_material",SqlDbType = SqlDbType.NVarChar, Value = reng.CodigoMaterial },
                            new SqlParameter()
                            { ParameterName="@id_tema",SqlDbType = SqlDbType.Int, Value = idTema },
                            new SqlParameter()
                            { ParameterName="@fecha_desde",SqlDbType = SqlDbType.DateTime, Value = fechaD },
                            new SqlParameter()
                            { ParameterName="@fecha_hasta",SqlDbType = SqlDbType.DateTime, Value = fechaH },
                            new SqlParameter()
                            { ParameterName="@id_categoria_ubi",SqlDbType = SqlDbType.Int, Value = idCategoria },
                            new SqlParameter()
                            { ParameterName="@id_categoria",SqlDbType = SqlDbType.Int, Value = idCategoria },
                            new SqlParameter()
                            { ParameterName="@es_pnt",SqlDbType = SqlDbType.Int, Value = esPnt },
                            new SqlParameter()
                            { ParameterName="@id_empresa",SqlDbType = SqlDbType.Int, Value = idEmpresa },
                            new SqlParameter()
                            { ParameterName="@fecha_aprob",SqlDbType = SqlDbType.DateTime, Value = DateTime.Today }
            };
            if (idProg != 0 && idEmi != 0)
            {
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_programa", SqlDbType = SqlDbType.Int, Value = idProg });
                parametrosR.Add(new SqlParameter() { ParameterName = "@tipo_suger", SqlDbType = SqlDbType.Int, Value = 0 });
                parametrosR.Add(new SqlParameter() { ParameterName = "@hs_desde", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });
                parametrosR.Add(new SqlParameter() { ParameterName = "@hs_hasta", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_emisiones_pgma", SqlDbType = SqlDbType.Int, Value = idEmi });
            }
            else
            {
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_programa", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
                parametrosR.Add(new SqlParameter() { ParameterName = "@tipo_suger", SqlDbType = SqlDbType.Int, Value = 1 });
                parametrosR.Add(new SqlParameter() { ParameterName = "@hs_desde", SqlDbType = SqlDbType.DateTime, Value = horaD });
                parametrosR.Add(new SqlParameter() { ParameterName = "@hs_hasta", SqlDbType = SqlDbType.DateTime, Value = horaH });
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_emisiones_pgma", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
            }
            if (idProd != 0)
            {
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_producto", SqlDbType = SqlDbType.Int, Value = idProd });
            }
            else
            {
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_producto", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
            }
            if (DB.DInt(idMedio) == 0)
            {
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_medio", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
            }
            else
            {
                parametrosR.Add(new SqlParameter() { ParameterName = "@id_medio", SqlDbType = SqlDbType.Int, Value = DB.DInt(idMedio) });
            }

            try
            {
                DB.Execute(sql, parametrosR);

                // Grabo las Menciones...
                int contadorSpots = 0;
                if (esUpdateRen == true)
                {
                    string sqlCommandM = "select COUNT(id_menciones) as spots from menciones where id_op=" + IdOPMMASS + " and id_detalle=" + reng.NroDeRenglon;

                    DataTable tm = DB.Select(sqlCommandM);
                    if (tm.Rows.Count == 1)
                    {
                        contadorSpots = DB.DInt(tm.Rows[0]["spots"].ToString());
                    }
                }
                foreach (mencion elem in reng.Menciones)
                {
                    if (esUpdateRen == true)
                    {
                        DateTime diaEmision = Convert.ToDateTime(elem.DiaDEEmision);
                        if (diaEmision > DateTime.Today)
                        {
                            contadorSpots += elem.TotalMenciones;
                        }
                    }
                    else
                    {
                        contadorSpots += elem.TotalMenciones;
                    }
 
                    int cont = 0;
                    
                    if (esUpdateRen == true)
                    {
                        DateTime fechaHoy = DateTime.Now;
                        DateTime diaDEmision = DateTime.Parse(elem.DiaDEEmision);
                        while (cont < elem.TotalMenciones)
                        {
                            if (diaDEmision > fechaHoy)
                            {
                                saveMencion(elem, anio, mes, nro_orden, reng.NroDeRenglon, reng.TemaMaterialusar, idTema, reng.Duracion, idAnun, idMedio, horaD, horaH, idProd, idCategoria, esPnt, reng.PrecioSegundo, idProg, idEmi);
                            }
                            cont++;
                            //mon.monto += reng.Duracion * reng.PrecioSegundo;
                        }
                    }
                    else
                    {
                        while (cont < elem.TotalMenciones)
                        {
                            saveMencion(elem, anio, mes, nro_orden, reng.NroDeRenglon, reng.TemaMaterialusar, idTema, reng.Duracion, idAnun, idMedio, horaD, horaH, idProd, idCategoria, esPnt, reng.PrecioSegundo, idProg, idEmi);
                            cont++;
                            //mon.monto += reng.Duracion * reng.PrecioSegundo;
                        }
                    } 
                }
                mon.segundos = contadorSpots * reng.Duracion;
                mon.monto = mon.segundos * reng.PrecioSegundo;

                string sqlR2 = "update orden_pub_as set cant_spot=@cant_spot, seg_pag=@seg_pag, valor_mencion=@valor_mencion, monto_bruto=@monto_bruto, monto_neto=@monto_neto where id_op = @id_op and anio=@anio and mes=@mes and nro_orden=@nro_orden and id_detalle=@id_detalle";
                List<SqlParameter> parametrosR2 = new List<SqlParameter>()
                {
                    new SqlParameter()
                    { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                    new SqlParameter()
                    { ParameterName="@anio",SqlDbType = SqlDbType.Int, Value = anio },
                    new SqlParameter()
                    { ParameterName="@mes",SqlDbType = SqlDbType.Int, Value = mes },
                    new SqlParameter()
                    { ParameterName="@nro_orden",SqlDbType = SqlDbType.Int, Value =  DB.DInt(nro_orden) },
                    new SqlParameter()
                    { ParameterName="@id_detalle",SqlDbType = SqlDbType.Int, Value = reng.NroDeRenglon },
                    new SqlParameter()
                    { ParameterName = "@cant_spot", SqlDbType = SqlDbType.Int, Value = contadorSpots },
                    new SqlParameter()
                    { ParameterName = "@seg_pag", SqlDbType = SqlDbType.Int, Value = mon.segundos },
                    new SqlParameter()
                    { ParameterName="@valor_mencion",SqlDbType = SqlDbType.Decimal, Value = mon.monto },
                    new SqlParameter()
                    { ParameterName="@monto_bruto",SqlDbType = SqlDbType.Decimal, Value = mon.monto },
                    new SqlParameter()
                    { ParameterName="@monto_neto",SqlDbType = SqlDbType.Decimal, Value = mon.monto }
                };
                DB.Execute(sqlR2, parametrosR2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mon;
        }

        public int comprobarPrograma(string desc)
        {
            string sqlCommand = "select id_programa from programas where desc_programa like '" + desc + "'";
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_programa"].ToString());
            }
            return resultado;
        }

        public static int comprobarTema(int idProd, string codMat, int duracion)
        {
            string sqlCommand = "select id_tema from dur_tema_as where etiqueta like '" + codMat + "' and id_producto = " + idProd + " and duracion = " + duracion;
            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_tema"].ToString());
            }
            return resultado;
        }


        public int saveTema(int idProd, string descTema, int idTipoMat, int dur, string codMat, int idMedio)
        {
            String sqlId = "select max(id_tema) as maximo from temas";
            int nuevoId = 0;
            DataTable t = DB.Select(sqlId);

            if (t.Rows.Count == 1)
            {
                nuevoId = DB.DInt(t.Rows[0]["maximo"].ToString());
                nuevoId++;
            }

            string sql = "insert into temas(id_producto, id_tema, desc_tema, es_borrado, tipo_material, tipo_lectura, vig_desde) " +
                         "values (@id_producto, @id_tema, @desc_tema, 0, @tipo_material, 0, @vig_desde)";

            List<SqlParameter> parametrosT = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@id_producto",SqlDbType = SqlDbType.Int, Value = idProd },
                            new SqlParameter()
                            { ParameterName="@id_tema",SqlDbType = SqlDbType.Int, Value = nuevoId },
                            new SqlParameter()
                            { ParameterName="@desc_tema",SqlDbType = SqlDbType.NVarChar, Value = descTema },
                             new SqlParameter()
                            { ParameterName="@tipo_material",SqlDbType = SqlDbType.Int, Value = idTipoMat },
                            new SqlParameter()
                            { ParameterName="@vig_desde",SqlDbType = SqlDbType.DateTime, Value = DateTime.Today }
                        };

            string sql2 = "insert into dur_tema_ap(id_producto, id_tema, id_duracion, fecha_desde, duracion_total, no_facturable, no_certificable, no_vinculable) " +
                          "values (@id_producto, @id_tema, 1, @fecha_desde, @duracion_total, 0, 0, 0)";

            List<SqlParameter> parametros2 = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@id_producto",SqlDbType = SqlDbType.Int, Value = idProd },
                            new SqlParameter()
                            { ParameterName="@id_tema",SqlDbType = SqlDbType.Int, Value = nuevoId },
                            new SqlParameter()
                            { ParameterName="@fecha_desde",SqlDbType = SqlDbType.DateTime, Value = DateTime.Today },
                              new SqlParameter()
                            { ParameterName="@duracion_total",SqlDbType = SqlDbType.Int, Value = dur }
                        };
            
            string sql3 = "insert into dur_tema_as(id_producto, id_tema, id_duracion, id_item, duracion, texto, ubicacion, locucion, etiqueta, id_material, adascode, adascodepend, " +
                          "tipo_codmaterial, patharchivo) " +
                          "values (@id_producto, @id_tema, 1, 1, @duracion, @texto, @ubicacion, 0, @etiqueta, 0, @adascode, 0, 0, @patharchivo)";

            List<SqlParameter> parametros3 = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@id_producto",SqlDbType = SqlDbType.Int, Value = idProd },
                            new SqlParameter()
                            { ParameterName="@id_tema",SqlDbType = SqlDbType.Int, Value = nuevoId },
                            new SqlParameter()
                            { ParameterName="@fecha_desde",SqlDbType = SqlDbType.DateTime, Value = DateTime.Today },
                            new SqlParameter()
                            { ParameterName="@duracion",SqlDbType = SqlDbType.Int, Value = dur },
                            new SqlParameter()
                            { ParameterName="@texto",SqlDbType = SqlDbType.Text, Value = "" },
                            new SqlParameter()
                            { ParameterName="@ubicacion",SqlDbType = SqlDbType.NVarChar, Value = "" },
                            new SqlParameter()
                            { ParameterName="@etiqueta",SqlDbType = SqlDbType.NVarChar, Value = codMat },
                            new SqlParameter()
                            { ParameterName="@adascode",SqlDbType = SqlDbType.NVarChar, Value = codMat },
                            new SqlParameter()
                            { ParameterName="@patharchivo",SqlDbType = SqlDbType.NVarChar, Value = "" }
                        };


            string sql4 = "insert into dur_medios(id_producto, id_tema, id_duracion, id_medio) " +
                          "values (@id_producto, @id_tema, 1, @id_medio)";

            List<SqlParameter> parametros4 = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@id_producto",SqlDbType = SqlDbType.Int, Value = idProd },
                            new SqlParameter()
                            { ParameterName="@id_tema",SqlDbType = SqlDbType.Int, Value = nuevoId },
                            new SqlParameter()
                            { ParameterName="@id_medio",SqlDbType = SqlDbType.Int, Value = idMedio }
                        };

            try
            {
                DB.Execute(sql, parametrosT);
                DB.Execute(sql2, parametros2);
                DB.Execute(sql3, parametros3);
                DB.Execute(sql4, parametros4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return nuevoId;
        }

        public bool saveMencion(mencion men, int anio, int mes, int nro_orden, int idDet, string descTema, int idTema, int dur, int idCon, int idMed, DateTime hrD, DateTime hH, int idProd, int idCategoria, int esPnt, double precioSeg, int idProg, int idEmi)
        {
            bool resultado = true;

            string sql = "insert into menciones(fecharutina, id_op, anio, mes, nro_orden, id_detalle, desc_tema, id_tema, duracion, id_contacto, id_medio, horadesde, horahasta, tipo_orden_mencion, " +
                         "orden, msrepl_tran_version, es_pnt, es_levantada, id_representacion, id_producto, id_categoria, tipo_suger, id_duracion, es_tandaimpar, puede_mover, es_pauta, es_aleatorio, " +
                         "es_canje, es_solorutina, es_agregado, duracion_real, seg_art, seg_pagos, es_facturada, anio_fact, mes_fact, esta_pagada, importe, descuento, importe_neto, prating, " +
                         "id_programa, id_emisiones_pgma) " +
                         "values (@fecharutina, @id_op, @anio, @mes, @nro_orden, @id_detalle, @desc_tema, @id_tema, @duracion, @id_contacto, @id_medio, @horadesde, @horahasta, @tipo_orden_mencion, " +
                         "@orden, @msrepl_tran_version, @es_pnt, 0, 1, @id_producto, @id_categoria, @tipo_suger, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, @seg_pagos, 0, 0, 0, 0, @importe, 0, @importe_neto, 0, " +
                         "@id_programa, @id_emisiones_pgma)";

            Guid msrepl_tran_version = new Guid();
            DateTime diaDEmision = DateTime.Parse(men.DiaDEEmision);
            int tipoOrdenMencion = 0; //automático
            int orden = 0;
            if (men.Ubicacion == "CAB") //cabeza de tanda
            {
                tipoOrdenMencion = 1;
            }
            else if (men.Ubicacion == "MIT") //mitad de tanda
            {
                tipoOrdenMencion = 2;
            }
            else if (men.Ubicacion == "COL") //cola de tanda
            {
                tipoOrdenMencion = 3;
            }
            else if (men.Ubicacion == "MAN") //manual
            {
                tipoOrdenMencion = 4;
                orden = men.UbicacionManualOrden;
            }

            List<SqlParameter> parametrosM = new List<SqlParameter>()
                        {
                            new SqlParameter()
                            { ParameterName="@fecharutina",SqlDbType = SqlDbType.DateTime, Value = diaDEmision },
                             new SqlParameter()
                            { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                             new SqlParameter()
                            { ParameterName="@anio",SqlDbType = SqlDbType.Int, Value = anio },
                            new SqlParameter()
                            { ParameterName="@mes",SqlDbType = SqlDbType.Int, Value = mes },
                            new SqlParameter()
                            { ParameterName="@nro_orden",SqlDbType = SqlDbType.Int, Value =  DB.DInt(nro_orden) },
                            new SqlParameter()
                            { ParameterName="@id_detalle",SqlDbType = SqlDbType.Int, Value = idDet },
                            new SqlParameter()
                            { ParameterName="@desc_tema",SqlDbType = SqlDbType.NVarChar, Value = descTema },
                            new SqlParameter()
                            { ParameterName="@id_tema",SqlDbType = SqlDbType.Int, Value = idTema },
                            new SqlParameter()
                            { ParameterName="@duracion",SqlDbType = SqlDbType.Int, Value = dur },
                            new SqlParameter()
                            { ParameterName="@id_contacto",SqlDbType = SqlDbType.Int, Value = idCon },
                            new SqlParameter()
                            { ParameterName="@tipo_orden_mencion",SqlDbType = SqlDbType.Int, Value = tipoOrdenMencion },
                            new SqlParameter()
                            { ParameterName="@orden",SqlDbType = SqlDbType.Int, Value = orden },
                            new SqlParameter()
                            { ParameterName="@msrepl_tran_version",SqlDbType = SqlDbType.UniqueIdentifier, Value = msrepl_tran_version },
                            new SqlParameter()
                            { ParameterName="@id_categoria",SqlDbType = SqlDbType.Int, Value = idCategoria },
                            new SqlParameter()
                            { ParameterName="@es_pnt",SqlDbType = SqlDbType.Int, Value = esPnt },
                            new SqlParameter()
                            { ParameterName="@seg_pagos",SqlDbType = SqlDbType.Int, Value = dur },
                            new SqlParameter()
                            { ParameterName="@importe",SqlDbType = SqlDbType.Decimal, Value = dur * precioSeg },
                            new SqlParameter()
                            { ParameterName="@importe_neto",SqlDbType = SqlDbType.Decimal, Value = dur * precioSeg },
                        };

            if (idProg != 0 && idEmi != 0)
            {
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_programa", SqlDbType = SqlDbType.Int, Value = idProg });
                parametrosM.Add(new SqlParameter() { ParameterName = "@tipo_suger", SqlDbType = SqlDbType.Int, Value = 0 });
                parametrosM.Add(new SqlParameter() { ParameterName = "@horadesde", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });
                parametrosM.Add(new SqlParameter() { ParameterName = "@horahasta", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_emisiones_pgma", SqlDbType = SqlDbType.Int, Value = idEmi });
            }
            else
            {
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_programa", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
                parametrosM.Add(new SqlParameter() { ParameterName = "@tipo_suger", SqlDbType = SqlDbType.Int, Value = 1 });
                parametrosM.Add(new SqlParameter() { ParameterName = "@horadesde", SqlDbType = SqlDbType.DateTime, Value = hrD });
                parametrosM.Add(new SqlParameter() { ParameterName = "@horahasta", SqlDbType = SqlDbType.DateTime, Value = hH });
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_emisiones_pgma", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
            }
            if (idProd != 0)
            {
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_producto", SqlDbType = SqlDbType.Int, Value = idProd });
            }
            else
            {
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_producto", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
            }
            if (DB.DInt(idMed) == 0)
            {
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_medio", SqlDbType = SqlDbType.Int, Value = DBNull.Value });
            }
            else
            {
                parametrosM.Add(new SqlParameter() { ParameterName = "@id_medio", SqlDbType = SqlDbType.Int, Value = DB.DInt(idMed) });
            }
           
            try
            {
                DB.Execute(sql, parametrosM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resultado = false;
            }
            return resultado;
        }

        public int getIdCategoria(string desc)
        {
            string sqlCommand = "select id_categoria from categorias where desc_categoria like '" + desc + "'";

            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_categoria"].ToString());
            }
            return resultado;
        }

        public int getIdConcepto(string desc)
        {
            string sqlCommand = "select id_concepto_negocio from concepto_negocios where desc_concepto_negocio like '" + desc + "'";

            int resultado = 0;
            DataTable t = DB.Select(sqlCommand);

            if (t.Rows.Count == 1)
            {
                resultado = DB.DInt(t.Rows[0]["id_concepto_negocio"].ToString());
            }
            return resultado;
        }

        public int getEmision(int idProg, string hrDesde, string hrHasta)
        {
            string periodo = Periodo.ToString(); 
            string anio = periodo.Substring(0, 4);
            string mes = periodo.Substring(4, 2);
            string vigenciaD = anio + "-" + mes + "-" + "01";

            int resultado = 0;

            string sqlCommand = "declare @first datetime set @first = '" + hrDesde + "'" +
                                    " declare @second datetime set @second = '" + hrHasta + "'" +
                                    " select id_emisiones_pgma from emisiones_pgma where id_programa = " + idProg +
                                    " and ('" + vigenciaD + "' >= vigencia_desde) and (('" + FechaVencimiento + "' <= vigencia_hasta) or vigencia_hasta is null)" +
                                    " and((cast(cast(cast(@first as time) as datetime) as float) - floor(cast(cast(cast(@first as time) as datetime) as float))) >=" +
                                    " (cast(cast(cast(hs_desde as time) as datetime) as float) - floor(cast(cast(cast(hs_desde as time) as datetime) as float)))" +
                                    " and(cast(cast(cast(@second as time) as datetime) as float) - floor(cast(cast(cast(@second as time) as datetime) as float))) <=" +
                                    " (cast(cast(cast(hs_hasta as time) as datetime) as float) - floor(cast(cast(cast(hs_hasta as time) as datetime) as float))))";

            List<int> emisiones = new List<int>();
            int emision;
            DataTable t = DB.Select(sqlCommand);

            foreach (DataRow item in t.Rows)
            {
                emision = DB.DInt(item["id_emisiones_pgma"].ToString());

                emisiones.Add(emision);
            }

            if (emisiones.Count == 1)
            {
                resultado = emisiones[0];
            }
           
            return resultado;
        }

        public int vincularContactos(int idAgen, int idAnun)
        {
            String sqlId = "select max(id_vinculo) as maximo from vinculos";
            int nuevoId = 0;
            DataTable t = DB.Select(sqlId);

            if (t.Rows.Count == 1)
            {
                nuevoId = DB.DInt(t.Rows[0]["maximo"].ToString());
                nuevoId++;
            }

            string sql = "insert into vinculos(id_contacto, id_tipo_rol, id_contacto_padre, id_tipo_rol_padre, xctacte, id_vinculo, codigo) " +
                         "values (@id_contacto, 1, @id_contacto_padre, 0, 0, @id_vinculo, '')";


            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                            new SqlParameter()
                            { ParameterName="@id_contacto",SqlDbType = SqlDbType.Int, Value = idAnun },
                            new SqlParameter()
                            { ParameterName="@id_contacto_padre",SqlDbType = SqlDbType.Int, Value = idAgen },
                            new SqlParameter()
                            { ParameterName="@id_vinculo",SqlDbType = SqlDbType.Int, Value = nuevoId }
            };

            try
            {
                DB.Execute(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return nuevoId;
        }

        public int vincularProducto(int idProd, int idAnun)
        {
            int resultado = 0;

            string sql = "insert into anun_prod(id_producto, id_anunciante) " +
             "values (@id_producto, @id_anunciante)";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                            new SqlParameter()
                            { ParameterName="@id_producto",SqlDbType = SqlDbType.Int, Value = idProd },
                            new SqlParameter()
                            { ParameterName="@id_anunciante",SqlDbType = SqlDbType.Int, Value = idAnun }
            };
          

            try
            {
                DB.Execute(sql, parametros);
                resultado = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }

        public bool verificarEmision(string diaEmision, string horaDesde, string horaHasta, int idProg)
        {
            DateTime diaSem = Convert.ToDateTime(diaEmision);
            int diaNum = (int)diaSem.DayOfWeek;
            string dia = "";
           
            switch (diaNum)
            {
                case 1:
                    dia = "lun";
                    break;
                case 2:
                    dia = "mar";
                    break;
                case 3:
                    dia = "mie";
                    break;
                case 4:
                    dia = "jue";
                    break;
                case 5:
                    dia = "vie";
                    break;
                case 6:
                    dia = "sab";
                    break;
                case 0:
                    dia = "dom";
                    break;
            }

            //string periodo = Periodo.ToString();
            //string anio = periodo.Substring(0, 4);
            //string mes = periodo.Substring(4, 2);
            //string vigenciaD = anio + "-" + mes + "-" + "01";

            bool resultado = false;

            string sql = "declare @first datetime set @first = '" + horaDesde + "'" +
                                    " declare @second datetime set @second = '" + horaHasta + "'" +
                                    " select id_emisiones_pgma from emisiones_pgma where id_programa = " + idProg +
                                    " and ('" + diaEmision + "' >= vigencia_desde) and (('" + diaEmision + "' <= vigencia_hasta) or vigencia_hasta is null)" +
                                    " and((cast(cast(cast(@first as time) as datetime) as float) - floor(cast(cast(cast(@first as time) as datetime) as float))) >=" +
                                    " (cast(cast(cast(hs_desde as time) as datetime) as float) - floor(cast(cast(cast(hs_desde as time) as datetime) as float)))" +
                                    " and(cast(cast(cast(@second as time) as datetime) as float) - floor(cast(cast(cast(@second as time) as datetime) as float))) <=" +
                                    " (cast(cast(cast(hs_hasta as time) as datetime) as float) - floor(cast(cast(cast(hs_hasta as time) as datetime) as float))))" +
                                    " and " + dia + "=1";

            DataTable t = DB.Select(sql);

            if (t.Rows.Count == 1)
            {
                resultado = true;
            }
            return resultado;
        }

        public bool comprobarMenLevantadas()
        {
            string sqlCommand = "select id_menciones from menciones where es_levantada < 2 and id_rutina > 0 and id_op=" + IdOPMMASS;

            bool resultado = false;

            DataTable t = DB.Select(sqlCommand);
            if (t.Rows.Count > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public void LimpiarDetalles (int idDet)
        {
            string sqlCommandz = "select COUNT(*) as cantMen from orden_pub_as ops inner join menciones m on m.id_op = ops.id_op and m.id_detalle = ops.id_detalle where ops.id_op = @id_op and ops.id_detalle = @id_detalle";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                { ParameterName="@id_op",SqlDbType = SqlDbType.Int, Value = IdOPMMASS },
                 new SqlParameter()
                { ParameterName="@id_detalle",SqlDbType = SqlDbType.Int, Value = idDet }
            };

            DataTable tz = DB.Select(sqlCommandz, parametros);
            if (tz.Rows.Count == 1)
            {
                int cantMen = DB.DInt(tz.Rows[0]["cantMen"].ToString());
                if (cantMen == 0)
                {
                    DB.Execute("delete from orden_pub_as where id_op = " + IdOPMMASS.ToString() + " and id_detalle =" + idDet.ToString());
                }
            }

            //foreach (DataRow item in tz.Rows)
            //{
            //    int cantMen = DB.DInt(item["cantMen"].ToString());

            //    if (cantMen == 0)
            //    {
            //        DB.Execute("delete from orden_pub_as where id_op = " + IdOPMMASS.ToString() + " and ops.id_detalle =" + idDet.ToString());
            //    }
            //}
        }

    }
}
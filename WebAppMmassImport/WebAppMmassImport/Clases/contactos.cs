using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Helpers;

namespace WebAppMmassImport.Clases
{
    public class resultado
    {
        public int id { get; set; }
        public string rdo { get; set; }
        public string descripcion { get; set; }
    }
    public class relaciones
    {
        public string contacto_guid { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
    }
    public class emails
    {
        public string direccion { get; set; }
        public bool certifica { get; set; }
        public bool general { get; set; }
        public bool comprobantes { get; set; }
    }
    public class telefonos
    {
        public string tipo { get; set; }
        public string numero { get; set; }
        public string descripcion { get; set; }
    }

    public class domicilios
    {
        public string tipo { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string barrio { get; set; }
        public string localidad { get; set; }
        public string estado { get; set; }
    }
    public class contactos
    {
        public int id { get; set; }
        public string operacion { get; set; }
        public string razon_social { get; set; }
        public string rfc { get; set; }
        public string rol { get; set; }
        public string guid { get; set; }
        public string impuesto { get; set; }
        public bool requiere_expediente_fact { get; set; }        
        public List<domicilios> Domicilios { get; set; }
        public List<telefonos> Telefonos { get; set; }
        public List<emails> Emails { get; set; }
        public List<relaciones> Relaciones { get; set; }
        private int nuevoId() {
            String sqlId = "select max(id_contacto) as maximo from contactos";
            int nuevoId = 0;
            DataTable t = DB.Select(sqlId);

            if (t.Rows.Count == 1)
            {
                nuevoId = DB.DInt(t.Rows[0]["maximo"].ToString());
                nuevoId++;
            }
            return nuevoId;
        }
        public resultado grabarContacto()
        {
            resultado vres = new resultado();

            String sql = "";
            /* Saco el nuevo identificador... */
            string vIdCodigo = nuevoId().ToString();

            sql = "insert into contactos (id_contacto, contacto, ing_contacto, razon_social, nombre_com, id_contactoenlace, es_borrado, fecha_modificacion, account_id, req_exp_fact)" +
                " values (" + vIdCodigo + "," + vIdCodigo + ",getdate(),'" + razon_social + "','" + razon_social + "','" + rfc + "', 0, getdate(),'" + guid + "', 0 )";

            DB.Execute(sql);

            /* Rol del Contacto..*/
            int id_tipo_rol = 0; //AGENCIA

                    if (rol == "ANUNCIANTE")
                    {
                        id_tipo_rol = 1;
                    }
                    else if (rol == "EJECUTIVO")
                    {
                        id_tipo_rol = 2;
                    }
            String sqlR = "insert into roles(id_contacto,id_tipo_rol) values (" + vIdCodigo + "," + id_tipo_rol + ")";
            DB.Execute(sqlR);

            vres.id = int.Parse(vIdCodigo);

            return vres;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCargaOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(WSLaNacion.wsimportSoapClient client=new WSLaNacion.wsimportSoapClient())
            {
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 00);

                WSLaNacion.orden_publicitaria op = new WSLaNacion.orden_publicitaria();
                //op.Empresa = textBox1.Text;
                //op.Estado = int.Parse(textBox2.Text);
                //op.CUIAgencia = textBox3.Text;
                //op.RazSocAgencia = textBox4.Text;
                //op.CUIAnunciante = textBox5.Text;
                //op.RazSocAnunciante = textBox6.Text;
                //op.Periodo = int.Parse(textBox7.Text);
                //op.Sennal = textBox8.Text;
                //op.NroOP = int.Parse(textBox9.Text);
                //op.NroOrden = int.Parse(textBox10.Text);
                //op.IdOPMMASS = int.Parse(textBox11.Text);
                //op.MarcaDescripcion = textBox12.Text;
                //op.ResponsableOrden = textBox13.Text;
                //op.Comentarios = textBox14.Text;
                //op.FechaVencimiento = textBox15.Text;
                //op.CompetitivoDescripcion = textBox27.Text;

//                  <tem:mencion>
//                        <!--Optional:-->
//                        <tem:DiaDEEmision>2021-07-02</tem:DiaDEEmision>
//                        <!--Optional:-->
//                        <tem:Ubicacion>COL</tem:Ubicacion>
//                        <tem:UbicacionManualOrden>0</tem:UbicacionManualOrden>
//                        <tem:TotalMenciones>3</tem:TotalMenciones>
//                     </tem:mencion>
//                  </tem:Menciones>
//                  <tem:NroDeRenglon>1</tem:NroDeRenglon>
//                  <!--Optional:-->
//                  <tem:ProgramaDescripcion>Caminos a la Escuela</tem:ProgramaDescripcion>
//                  <!--Optional:-->
//                  <tem:HoraDesdeCompraBloqHorario>13:00:00</tem:HoraDesdeCompraBloqHorario>
//                  <!--Optional:-->
//                  <tem:HoraHastaCompraBloqHorario>18:00:00</tem:HoraHastaCompraBloqHorario>
//                  <tem:Duracion>13</tem:Duracion>
//                  <tem:PrecioSegundo>0</tem:PrecioSegundo>
//                  <!--Optional:-->
//                  <tem:CodigoMaterial>15542401</tem:CodigoMaterial>
//                  <!--Optional:-->
//                  <tem:TemaMaterialusar>M1</tem:TemaMaterialusar>
//                  <!--Optional:-->
//                  <tem:TipoPublicidad>Tanda</tem:TipoPublicidad>
//               </tem:renglon>
//            </tem:Renglones>
//            <!--Optional:-->
//            <tem:Empresa>SAPU</tem:Empresa>
//            <tem:Estado>3</tem:Estado>
//            <!--Optional:-->
//            <tem:CUIAgencia>A14164</tem:CUIAgencia>
//            <!--Optional:-->
//            <tem:RazSocAgencia>GRUPO PEÑAFLOR SA</tem:RazSocAgencia>
//            <!--Optional:-->
//            <tem:CUIAnunciante>A14164</tem:CUIAnunciante>
//            <!--Optional:-->
//            <tem:RazSocAnunciante>GRUPO PEÑAFLOR SA</tem:RazSocAnunciante>
//            <tem:Periodo>202107</tem:Periodo>
//            <!--Optional:-->
//            <tem:Sennal>LN+</tem:Sennal>
//            <!--Optional:-->
//            <tem:NroOP>7000006000</tem:NroOP>
//            <!--Optional:-->
//            <tem:NroOrden>0</tem:NroOrden>
//            <tem:IdOPMMASS>0</tem:IdOPMMASS>
//            <!--Optional:-->
//            <tem:MarcaDescripcion>T?tulo prueba MMASS 1</tem:MarcaDescripcion>
//            <!--Optional:-->
//            <tem:CompetitivoDescripcion>VARIOS</tem:CompetitivoDescripcion>
//            <!--Optional:-->
//            <tem:ResponsableOrden>Sebastian Rolando</tem:ResponsableOrden>
//            <!--Optional:-->
//            <tem:Comentarios>prueba German</tem:Comentarios>
//            <tem:TotalGralMenciones>3</tem:TotalGralMenciones>
//            <!--Optional:-->
//            <tem:FechaVencimiento>2021-07-05</tem:FechaVencimiento>
//         </tem:registro>
//      </tem:addOrden>
//   </soap:Body>
//</soap:Envelope>


                op.Empresa = "SAPU";
                op.Estado = 3;
                op.CUIAgencia = "A2222";
                op.RazSocAgencia = "Agencia A2";
                op.CUIAnunciante = "B2222";
                op.RazSocAnunciante = "Anunciante B2";
                op.Periodo = 202109;
                op.Sennal = "LN+";
                op.NroOP = "7000006003";
                op.NroOrden = "1";
                op.IdOPMMASS = 0;
                op.MarcaDescripcion = "Producto test 2";
                op.ResponsableOrden = "Sebastian Rolando";
                op.Comentarios = "prueba movimiento";
                op.FechaVencimiento = "2021-09-30";
                op.CompetitivoDescripcion = "VARIOS";
                op.TotalGralMenciones = 3;

                WSLaNacion.renglon ren1 = new WSLaNacion.renglon();
                WSLaNacion.renglon ren2 = new WSLaNacion.renglon();

                //ren1.NroDeRenglon = int.Parse(textBox23.Text);
                //ren1.ProgramaDescripcion = textBox22.Text;
                //ren1.HoraDesdeCompraBloqHorario = textBox21.Text;
                //ren1.HoraHastaCompraBloqHorario = textBox20.Text;
                //ren1.Duracion = int.Parse(textBox19.Text);
                //ren1.CodigoMaterial = textBox18.Text;
                //ren1.TemaMaterialusar = textBox17.Text;
                //ren1.TipoPublicidad = textBox16.Text;
                //ren1.PrecioSegundo = decimal.Parse(textBox28.Text);

                //ren2.NroDeRenglon = int.Parse(textBox43.Text);
                //ren2.ProgramaDescripcion = textBox42.Text;
                //ren2.HoraDesdeCompraBloqHorario = textBox41.Text;
                //ren2.HoraHastaCompraBloqHorario = textBox40.Text;
                //ren2.Duracion = int.Parse(textBox39.Text);
                //ren2.CodigoMaterial = textBox38.Text;
                //ren2.TemaMaterialusar = textBox37.Text;
                //ren2.TipoPublicidad = textBox36.Text;
                //ren2.PrecioSegundo = decimal.Parse(textBox35.Text);

                ren1.NroDeRenglon = 1;
                ren1.ProgramaDescripcion = "Caminos a la Escuela";
                ren1.HoraDesdeCompraBloqHorario = "13:00:00";
                ren1.HoraHastaCompraBloqHorario = "18:00:00";
                ren1.Duracion = 15;
                ren1.CodigoMaterial = "1A";
                ren1.TemaMaterialusar = "M1";
                ren1.TipoPublicidad = "Tanda";
                ren1.PrecioSegundo = 1500;

                ren2.NroDeRenglon = 2;
                ren2.ProgramaDescripcion = "Caminos a la Escuela";
                ren2.HoraDesdeCompraBloqHorario = "19:00:00";
                ren2.HoraHastaCompraBloqHorario = "20:30:00";
                ren2.Duracion = 35;
                ren2.CodigoMaterial = "qwerty2";
                ren2.TemaMaterialusar = "Tema Prueba relacion 1";
                ren2.TipoPublicidad = "Tanda";
                ren2.PrecioSegundo = 1800;

                WSLaNacion.mencion men1 = new WSLaNacion.mencion();
                WSLaNacion.mencion men2 = new WSLaNacion.mencion();
                WSLaNacion.mencion men3 = new WSLaNacion.mencion();

                //men1.Ubicacion = textBox26.Text;
                //men1.DiaDEEmision = textBox25.Text;
                //men1.TotalMenciones = int.Parse(textBox24.Text);

                //men2.Ubicacion = textBox31.Text;
                //men2.DiaDEEmision = textBox30.Text;
                //men2.TotalMenciones = int.Parse(textBox29.Text);

                //men3.Ubicacion = textBox34.Text;
                //men3.DiaDEEmision = textBox33.Text;
                //men3.TotalMenciones = int.Parse(textBox32.Text);

                men1.Ubicacion = "COL";
                men1.DiaDEEmision = "2021-09-22";
                men1.TotalMenciones = 1;
                men1.UbicacionManualOrden = 0;

                //men2.Ubicacion = "COL";
                //men2.DiaDEEmision = "2021-07-05";
                //men2.TotalMenciones = 2;
                //men2.UbicacionManualOrden = 0;

                men3.Ubicacion = "CAB";
                men3.DiaDEEmision = "2021-09-22";
                men3.TotalMenciones = 2;
                men3.UbicacionManualOrden = 0;

                ren1.Menciones = new WSLaNacion.ArrayOfMencion();
                ren2.Menciones = new WSLaNacion.ArrayOfMencion();

                ren1.Menciones.Add(men1);
                //ren1.Menciones.Add(men2);
                ren2.Menciones.Add(men3);

                op.Renglones = new WSLaNacion.ArrayOfRenglon();

                op.Renglones.Add(ren1);
                op.Renglones.Add(ren2);



                var respuesta = client.addOrden(op);

                textBox44.Text = respuesta.Estado;
                textBox45.Text = respuesta.Descripcion;
                textBox46.Text = respuesta.Id.ToString();
            } 
        }
    }
}

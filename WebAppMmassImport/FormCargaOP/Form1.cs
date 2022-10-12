using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                op.CUIAgencia = "DIRECTO";
                op.RazSocAgencia = "DIRECTO";
                op.CUIAnunciante = "A36077";
                op.RazSocAnunciante = "GRANGY 'S";
                op.Periodo = 202110;
                op.Sennal = "LN+";
                op.NroOP = "7000010479";
                op.NroOrden = "20.10.21 - 4";
                op.IdOPMMASS = 0;
                op.MarcaDescripcion = "Renault Verano";
                op.ResponsableOrden = "Valeria Duarte";
                op.Comentarios = "prueba apostrofe 1";
                op.FechaVencimiento = "2021-10-29";
                op.CompetitivoDescripcion = "INDUSTRIA AUTOMOTRIZ";
                op.TotalGralMenciones = 4;

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
                ren1.ProgramaDescripcion = "EL NOTICIERO";
                ren1.HoraDesdeCompraBloqHorario = "02:00:00";
                ren1.HoraHastaCompraBloqHorario = "03:59:59";
                ren1.Duracion = 15;
                ren1.CodigoMaterial = "13354";
                ren1.TemaMaterialusar = "A_13354_CASO DE PRUEBA _AUTOMOTRIZ_15";
                ren1.TipoPublicidad = "Tanda";
                ren1.PrecioSegundo = 180;

                ren2.NroDeRenglon = 2;
                ren2.ProgramaDescripcion = "HORA 17";
                ren2.HoraDesdeCompraBloqHorario = "17:00:00";
                ren2.HoraHastaCompraBloqHorario = "18:00:00";
                ren2.Duracion = 15;
                ren2.CodigoMaterial = "M2";
                ren2.TemaMaterialusar = "Tema Prueba error mat";
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

                men1.Ubicacion = "";
                men1.DiaDEEmision = "2021-10-21";
                men1.TotalMenciones = 2;
                men1.UbicacionManualOrden = 0;

                men2.Ubicacion = "";
                men2.DiaDEEmision = "2021-10-21";
                men2.TotalMenciones = 1;
                men2.UbicacionManualOrden = 0;

                men3.Ubicacion = "";
                men3.DiaDEEmision = "2021-10-26";
                men3.TotalMenciones = 1;
                men3.UbicacionManualOrden = 0;

                ren1.Menciones = new WSLaNacion.ArrayOfMencion();
                ren2.Menciones = new WSLaNacion.ArrayOfMencion();

                ren1.Menciones.Add(men1);
                //ren2.Menciones.Add(men2);
                //ren2.Menciones.Add(men3);

                op.Renglones = new WSLaNacion.ArrayOfRenglon();

                //op.Renglones.Add(ren1);
                op.Renglones.Add(ren2);



                var respuesta = client.addOrden(op);

                textBox44.Text = respuesta.Estado;
                textBox45.Text = respuesta.Descripcion;
                textBox46.Text = respuesta.Id.ToString();
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (WSLaNacion.wsimportSoapClient client = new WSLaNacion.wsimportSoapClient())
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
                op.CUIAgencia = "A05370088";
                op.RazSocAgencia = "FORMATOS NO TRADICIONALES S.A.";
                op.CUIAnunciante = "A05367604";
                op.RazSocAnunciante = "NINGBO SA";
                op.Periodo = 202210;
                op.Sennal = "LN+";
                op.NroOP = "7000014733";
                op.NroOrden = "0006_2022";
                op.IdOPMMASS = 8109;
                op.MarcaDescripcion = "SAPHIRUS";
                op.ResponsableOrden = "Silvia Malloggi";
                op.Comentarios = "prueba orden no guarda menciones 1 upd 1";
                op.FechaVencimiento = "2022-10-31";
                op.CompetitivoDescripcion = "CONSUMO MASIVO ; HIGIENE ; LIMPIEZA";
                op.TotalGralMenciones = 12;

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
                ren1.ProgramaDescripcion = "";
                ren1.HoraDesdeCompraBloqHorario = "18:00:00";
                ren1.HoraHastaCompraBloqHorario = "00:00:00";
                ren1.Duracion = 15;
                ren1.CodigoMaterial = "19649";
                ren1.TemaMaterialusar = "A_19649_SAPHIRUS_Saphirus Bailar_15";
                ren1.TipoPublicidad = "Tanda";
                ren1.PrecioSegundo = 2171.43;


                ren2.NroDeRenglon = 2;
                ren2.ProgramaDescripcion = "+REALIDAD";
                ren2.HoraDesdeCompraBloqHorario = "20:10:00";
                ren2.HoraHastaCompraBloqHorario = "20:30:00";
                ren2.Duracion = 5;
                ren2.CodigoMaterial = "13848";
                ren2.TemaMaterialusar = "A_13848_MMAS-251-1140_Mat1_12";
                ren2.TipoPublicidad = "Tanda";
                ren2.PrecioSegundo = 20;

                WSLaNacion.mencion men1 = new WSLaNacion.mencion();
                WSLaNacion.mencion men2 = new WSLaNacion.mencion();
                WSLaNacion.mencion men3 = new WSLaNacion.mencion();
                WSLaNacion.mencion men4 = new WSLaNacion.mencion();
                WSLaNacion.mencion men5 = new WSLaNacion.mencion();
                WSLaNacion.mencion men6 = new WSLaNacion.mencion();
                WSLaNacion.mencion men7 = new WSLaNacion.mencion();
                WSLaNacion.mencion men8 = new WSLaNacion.mencion();
                WSLaNacion.mencion men9 = new WSLaNacion.mencion();
                WSLaNacion.mencion men10 = new WSLaNacion.mencion();
                WSLaNacion.mencion men11 = new WSLaNacion.mencion();
                WSLaNacion.mencion men12 = new WSLaNacion.mencion();

                //men1.Ubicacion = textBox26.Text;
                //men1.DiaDEEmision = textBox25.Text;
                //men1.TotalMenciones = int.Parse(textBox24.Text);

                //men2.Ubicacion = textBox31.Text;
                //men2.DiaDEEmision = textBox30.Text;
                //men2.TotalMenciones = int.Parse(textBox29.Text);

                //men3.Ubicacion = textBox34.Text;
                //men3.DiaDEEmision = textBox33.Text;
                //men3.TotalMenciones = int.Parse(textBox32.Text);


                men1.Ubicacion = "";
                men1.DiaDEEmision = "2022-10-03";
                men1.TotalMenciones = 1;
                men1.UbicacionManualOrden = 0;
                men1.IdAvisoNotables = "1203105232";

                men2.Ubicacion = "";
                men2.DiaDEEmision = "2022-10-05";
                men2.TotalMenciones = 1;
                men2.UbicacionManualOrden = 0;
                men2.IdAvisoNotables = "1205105214";

                men3.Ubicacion = "";
                men3.DiaDEEmision = "2022-10-07";
                men3.TotalMenciones = 1;
                men3.UbicacionManualOrden = 0;
                men3.IdAvisoNotables = "1207105162";

                men4.Ubicacion = "";
                men4.DiaDEEmision = "2022-10-10";
                men4.TotalMenciones = 1;
                men4.UbicacionManualOrden = 0;
                men4.IdAvisoNotables = "1210105197";

                men5.Ubicacion = "";
                men5.DiaDEEmision = "2022-10-12";
                men5.TotalMenciones = 1;
                men5.UbicacionManualOrden = 0;
                men5.IdAvisoNotables = "1212105189";

                men6.Ubicacion = "";
                men6.DiaDEEmision = "2022-10-14";
                men6.TotalMenciones = 1;
                men6.UbicacionManualOrden = 0;
                men6.IdAvisoNotables = "1214105149";

                men7.Ubicacion = "";
                men7.DiaDEEmision = "2022-10-17";
                men7.TotalMenciones = 1;
                men7.UbicacionManualOrden = 0;
                men7.IdAvisoNotables = "1217105158";

                men8.Ubicacion = "";
                men8.DiaDEEmision = "2022-10-19";
                men8.TotalMenciones = 1;
                men8.UbicacionManualOrden = 0;
                men8.IdAvisoNotables = "1219105132";

                men9.Ubicacion = "";
                men9.DiaDEEmision = "2022-10-21";
                men9.TotalMenciones = 1;
                men9.UbicacionManualOrden = 0;
                men9.IdAvisoNotables = "1221105106";

                men10.Ubicacion = "";
                men10.DiaDEEmision = "2022-10-24";
                men10.TotalMenciones = 1;
                men10.UbicacionManualOrden = 0;
                men10.IdAvisoNotables = "1224105128";

                men11.Ubicacion = "";
                men11.DiaDEEmision = "2022-10-26";
                men11.TotalMenciones = 1;
                men11.UbicacionManualOrden = 0;
                men11.IdAvisoNotables = "1226105106";

                men12.Ubicacion = "";
                men12.DiaDEEmision = "2022-10-28";
                men12.TotalMenciones = 1;
                men12.UbicacionManualOrden = 0;
                men12.IdAvisoNotables = "1228105089";

                ren1.Menciones = new WSLaNacion.ArrayOfMencion();
                ren2.Menciones = new WSLaNacion.ArrayOfMencion();

                ren1.Menciones.Add(men1);
                ren1.Menciones.Add(men2);
                ren1.Menciones.Add(men3);
                ren1.Menciones.Add(men4);
                ren1.Menciones.Add(men5);
                ren1.Menciones.Add(men6);
                ren1.Menciones.Add(men7);
                ren1.Menciones.Add(men8);
                ren1.Menciones.Add(men9);
                ren1.Menciones.Add(men10);
                ren1.Menciones.Add(men11);
                ren1.Menciones.Add(men12);

                op.Renglones = new WSLaNacion.ArrayOfRenglon();

                op.Renglones.Add(ren1);
                //op.Renglones.Add(ren2);

                var respuesta = client.addOrden(op);

                textBox47.Text = respuesta.Estado;
                textBox48.Text = respuesta.Descripcion;
                textBox46.Text = respuesta.Id.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (WSLaNacion.wsimportSoapClient client = new WSLaNacion.wsimportSoapClient())
            {
                client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 00);

                WSLaNacion.orden_publicitaria op = new WSLaNacion.orden_publicitaria();

                string fechaDesde = "2022-09-01";
                string fechaHasta = "2022-09-20";

                var respuesta = client.consultarMenciones(fechaDesde, fechaHasta);

                textBox50.Text = respuesta.Estado;
                textBox49.Text = respuesta.Descripcion;
            }
        }
    }
}

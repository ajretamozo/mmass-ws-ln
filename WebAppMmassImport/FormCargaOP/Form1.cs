﻿using System;
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
                op.CUIAgencia = "DIRECTO";
                op.RazSocAgencia = "DIRECTO";
                op.CUIAnunciante = "A25576";
                op.RazSocAnunciante = "SA LA NACION";
                op.Periodo = 202208;
                op.Sennal = "LN+";
                op.NroOP = "7000010870";
                op.NroOrden = "2022-8521";
                op.IdOPMMASS = 7640;
                op.MarcaDescripcion = "LAS MARIAS";
                op.ResponsableOrden = "Sebastian Rolando";
                op.Comentarios = "prueba log auditoria 5";
                op.FechaVencimiento = "2022-08-31";
                op.CompetitivoDescripcion = "VARIOS";
                op.TotalGralMenciones = 5;
                op.XMLCompleto = "{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"COMUNIDAD DE NEGOCIOS\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:29:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-16\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-22\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-30\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-15\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-17\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-23\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-29\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A04102596\",\"RazSocAgencia\":\"DATOLA CHRISTIAN OSCAR\",\"CUIAnunciante\":\"A04062165\",\"RazSocAnunciante\":\"TEZANOS PINTO, CARIDE FITTE y Asoc SRL\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012527\",\"NroOrden\":\"01190510/22\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"AUREN \",\"CompetitivoDescripcion\":\"SERVICIOS EMPRESARIALES & PERSONALES\",\"ResponsableOrden\":\"Silvia Malloggi\",\"Comentarios\":\"\",\"TotalGralMenciones\":24,\"FechaVencimiento\":\"2022-03-30\"}{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-11\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"EL DIARIO DE LEUCO\",\"HoraDesdeCompraBloqHorario\":\"21:00:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-11\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"\",\"HoraDesdeCompraBloqHorario\":\"10:00:00\",\"HoraHastaCompraBloqHorario\":\"13:00:00\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":6,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-11\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":7,\"ProgramaDescripcion\":\"\",\"HoraDesdeCompraBloqHorario\":\"21:00:00\",\"HoraHastaCompraBloqHorario\":\"22:00:00\",\"Duracion\":18,\"PrecioSegundo\":0.0,\"CodigoMaterial\":\"16018\",\"TemaMaterialusar\":\"A_16018_GARGALETAS_GARGALETAS_18\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A00101261\",\"RazSocAgencia\":\"ESTUDIO ALPHA RH PEPE Y ASOC\",\"CUIAnunciante\":\"A03319714\",\"RazSocAnunciante\":\"LABORATORIOS MONSERRAT Y ECLAIR S.A\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012528\",\"NroOrden\":\"10945\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"GARGALETAS\",\"CompetitivoDescripcion\":\"LABORATORIOS\",\"ResponsableOrden\":\"Maria Soledad Fernandez\",\"Comentarios\":\"\",\"TotalGralMenciones\":12,\"FechaVencimiento\":\"2022-03-13\"}{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"COMUNIDAD DE NEGOCIOS\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:29:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-16\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-22\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-30\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-15\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-17\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-23\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-29\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A04102596\",\"RazSocAgencia\":\"DATOLA CHRISTIAN OSCAR\",\"CUIAnunciante\":\"A04062165\",\"RazSocAnunciante\":\"TEZANOS PINTO, CARIDE FITTE y Asoc SRL\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012527\",\"NroOrden\":\"01190510/22\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"AUREN \",\"CompetitivoDescripcion\":\"SERVICIOS EMPRESARIALES & PERSONALES\",\"ResponsableOrden\":\"Silvia Malloggi\",\"Comentarios\":\"\",\"TotalGralMenciones\":24,\"FechaVencimiento\":\"2022-03-30\"}{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"COMUNIDAD DE NEGOCIOS\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:29:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-16\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-22\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-30\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-15\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-17\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-23\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-29\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A04102596\",\"RazSocAgencia\":\"DATOLA CHRISTIAN OSCAR\",\"CUIAnunciante\":\"A04062165\",\"RazSocAnunciante\":\"TEZANOS PINTO, CARIDE FITTE y Asoc SRL\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012527\",\"NroOrden\":\"01190510/22\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"AUREN \",\"CompetitivoDescripcion\":\"SERVICIOS EMPRESARIALES & PERSONALES\",\"ResponsableOrden\":\"Silvia Malloggi\",\"Comentarios\":\"\",\"TotalGralMenciones\":24,\"FechaVencimiento\":\"2022-03-30\"}{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"COMUNIDAD DE NEGOCIOS\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:29:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-16\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-22\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-30\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-15\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-17\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-23\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-29\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A04102596\",\"RazSocAgencia\":\"DATOLA CHRISTIAN OSCAR\",\"CUIAnunciante\":\"A04062165\",\"RazSocAnunciante\":\"TEZANOS PINTO, CARIDE FITTE y Asoc SRL\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012527\",\"NroOrden\":\"01190510/22\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"AUREN \",\"CompetitivoDescripcion\":\"SERVICIOS EMPRESARIALES & PERSONALES\",\"ResponsableOrden\":\"Silvia Malloggi\",\"Comentarios\":\"\",\"TotalGralMenciones\":24,\"FechaVencimiento\":\"2022-03-30\"}{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"COMUNIDAD DE NEGOCIOS\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:29:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-16\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-22\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-30\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-15\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-17\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-23\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-29\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A04102596\",\"RazSocAgencia\":\"DATOLA CHRISTIAN OSCAR\",\"CUIAnunciante\":\"A04062165\",\"RazSocAnunciante\":\"TEZANOS PINTO, CARIDE FITTE y Asoc SRL\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012527\",\"NroOrden\":\"01190510/22\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"AUREN \",\"CompetitivoDescripcion\":\"SERVICIOS EMPRESARIALES & PERSONALES\",\"ResponsableOrden\":\"Silvia Malloggi\",\"Comentarios\":\"\",\"TotalGralMenciones\":24,\"FechaVencimiento\":\"2022-03-30\"}{\"Renglones\":[{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":1,\"ProgramaDescripcion\":\"ODISEA\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":2,\"ProgramaDescripcion\":\"COMUNIDAD DE NEGOCIOS\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"23:29:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-07\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-09\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-14\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-16\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-22\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-28\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-30\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":3,\"ProgramaDescripcion\":\"+REALIDAD\",\"HoraDesdeCompraBloqHorario\":\"20:00:00\",\"HoraHastaCompraBloqHorario\":\"20:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-08\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-10\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-15\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-17\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-21\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-23\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-29\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":4,\"ProgramaDescripcion\":\"+VOCES\",\"HoraDesdeCompraBloqHorario\":\"22:00:00\",\"HoraHastaCompraBloqHorario\":\"22:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"},{\"Menciones\":[{\"DiaDEEmision\":\"2022-03-13\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-20\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1},{\"DiaDEEmision\":\"2022-03-27\",\"Ubicacion\":\"\",\"UbicacionManualOrden\":0,\"TotalMenciones\":1}],\"NroDeRenglon\":5,\"ProgramaDescripcion\":\"LA CORNISA\",\"HoraDesdeCompraBloqHorario\":\"20:30:00\",\"HoraHastaCompraBloqHorario\":\"21:59:59\",\"Duracion\":10,\"PrecioSegundo\":1112.0000,\"CodigoMaterial\":\"16017\",\"TemaMaterialusar\":\"A_16017_AUREN_AUREN_10\",\"TipoPublicidad\":\"Tanda\"}],\"Empresa\":\"SAPU\",\"Estado\":3,\"CUIAgencia\":\"A04102596\",\"RazSocAgencia\":\"DATOLA CHRISTIAN OSCAR\",\"CUIAnunciante\":\"A04062165\",\"RazSocAnunciante\":\"TEZANOS PINTO, CARIDE FITTE y Asoc SRL\",\"Periodo\":202203,\"Sennal\":\"LN+\",\"NroOP\":\"7000012527\",\"NroOrden\":\"01190510/22\",\"IdOPMMASS\":0,\"MarcaDescripcion\":\"AUREN \",\"CompetitivoDescripcion\":\"SERVICIOS EMPRESARIALES & PERSONALES\",\"ResponsableOrden\":\"Silvia Malloggi\",\"Comentarios\":\"\",\"TotalGralMenciones\":24,\"FechaVencimiento\":\"2022-03-30\"}";

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
                ren1.HoraDesdeCompraBloqHorario = "14:00:00";
                ren1.HoraHastaCompraBloqHorario = "14:59:59";
                ren1.Duracion = 1;
                ren1.CodigoMaterial = "1";
                ren1.TemaMaterialusar = "A_18479_LAS MARIAS_Las Marias_1";
                ren1.TipoPublicidad = "Auspicio";
                ren1.PrecioSegundo = 40000;


                ren2.NroDeRenglon = 2;
                ren2.ProgramaDescripcion = "+INFO DE LA TARDE";
                ren2.HoraDesdeCompraBloqHorario = "15:00:00";
                ren2.HoraHastaCompraBloqHorario = "16:59:59";
                ren2.Duracion = 12;
                ren2.CodigoMaterial = "13848";
                ren2.TemaMaterialusar = "A_13848_MMAS-251-1140_Mat1_12";
                ren2.TipoPublicidad = "Tanda";
                ren2.PrecioSegundo = 0.0;

                WSLaNacion.mencion men1 = new WSLaNacion.mencion();
                WSLaNacion.mencion men2 = new WSLaNacion.mencion();
                WSLaNacion.mencion men3 = new WSLaNacion.mencion();
                WSLaNacion.mencion men4 = new WSLaNacion.mencion();
                //WSLaNacion.mencion men5 = new WSLaNacion.mencion();
                //WSLaNacion.mencion men6 = new WSLaNacion.mencion();
                //WSLaNacion.mencion men7 = new WSLaNacion.mencion();
                //WSLaNacion.mencion men8 = new WSLaNacion.mencion();
                //WSLaNacion.mencion men9 = new WSLaNacion.mencion();
                //WSLaNacion.mencion men10 = new WSLaNacion.mencion();

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
                men1.DiaDEEmision = "2022-08-07";
                men1.TotalMenciones = 1;
                men1.UbicacionManualOrden = 0;
                men1.IdAvisoNotables = "1234";

                men2.Ubicacion = "";
                men2.DiaDEEmision = "2022-08-14";
                men2.TotalMenciones = 1;
                men2.UbicacionManualOrden = 0;
                men2.IdAvisoNotables = "4567";

                men3.Ubicacion = "";
                men3.DiaDEEmision = "2022-08-21";
                men3.TotalMenciones = 1;
                men3.UbicacionManualOrden = 0;
                men3.IdAvisoNotables = "7890";

                men4.Ubicacion = "";
                men4.DiaDEEmision = "2022-08-28";
                men4.TotalMenciones = 1;
                men4.UbicacionManualOrden = 0;
                men4.IdAvisoNotables = "102";

                //men5.Ubicacion = "";
                //men5.DiaDEEmision = "2021-11-15";
                //men5.TotalMenciones = 1;
                //men5.UbicacionManualOrden = 0;

                //men6.Ubicacion = "";
                //men6.DiaDEEmision = "2021-11-16";
                //men6.TotalMenciones = 1;
                //men6.UbicacionManualOrden = 0;


                //men7.Ubicacion = "";
                //men7.DiaDEEmision = "2021-11-26";
                //men7.TotalMenciones = 1;
                //men7.UbicacionManualOrden = 0;

                //men8.Ubicacion = "";
                //men8.DiaDEEmision = "2021-11-24";
                //men8.TotalMenciones = 1;
                //men8.UbicacionManualOrden = 0;

                //men9.Ubicacion = "";
                //men9.DiaDEEmision = "2021-12-29";
                //men9.TotalMenciones = 1;
                //men9.UbicacionManualOrden = 0;

                //men10.Ubicacion = "";
                //men10.DiaDEEmision = "2021-12-06";
                //men10.TotalMenciones = 1;
                //men10.UbicacionManualOrden = 0;


                ren1.Menciones = new WSLaNacion.ArrayOfMencion();
                ren2.Menciones = new WSLaNacion.ArrayOfMencion();

                ren1.Menciones.Add(men1);
                ren1.Menciones.Add(men2);
                ren1.Menciones.Add(men3);
                ren1.Menciones.Add(men4);
                //ren1.Menciones.Add(men5);
                //ren1.Menciones.Add(men6);
                //ren2.Menciones.Add(men7);
                //ren2.Menciones.Add(men3);
                //ren2.Menciones.Add(men4);
                //ren2.Menciones.Add(men10);

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

                string fechaDesde = "2022-03-14";
                string fechaHasta = "2022-03-16";

                var respuesta = client.consultarMenciones(fechaDesde, fechaHasta);

                textBox50.Text = respuesta.Estado;
                textBox49.Text = respuesta.Descripcion;
            }
        }
    }
}

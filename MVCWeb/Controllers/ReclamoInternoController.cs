using BussinesLogic.Controllers;
using BussinesLogic.Logic;
using CommonSolution.Constantes;
using CommonSolution.DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInterna.Helpers;

namespace WebInterna.Controllers
{
    [UserAuthentication]
    public class ReclamoInternoController : Controller
    {
        public ActionResult Listar()
        {
            LReclamoController reclamoController = new LReclamoController();
            LZonaController zonaController = new LZonaController();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            List<DTO_Reclamo> colDataModel = reclamoController.ListarReclamos();
            foreach (DTO_Reclamo item in colDataModel)
            {
                item.tipoReclamo = reclamoController.tipoReclamoById((int)item.idTipoReclamo);
                if (item.numeroZona != null)
                {
                    item.zona = zonaController.ZonaByNumero((int)item.numeroZona);
                }
                if (item.numeroCuadrilla != null)
                {
                    item.cuadrilla = cuadrillaController.CuadrillaByNumero((int)item.numeroCuadrilla);
                }   
            }
            colDataModel = colDataModel.OrderByDescending(g => g.situacion).ToList();
            return View(colDataModel);
        }

        [HttpPost]
        public ActionResult Buscar(string estado)
        {
            LReclamoController reclamoController = new LReclamoController();
            List<DTO_Reclamo> lista = new List<DTO_Reclamo>();
            if (!string.IsNullOrEmpty(estado))
            {
                lista = reclamoController.ListByEstado(estado);
            }
            else
            {
                lista = reclamoController.ListarReclamos();
            }

            foreach (DTO_Reclamo item in lista)
            {
                LZonaController zonaController = new LZonaController();
                LCuadrillaController cuadrillaController = new LCuadrillaController();
                item.tipoReclamo = reclamoController.tipoReclamoById((int)item.idTipoReclamo);
                if (item.numeroZona != null)
                {
                    item.zona = zonaController.ZonaByNumero((int)item.numeroZona);
                }
                if (item.numeroCuadrilla != null)
                {
                    item.cuadrilla = cuadrillaController.CuadrillaByNumero((int)item.numeroCuadrilla);
                }
            }

            return PartialView("_ListaReclamos", lista);
        }

        public ActionResult Historial(int numero)
        {
            LLogReclamoController logReclamoController = new LLogReclamoController();
            List<DTO_LogReclamo> dto = logReclamoController.GetLogReclamosByNum(numero);
            return View(dto);
        }
        public ActionResult EditarEstado(int numeroReclamo)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numeroReclamo);
            ViewBag.siguiente = reclamoController.SiguienteEstado(dto);
            return View(dto);
        }
        public ActionResult EditarEstadoSubmit(DTO_Reclamo dto, int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dtoAux = reclamoController.ReclamoByNumero(numero);
            dtoAux.fchaHora = DateTime.Now;
            dtoAux.comentarioFuncionario = dto.comentarioFuncionario;
            dtoAux.estado = reclamoController.SiguienteEstado(dtoAux);
            string nombreUsuario = Session["nombreUsuario"].ToString();
            dtoAux.nombreFuncionario = nombreUsuario;
            reclamoController.ModificarEstado(dtoAux);
            return RedirectToAction("Listar");
        }

        public ActionResult Desestimar(int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numero);
            return View(dto);
        }
        public ActionResult DesestimarSubmit(DTO_Reclamo dto)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dtoAux = reclamoController.ReclamoByNumero(dto.numero);
            dtoAux.comentarioFuncionario = dto.comentarioFuncionario;
            dtoAux.nombreFuncionario = Session["nombreUsuario"].ToString();
            dtoAux.fchaHora = DateTime.Now;
            dtoAux.situacion = CGeneral.INACTIVO;
            dtoAux.estado = "DESESTIMADO";
            reclamoController.DesestimarReclamo(dtoAux);
            return RedirectToAction("Listar");
        }

        public ActionResult AsignarCuadrilla(int numeroReclamo)
        {
            LReclamoController reclamoController = new LReclamoController();
            DTO_Reclamo dtoAux = reclamoController.ReclamoByNumero(numeroReclamo);
            int? numeroCuadrilla = reclamoController.FraccionadorDeCuadrillas(dtoAux.numeroZona);
            if (numeroCuadrilla != null)
            {
                reclamoController.ModificarCuadrilla(dtoAux.numero, numeroCuadrilla);
                return RedirectToAction("Listar");
            }
            else
            {
                ModelState.AddModelError("MsgReport", "La zona no tiene cuadrillas asignadas");
                LZonaController zonaController = new LZonaController();
                LCuadrillaController cuadrillaController = new LCuadrillaController();
                List<DTO_Reclamo> colDataModel = reclamoController.ListarReclamos();
                foreach (DTO_Reclamo item in colDataModel)
                {
                    item.tipoReclamo = reclamoController.tipoReclamoById((int)item.idTipoReclamo);
                    if (item.numeroZona != null)
                    {
                        item.zona = zonaController.ZonaByNumero((int)item.numeroZona);
                    }
                    if (item.numeroCuadrilla != null)
                    {
                        item.cuadrilla = cuadrillaController.CuadrillaByNumero((int)item.numeroCuadrilla);
                    }
                }
                colDataModel = colDataModel.OrderByDescending(g => g.situacion).ToList();
                return View("Listar", colDataModel);
            }
        }
        public ActionResult ReportePdf(int numero)
        {
            LReclamoController reclamoController = new LReclamoController();
            LZonaController zonaController = new LZonaController();
            LCuadrillaController cuadrillaController = new LCuadrillaController();
            DTO_Reclamo dto = reclamoController.ReclamoByNumero(numero);
            dto.tipoReclamo = reclamoController.tipoReclamoById((int)dto.idTipoReclamo);
            dto.zona = zonaController.ZonaByNumero((int)dto.numeroZona);
            if (dto.numeroCuadrilla != null)
            {
                dto.cuadrilla = cuadrillaController.CuadrillaByNumero((int)dto.numeroCuadrilla);
            }
            byte[] abytes = ToPdf(dto);
            return File(abytes, "application/pdf");
        }

        public byte[] ToPdf(DTO_Reclamo dto)
        {
            Document documento = new Document(PageSize.A4, 40f, 40f, 20f, 20f);
            PdfPTable pdfTable = new PdfPTable(2);
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            Font fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter.GetInstance(documento, memoryStream);
            documento.Open();
            pdfTable.SetWidths(new float[] { 60f, 100f });

            #region Header
            Font fontStyleHeader = FontFactory.GetFont("Tahoma", 20f, 1);
            PdfPCell pdfPCellHeader = new PdfPCell(new Phrase("Reporte PDF - Reclamo Número: " + dto.numero, fontStyleHeader));
            pdfPCellHeader.Colspan = 3;
            pdfPCellHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellHeader.Border = 0;
            pdfPCellHeader.PaddingTop = 20;
            pdfPCellHeader.BackgroundColor = BaseColor.WHITE;
            pdfPCellHeader.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfPCellHeader);

            Font fontStyleSubHeader = FontFactory.GetFont("Tahoma", 11f, 1);
            PdfPCell pdfPCellSubHeader = new PdfPCell(new Phrase("Generado a la hora: " + DateTime.Now.ToString(), fontStyleSubHeader));
            pdfPCellSubHeader.Colspan = 3;
            pdfPCellSubHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellSubHeader.Border = 0;
            pdfPCellSubHeader.PaddingBottom = 30f;
            pdfPCellSubHeader.BackgroundColor = BaseColor.WHITE;
            pdfPCellSubHeader.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfPCellSubHeader);
            pdfTable.CompleteRow();
            #endregion

            #region Body
            Font fontStyleBody = FontFactory.GetFont("Tahoma", 12f, 1);
            PdfPCell pdfPCellBody1 = new PdfPCell(new Phrase("Número de reclamo", fontStyleBody));
            pdfPCellBody1.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody1.Padding = 10f;
            pdfPCellBody1.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody1.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody1);

            PdfPCell pdfPCellTable1 = new PdfPCell(new Phrase(dto.numero.ToString(), fontStyleBody));
            pdfPCellTable1.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable1.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable1.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable1);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody2 = new PdfPCell(new Phrase("Fecha y Hora - Último cambio", fontStyleBody));
            pdfPCellBody2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody2.Padding = 10f;
            pdfPCellBody2.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody2.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody2);

            PdfPCell pdfPCellTable2 = new PdfPCell(new Phrase(dto.fchaHora.ToString(), fontStyleBody));
            pdfPCellTable2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable2.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable2.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable2);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody3 = new PdfPCell(new Phrase("Estado", fontStyleBody));
            pdfPCellBody3.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody3.Padding = 10f;
            pdfPCellBody3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody3.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody3);

            PdfPCell pdfPCellTable3 = new PdfPCell(new Phrase(dto.estado, fontStyleBody));
            pdfPCellTable3.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable3.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable3);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody4 = new PdfPCell(new Phrase("Tipo de reclamo", fontStyleBody));
            pdfPCellBody4.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody4.Padding = 10f;
            pdfPCellBody4.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody4.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody4);

            PdfPCell pdfPCellTable4 = new PdfPCell(new Phrase(dto.tipoReclamo.nombre.ToString(), fontStyleBody));
            pdfPCellTable4.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable4.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable4.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable4);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody5 = new PdfPCell(new Phrase("Id tipo de reclamo", fontStyleBody));
            pdfPCellBody5.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody5.Padding = 10f;
            pdfPCellBody5.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody5.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody5);

            PdfPCell pdfPCellTable5 = new PdfPCell(new Phrase(dto.tipoReclamo.id.ToString(), fontStyleBody));
            pdfPCellTable5.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable5.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable5.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable5);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody6 = new PdfPCell(new Phrase("Descripción tipo de reclamo", fontStyleBody));
            pdfPCellBody6.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody6.Padding = 10f;
            pdfPCellBody6.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody6.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody6);

            PdfPCell pdfPCellTable6 = new PdfPCell(new Phrase(dto.tipoReclamo.descripcion.ToString(), fontStyleBody));
            pdfPCellTable6.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable6.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable6.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable6);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody7 = new PdfPCell(new Phrase("Zona", fontStyleBody));
            pdfPCellBody7.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody7.Padding = 10f;
            pdfPCellBody7.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody7.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody7);

            PdfPCell pdfPCellTable7 = new PdfPCell(new Phrase(dto.zona.nombre.ToString(), fontStyleBody));
            pdfPCellTable7.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable7.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable7.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable7);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody8 = new PdfPCell(new Phrase("Número zona", fontStyleBody));
            pdfPCellBody8.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody8.Padding = 10f;
            pdfPCellBody8.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody8.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody8);

            PdfPCell pdfPCellTable8 = new PdfPCell(new Phrase(dto.zona.numero.ToString(), fontStyleBody));
            pdfPCellTable8.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable8.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable8.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable8);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody9 = new PdfPCell(new Phrase("Cuadrilla", fontStyleBody));
            pdfPCellBody9.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody9.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody9.Padding = 10f;
            pdfPCellBody9.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody9);

            if (dto.cuadrilla != null)
            {
                PdfPCell pdfPCellTable9 = new PdfPCell(new Phrase(dto.cuadrilla.nombre.ToString(), fontStyleBody));
                pdfPCellTable9.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable9.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable9.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable9);
                pdfTable.CompleteRow();
            }
            else
            {
                PdfPCell pdfPCellTable9 = new PdfPCell(new Phrase("No asignada", fontStyleBody));
                pdfPCellTable9.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable9.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable9.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable9);
                pdfTable.CompleteRow(); ;
            }  

            PdfPCell pdfPCellBody10 = new PdfPCell(new Phrase("Cantidad de peones", fontStyleBody));
            pdfPCellBody10.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody10.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody10.Padding = 10f;
            pdfPCellBody10.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody10);

            if (dto.cuadrilla != null)
            {
                PdfPCell pdfPCellTable10 = new PdfPCell(new Phrase(dto.cuadrilla.cantidadPeones.ToString(), fontStyleBody));
                pdfPCellTable10.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable10.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable10.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable10);
                pdfTable.CompleteRow();
            }
            else
            {
                PdfPCell pdfPCellTable10 = new PdfPCell(new Phrase("-", fontStyleBody));
                pdfPCellTable10.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable10.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable10.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable10);
                pdfTable.CompleteRow();
            }

            PdfPCell pdfPCellBody11 = new PdfPCell(new Phrase("Comentarios del cliente", fontStyleBody));
            pdfPCellBody11.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody11.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody11.Padding = 10f;
            pdfPCellBody11.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody11);

            PdfPCell pdfPCellTable11 = new PdfPCell(new Phrase(dto.observacionesCiudadano, fontStyleBody));
            pdfPCellTable11.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellTable11.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellTable11.BackgroundColor = BaseColor.WHITE;
            pdfTable.AddCell(pdfPCellTable11);
            pdfTable.CompleteRow();

            PdfPCell pdfPCellBody12 = new PdfPCell(new Phrase("Funcionario encargado", fontStyleBody));
            pdfPCellBody12.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody12.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody12.Padding = 10f;
            pdfPCellBody12.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody12);

            if (dto.nombreFuncionario != null)
            {
                PdfPCell pdfPCellTable12 = new PdfPCell(new Phrase(dto.nombreFuncionario, fontStyleBody));
                pdfPCellTable12.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable12.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable12.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable12);
                pdfTable.CompleteRow();
            }
            else
            {
                PdfPCell pdfPCellTable12 = new PdfPCell(new Phrase("No asignado", fontStyleBody));
                pdfPCellTable12.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable12.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable12.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable12);
                pdfTable.CompleteRow();
            }
            
            PdfPCell pdfPCellBody13 = new PdfPCell(new Phrase("Último comentario del funcionario", fontStyleBody));
            pdfPCellBody13.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCellBody13.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCellBody13.Padding = 10f;
            pdfPCellBody13.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(pdfPCellBody13);

            if (dto.comentarioFuncionario != null)
            {
                PdfPCell pdfPCellTable13 = new PdfPCell(new Phrase(dto.comentarioFuncionario, fontStyleBody));
                pdfPCellTable13.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable13.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable13.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable13);
                pdfTable.CompleteRow();
            }
            else
            {
                PdfPCell pdfPCellTable13 = new PdfPCell(new Phrase("No asignado", fontStyleBody));
                pdfPCellTable13.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCellTable13.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCellTable13.BackgroundColor = BaseColor.WHITE;
                pdfTable.AddCell(pdfPCellTable13);
                pdfTable.CompleteRow();
            }
            #endregion

            string QRText = "Número de reclamo: " + dto.numero + "\nFecha/hora de último cambio: " + dto.fchaHora 
                + "\nEstado acutal: " + dto.estado + "\nId del tipo de reclamo: " + dto.idTipoReclamo + "\nNúmero de zona: "
                + dto.numeroZona;
            BarcodeQRCode barcodeQRCode = new BarcodeQRCode(QRText, 1000, 1000, null);
            Image barcodeQRCodeImage = barcodeQRCode.GetImage();
            barcodeQRCodeImage.ScaleAbsolute(200, 200);
            documento.Add(pdfTable);
            documento.Add(barcodeQRCodeImage);
            documento.Close();
            return memoryStream.ToArray();
        }
    }
}
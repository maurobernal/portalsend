﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using PortalSend.App_Data;
using PortalSend.App_Data.PORTALSEND;
using PortalSend.ExtensionMethods;

namespace PortalSend.Models
{
    public class Lotes_Models
    {
        private PortalSend_Entities _conexion = new PortalSend_Entities();
        public string Lote { get; set; }
        public int Cant { get; set; }
        
        public List<Lotes_Models> SelectLotes(DateTime _fechadesde, DateTime _fechahasta)
        {
            _fechadesde = _fechadesde.ChangeTime(0, 0, 0, 0);
            _fechahasta = _fechahasta.ChangeTime(23, 59, 0, 0);
            Lotes_Models L = new Lotes_Models();
            List<Lotes_Models> ListL = new List<Lotes_Models>();
            try
            {
                ListL = (
                    (from q in _conexion.Mensajes
                     where q.men_fecha >= _fechadesde && q.men_fecha <= _fechahasta
                     group q by q.men_lote into g
                     orderby g.Key descending

                     select new Lotes_Models()
                     {
                         Cant = g.Count(),
                         Lote = g.Key
                     }).ToList()

                        ); ;
                
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListL;

        }

       
    }
}
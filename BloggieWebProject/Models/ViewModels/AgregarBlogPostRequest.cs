﻿using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.ViewModels
{
    public class AgregarBlogPostRequest
    {
  
        public string Encabezado { get; set; }

        public string TituloPagina { get; set; }

        public string Contenido { get; set; }

        public string DescripcionCorta { get; set; }

        public string UrlImagenDestacada { get; set; }

        public string ManejadorUrl { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string Autor { get; set; }

        public bool Visible { get; set; }

    }
}

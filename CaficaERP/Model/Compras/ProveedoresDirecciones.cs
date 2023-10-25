﻿using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Compras
{
    public class ProveedoresDirecciones : BaseModel
    {
        public ProveedoresDirecciones()
        {
            this.Colonias = new Colonias();
            this.CodigosPostales = new CodigosPostales();
            this.Ciudades = new Ciudades();
            this.Municipios = new Municipios();
            this.Estados = new Estados();
            this.Paises = new Paises();
            
        }


        public long ProveedorId { get; set; }
        public string Calle { get; set; }
        public string NoInterior { get; set; }
        public string NoExterior { get; set; }
        public string Referencia { get; set; }
        public long ColoniaId { get; set; }
        public long CodigoPostalId { get; set; }
        public long CiudadId { get; set; }
        public long EstadoId { get; set; }
        public long PaisId { get; set; }
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<long> MunicipioId { get; set; }

        public virtual Ciudades Ciudades { get; set; }
        public virtual CodigosPostales CodigosPostales { get; set; }
        public virtual Colonias Colonias { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Municipios Municipios { get; set; }
        public virtual Paises Paises { get; set; }


        public override string Validar(string propiedad)
        {
            return null;
        }
    }
}

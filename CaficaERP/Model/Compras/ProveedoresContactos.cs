﻿using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaficaERP.Model.Compras
{
    public class ProveedoresContactos : BaseModel
    {

        public ProveedoresContactos()
        {
            this.Colonias = new Colonias();
            this.CodigosPostales = new CodigosPostales();
            this.Ciudades = new Ciudades();
            this.Municipios = new Municipios();
            this.Estados = new Estados();
            this.Paises = new Paises();

        }

        public long ProveedorId { get; set; }
        public string Identificador { get; set; }
        public string NombreCompleto { get; set; }
        public string Puesto { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Referencia { get; set; }
        public Nullable<long> ColoniaId { get; set; }
        public Nullable<long> CodigoPostalId { get; set; }
        public Nullable<long> CiudadId { get; set; }
        public Nullable<long> EstadoId { get; set; }
        public Nullable<long> PaisId { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
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
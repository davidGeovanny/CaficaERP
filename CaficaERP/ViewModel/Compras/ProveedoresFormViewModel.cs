using CaficaERP.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;
using System.Windows;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;
using CaficaERP.Model.Compras;

namespace CaficaERP.ViewModel.Compras
{
    [POCOViewModel]
    public class ProveedoresFormViewModel : FormularioViewModel<Proveedores>
    {
        public virtual ProveedoresDirecciones DireccionSeleccionado { get; set; }
    
        public virtual ProveedoresContactos ContactoSeleccionado { get; set; }


        public ProveedoresFormViewModel(object view, Proveedores item, string conexion) : base(view, item, conexion)
        {
           
        }

        public ProveedoresFormViewModel(object view) : base(view)
        {
            //Nuevo
            CamposEnabled = true;

            //IconCancelar = true;

            CargarSiNo();
            CargarGiros();
            CargarGruposProveedores();
            CargarMonedas();
            CargarCondicionesPago();

            CargarDirecciones();
            

           // CargarCodigosPostales();
      
            this.RaisePropertyChanged(x => x.Item);
        }
        public override void CargarItem()
        {
            try
            {
                //Nuevo
                CargarDirecciones();

                CamposEnabled = true;

                Item.CanValidate = true;

                base.CargarItem();
                Item.Errores();

                CargarSiNo();
                CargarGiros();
                CargarGruposProveedores();
                CargarMonedas();
                CargarCondicionesPago();

               


          
                DireccionSeleccionado = new ProveedoresDirecciones();

             
                ContactoSeleccionado = new ProveedoresContactos();

            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                     MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, DevExpress.Xpf.Core.FloatingMode.Popup);
            }
        }
        public void ValorCeldaCambioDireccion(CellValue celda)
        {
            if (celda != null)
            {
                if(celda.Property=="ColoniaId")
                {
                    ProveedoresDirecciones celdaactual = (ProveedoresDirecciones)celda.Row;
                    celdaactual.CanValidate = true;

                    if(celdaactual.ColoniaId!=0)
                    {
                        celdaactual.Colonias = LstDirecciones.Where(x => x.Id == celdaactual.ColoniaId).SingleOrDefault();
                        celdaactual.CodigosPostales = celdaactual.Colonias.CodigosPostales;
                        celdaactual.Ciudades = celdaactual.Colonias.Ciudades;
                        celdaactual.Municipios = celdaactual.Colonias.Municipios;
                        celdaactual.Estados = celdaactual.Colonias.Estados;
                        celdaactual.Paises = celdaactual.Colonias.Paises;

                        celdaactual.ColoniaId = celdaactual.Colonias.Id;
                        celdaactual.CodigoPostalId = celdaactual.Colonias.CodigoPostalId;
                        celdaactual.CiudadId = celdaactual.Colonias.CiudadId;
                        celdaactual.MunicipioId = celdaactual.Colonias.MunicipioId;
                        celdaactual.EstadoId = celdaactual.Colonias.EstadoId;
                        celdaactual.PaisId = celdaactual.Colonias.PaisId;
                    }
                }

                this.RaisePropertyChanged(x => x.Item);
                // celdaactual.ImpuestoActual = Item;


                if (Item.Id != 0)
                {
                    foreach (ProveedoresDirecciones i in Item.ProveedoresDirecciones.Where(x => x.ProveedorId == 0).ToList())
                    {
                        i.ProveedorId = Item.Id;
                    }
                }

                if (Item.Errores() != null)
                    return;
                    
            }
        }

        public void EliminaFilaDireccion(ProveedoresDirecciones detalle)
        {
            try
            {
                if (DireccionSeleccionado != null)
                {
                    Item.ProveedoresDirecciones.Remove(DireccionSeleccionado);
                }

                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {

                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }

        public void ValorCeldaCambioContacto(CellValue celda)
        {
            if (celda != null)
            {
                if (celda.Property == "ColoniaId")
                {
                    ProveedoresContactos celdaactual = (ProveedoresContactos)celda.Row;
                    celdaactual.CanValidate = true;
                    if (celdaactual.ColoniaId != 0)
                    {
                        celdaactual.Colonias = LstDirecciones.Where(x => x.Id == celdaactual.ColoniaId).SingleOrDefault();
                        celdaactual.CodigosPostales = celdaactual.Colonias.CodigosPostales;
                        celdaactual.Ciudades = celdaactual.Colonias.Ciudades;
                        celdaactual.Municipios = celdaactual.Colonias.Municipios;
                        celdaactual.Estados = celdaactual.Colonias.Estados;
                        celdaactual.Paises = celdaactual.Colonias.Paises;

                        celdaactual.ColoniaId = celdaactual.Colonias.Id;
                        celdaactual.CodigoPostalId = celdaactual.Colonias.CodigoPostalId;
                        celdaactual.CiudadId = celdaactual.Colonias.CiudadId;
                        celdaactual.MunicipioId = celdaactual.Colonias.MunicipioId;
                        celdaactual.EstadoId = celdaactual.Colonias.EstadoId;
                        celdaactual.PaisId = celdaactual.Colonias.PaisId;
                    }
                }

                this.RaisePropertyChanged(x => x.Item);
                // celdaactual.ImpuestoActual = Item;


                if (Item.Id != 0)
                {
                    foreach (ProveedoresContactos i in Item.ProveedoresContactos.Where(x => x.ProveedorId == 0).ToList())
                    {
                        i.ProveedorId = Item.Id;
                    }
                }

                if (Item.Errores() != null)
                    return;
                    
            }
        }

        public void EliminaFilaContacto(ProveedoresContactos detalle)
        {
            try
            {
                if (ContactoSeleccionado != null)
                {
                    Item.ProveedoresContactos.Remove(ContactoSeleccionado);
                }

                this.RaisePropertyChanged(x => x.Item);
            }
            catch (Exception ex)
            {
                DXMessageBox.Show(this.OwnerVista, ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None, FloatingMode.Popup);
            }
        }
    }
}

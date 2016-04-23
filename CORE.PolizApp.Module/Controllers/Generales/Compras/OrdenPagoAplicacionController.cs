using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using CORE.Modulos.Compras;
using CORE.Modulos.Controllers.Gestion;
using CORE.Modulos.Gestion;

namespace CORE.Modulos.Controllers.Compras
{
  public class OrdenPagoAplicacionController : PagoAplicacionController
  {
    protected override void CreateActions( )
    {
      base.CreateActions( );

      PagoAplicarCuotaAction.Id = "OrdenPagoAplicarCuotaAction";
    }

    protected override void SetupCollectionSource( CollectionSource collectionSource )
    {
      collectionSource.Criteria.Add( "CuotasDelProveedor", CriteriaOperator.Parse( "Comprobante.Originante = ?", this.GetMasterObject< Pago >( ).Destinatario ) );
      collectionSource.Criteria.Add( "ComprobantesCompra", CriteriaOperator.Parse( "[<CORE.Modulos.Compras.Comprobante>][^.Comprobante.Oid = Oid]" ) );
    }

    protected override void SetupShowViewParameters( SimpleActionExecuteEventArgs e, CollectionSource collectionSource )
    {
      e.ShowViewParameters.CreatedView = Application.CreateListView( "CORE.Modulos.Gestion.ComprobanteCuota_LookupListView", collectionSource, false );
    }

    protected override void OnViewChanging( View view )
    {
      base.OnViewChanging( view );

      Active[ "EsPagoTipo" ] = view is ListView && this.GetMasterType( ( ListView ) view ) == typeof( OrdenPago );
    }
  }
}

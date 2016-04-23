using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using CORE.Modulos.Controllers.Gestion;
using CORE.Modulos.Gestion;
using CORE.Modulos.Ventas;

namespace CORE.Modulos.Controllers.Ventas
{
  public class ReciboAplicacionController : PagoAplicacionController
  {
    protected override void CreateActions( )
    {
      base.CreateActions( );

      PagoAplicarCuotaAction.Id = "ReciboAplicarCuotaAction";
    }

    protected override void SetupCollectionSource( CollectionSource collectionSource )
    {
      collectionSource.Criteria.Add( "CuotasDelCliente", CriteriaOperator.Parse( "Comprobante.Destinatario = ?", this.GetMasterObject<Pago>( ).Destinatario ) );
      collectionSource.Criteria.Add( "ComprobantesVenta", CriteriaOperator.Parse( "[<CORE.Modulos.Ventas.Comprobante>][^.Comprobante.Oid = Oid]" ) );
    }

    protected override void SetupShowViewParameters( SimpleActionExecuteEventArgs e, CollectionSource collectionSource )
    {
      e.ShowViewParameters.CreatedView = Application.CreateListView( "CORE.Modulos.Gestion.ComprobanteCuota_LookupListView", collectionSource, false );
    }

    protected override void OnViewChanging( View view )
    {
      base.OnViewChanging( view );

      Active[ "EsPagoTipo" ] = view is ListView && this.GetMasterType( ( ListView ) view ) == typeof( Recibo );
    }
  }
}
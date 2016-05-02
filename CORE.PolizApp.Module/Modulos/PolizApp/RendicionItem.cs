using System;
using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionItem")]
    public class RendicionItem : BasicObject
    {
        private decimal _fCambio;
        private decimal _fCambioComision;
        private decimal _fComisionCobranzaAplicado;
        private decimal _fComisionCobranzaCobrada;
        private decimal _fComisionCobranzaOrganizador;
        private decimal _fComisionCobranzaProductor;
        private decimal _fComisionCobranzaProductorRendidoTasa;
        private decimal _fComisionCobranzaTotal;
        private decimal _fComisionOrganizadorTotal;
        private decimal _fComisionPrimaAplicado;
        private decimal _fComisionPrimaCobrada;
        private decimal _fComisionPrimaOrganizador;
        private decimal _fComisionPrimaProductor;
        private decimal _fComisionPrimaProductorRendidoTasa;
        private decimal _fComisionPrimaTotal;
        private decimal _fComisionProductorTotal;
        private decimal _fComisionTotal;
        private DocumentoCuota _fDocumentoCuota;
        private Especie _fEspecie;
        private Especie _fEspecieComision;
        private DateTime _fFechaCobroAseguradora;
        private decimal _fImporte;
        private decimal _fImporteAplicado;
        private string _fNota;
        private int _fPagoAplicacion;
        private Rendicion _fRendicionDeAseguradora;

        public RendicionItem(Session session) : base(session)
        {
        }

        [Association(@"RendicionItemReferencesRendicion")]
        public Rendicion RendicionDeAseguradora
        {
            get { return _fRendicionDeAseguradora; }
            set { SetPropertyValue("RendicionDeAseguradora", ref _fRendicionDeAseguradora, value); }
        }

        [Association(@"RendicionItemReferencesDocumentoCuota")]
        public DocumentoCuota DocumentoCuota
        {
            get { return _fDocumentoCuota; }
            set { SetPropertyValue("DocumentoCuota", ref _fDocumentoCuota, value); }
        }

        //TODO: fk a PagoAplicacion
        public int PagoAplicacion
        {
            get { return _fPagoAplicacion; }
            set { SetPropertyValue<int>("PagoAplicacion", ref _fPagoAplicacion, value); }
        }

        public DateTime FechaCobroAseguradora
        {
            get { return _fFechaCobroAseguradora; }
            set { SetPropertyValue<DateTime>("FechaCobroAseguradora", ref _fFechaCobroAseguradora, value); }
        }

        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        public decimal Importe
        {
            get { return _fImporte; }
            set { SetPropertyValue<decimal>("Importe", ref _fImporte, value); }
        }

        public decimal Cambio
        {
            get { return _fCambio; }
            set { SetPropertyValue<decimal>("Cambio", ref _fCambio, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),[Importe]/case when isnull([Cambio],(0))=(0) then (1) else [Cambio] end,(0)))
        public decimal ImporteAplicado
        {
            get { return _fImporteAplicado; }
            set { SetPropertyValue<decimal>("ImporteAplicado", ref _fImporteAplicado, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),([comisionprimaorganizador]+[comisionprimaproductor])/[cambiocomision],(0)))
        public decimal ComisionPrimaAplicado
        {
            get { return _fComisionPrimaAplicado; }
            set { SetPropertyValue<decimal>("ComisionPrimaAplicado", ref _fComisionPrimaAplicado, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),([comisioncobranzaorganizador]+[comisioncobranzaproductor])/[cambiocomision],(0)))
        public decimal ComisionCobranzaAplicado
        {
            get { return _fComisionCobranzaAplicado; }
            set { SetPropertyValue<decimal>("ComisionCobranzaAplicado", ref _fComisionCobranzaAplicado, value); }
        }

        public Especie EspecieComision
        {
            get { return _fEspecieComision; }
            set { SetPropertyValue("EspecieComision", ref _fEspecieComision, value); }
        }

        public decimal CambioComision
        {
            get { return _fCambioComision; }
            set { SetPropertyValue<decimal>("CambioComision", ref _fCambioComision, value); }
        }

        public decimal ComisionPrimaOrganizador
        {
            get { return _fComisionPrimaOrganizador; }
            set { SetPropertyValue<decimal>("ComisionPrimaOrganizador", ref _fComisionPrimaOrganizador, value); }
        }

        public decimal ComisionPrimaProductor
        {
            get { return _fComisionPrimaProductor; }
            set { SetPropertyValue<decimal>("ComisionPrimaProductor", ref _fComisionPrimaProductor, value); }
        }

        public decimal ComisionCobranzaOrganizador
        {
            get { return _fComisionCobranzaOrganizador; }
            set { SetPropertyValue<decimal>("ComisionCobranzaOrganizador", ref _fComisionCobranzaOrganizador, value); }
        }

        public decimal ComisionCobranzaProductor
        {
            get { return _fComisionCobranzaProductor; }
            set { SetPropertyValue<decimal>("ComisionCobranzaProductor", ref _fComisionCobranzaProductor, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),[comisionprimaorganizador]+[comisioncobranzaorganizador],(0)))
        public decimal ComisionOrganizadorTotal
        {
            get { return _fComisionOrganizadorTotal; }
            set { SetPropertyValue<decimal>("ComisionOrganizadorTotal", ref _fComisionOrganizadorTotal, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),[comisionprimaproductor]+[comisioncobranzaproductor],(0)))
        public decimal ComisionProductorTotal
        {
            get { return _fComisionProductorTotal; }
            set { SetPropertyValue<decimal>("ComisionProductorTotal", ref _fComisionProductorTotal, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),[comisionprimaorganizador]+[comisionprimaproductor],(0)))
        public decimal ComisionPrimaTotal
        {
            get { return _fComisionPrimaTotal; }
            set { SetPropertyValue<decimal>("ComisionPrimaTotal", ref _fComisionPrimaTotal, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),[comisioncobranzaorganizador]+[comisioncobranzaproductor],(0)))
        public decimal ComisionCobranzaTotal
        {
            get { return _fComisionCobranzaTotal; }
            set { SetPropertyValue<decimal>("ComisionCobranzaTotal", ref _fComisionCobranzaTotal, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),(([comisionprimaproductor]+[comisioncobranzaproductor])+[comisionprimaorganizador])+[comisioncobranzaorganizador],(0)))
        public decimal ComisionTotal
        {
            get { return _fComisionTotal; }
            set { SetPropertyValue<decimal>("ComisionTotal", ref _fComisionTotal, value); }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),case when ([comisionprimaorganizador]+[comisionprimaproductor])=(0) then (0) else ([comisionprimaproductor]/([comisionprimaorganizador]+[comisionprimaproductor]))*(100) end,(0)))
        public decimal ComisionPrimaProductorRendidoTasa
        {
            get { return _fComisionPrimaProductorRendidoTasa; }
            set
            {
                SetPropertyValue<decimal>("ComisionPrimaProductorRendidoTasa", ref _fComisionPrimaProductorRendidoTasa,
                    value);
            }
        }

        //TODO: era computed; implementar en codigo
        //(CONVERT([decimal](12,2),case when ([comisioncobranzaorganizador]+[comisioncobranzaproductor])=(0) then (0) else ([comisioncobranzaproductor]/([comisioncobranzaorganizador]+[comisioncobranzaproductor]))*(100) end,(0)))
        public decimal ComisionCobranzaProductorRendidoTasa
        {
            get { return _fComisionCobranzaProductorRendidoTasa; }
            set
            {
                SetPropertyValue<decimal>("ComisionCobranzaProductorRendidoTasa",
                    ref _fComisionCobranzaProductorRendidoTasa, value);
            }
        }

        public decimal ComisionPrimaCobrada
        {
            get { return _fComisionPrimaCobrada; }
            set { SetPropertyValue<decimal>("ComisionPrimaCobrada", ref _fComisionPrimaCobrada, value); }
        }

        public decimal ComisionCobranzaCobrada
        {
            get { return _fComisionCobranzaCobrada; }
            set { SetPropertyValue<decimal>("ComisionCobranzaCobrada", ref _fComisionCobranzaCobrada, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }

        [Association(@"LiquidacionIntermadiarioItemReferencesRendicionItem")]
        public XPCollection<LiquidacionIntermadiarioItem> LiquidacionIntermadiarioItems => GetCollection<LiquidacionIntermadiarioItem>("LiquidacionIntermadiarioItems");
    }
}
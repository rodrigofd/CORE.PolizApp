using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Gestion;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.Stock
{
  [ImageName("box-share")]
  [Persistent(@"stock.Servicio")]
  [DefaultClassOptions]
  [DefaultProperty("Nombre")]
  [System.ComponentModel.DisplayName("Servicio")]
  [DefaultClassOptions]
public class Servicio : BasicObject
  {
    private string fCodigo;
    private string fNombre;

    public Servicio(Session session)
      : base(session)
    {
    }

    [Size(50)]
    [System.ComponentModel.DisplayName("C�digo")]
    [ Index(0) ]
public string Codigo
    {
      get { return fCodigo; }
      set { SetPropertyValue("codigo_articulo", ref fCodigo, value); }
    }

    [System.ComponentModel.DisplayName("Nombre")]
    [Index(1)]
public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue("Nombre", ref fNombre, value); }
    }
  }
}
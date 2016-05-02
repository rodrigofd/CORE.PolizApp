using System;
using System.Drawing;
using DevExpress.Xpo.Metadata;

namespace FDIT.Core
{
  [DefaultClassOptions]
public class ImageValueConverter : ValueConverter
  {
    public override Type StorageType
    {
      get { return typeof( byte[ ] ); }
    }

    private readonly ImageConverter imageConverter;

    public ImageValueConverter( )
    {
      imageConverter = new ImageConverter( );
    }

    public override object ConvertToStorageType( object value )
    {
      return value == null ? null : imageConverter.ConvertTo( value, StorageType );
    }

    public override object ConvertFromStorageType( object value )
    {
      return value == null ? null : imageConverter.ConvertFrom( value );
    }
  }
}
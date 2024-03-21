using MigrationSource.iOS.Renderers;
using MigrationSource.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AutoSelectEntry),
           typeof(AutoSelectEntryRenderer))]
namespace MigrationSource.iOS.Renderers
{
    public class AutoSelectEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(
            ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var nativeTextField = Control;
            nativeTextField.EditingDidBegin += 
                (object sender, EventArgs eIos) =>
            {
                nativeTextField.PerformSelector(new ObjCRuntime
                               .Selector("selectAll"),
                null, 0.0f);
            };
        }
    }
}
using Android.Content;
using MigrationSource.Droid.Renderers;
using MigrationSource.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AutoSelectEntry), 
    typeof(AutoSelectEntryRenderer))]
namespace MigrationSource.Droid.Renderers
{
    public class AutoSelectEntryRenderer : EntryRenderer
    {
        public AutoSelectEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(
            ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeEditText = 
                    (global::Android.Widget.EditText)Control;
                nativeEditText.SetSelectAllOnFocus(true);
            }
        }
    }
}
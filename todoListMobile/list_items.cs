using Android.App;
using Android.OS;

namespace todoListMobile
{
    [Activity(Label = "New activity")]
    class list_items : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout._items);
        }
    }
}
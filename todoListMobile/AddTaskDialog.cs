using Android.App;
using Android.OS;
using Android.Widget;

namespace todoListMobile
{
    [Activity(Label = "New activity")]

    class AddTaskDialog : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddTaskDialog);

            TimePicker picker = FindViewById<TimePicker>(Resource.Id.deadlineTimePicker);
            picker.SetIs24HourView((Java.Lang.Boolean)true);
        }
    }
}
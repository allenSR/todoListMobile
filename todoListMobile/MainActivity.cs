using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CHD;
using System;
using TodoList;

namespace todoListMobile
{
    [Activity (Label ="ToDo list"/*MainLauncher = true*/)]
    public class MainActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {                          //AppCompatActivity - сверху отображается название лайоута
        Button dailyTaskButton;
        Button commonTaskButton;
        Button exitButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Toolbar toolbarCommonTasks = FindViewById<Toolbar>(Resource.Id.toolbarCommonTasks);
            toolbarCommonTasks.InflateMenu(Resource.Menu.myMenu_CommonTasks);

            dailyTaskButton = FindViewById<Button>(Resource.Id.DailyTaskButton);
            commonTaskButton = FindViewById<Button>(Resource.Id.CommonTaskButton);
            exitButton = FindViewById<Button>(Resource.Id.ExitButton);

            dailyTaskButton.Click += DailyTaskButton_Click;
            commonTaskButton.Click += CommonTaskButton_Click;
            exitButton.Click += ExitButton_Click;

            /// Защита от возврата на страницу входа
            bool OnBackButtonPressed()
            {
                return false;
            }
            HWBackButtonManager.OnBackButtonPressedDelegate onBackButtonPressedDelegate = new HWBackButtonManager.OnBackButtonPressedDelegate(OnBackButtonPressed);
            HWBackButtonManager.Instance.SetHWBackButtonListener(onBackButtonPressedDelegate);
            ///
        }
      
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(login));
            StartActivity(intent);
        }

        private void CommonTaskButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CommonTasks));
            StartActivity(intent);
        }

        private void DailyTaskButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this,  typeof(ButtonsLayout));
            StartActivity(intent);
        }

      /*  public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }*/
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            /*switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                   
                    return true;
                case Resource.Id.navigation_dashboard:
                    //Intent intentCommonTasks = new Intent(this, typeof(CommonTasks));
                    //StartActivity(intentCommonTasks);
                    LayoutInflater inflater = LayoutInflater.From(this);
                    View subView = inflater.Inflate(Resource.Layout.CommonTasks, null);
                    //layoutContent.AddView(subView);
                    
                    return true;
                case Resource.Id.navigation_notifications:
                    Intent intentSettings = new Intent(this, typeof(Settings));
                    StartActivity(intentSettings);
                    return true;
                
            }*/
            return false;
        }
      
        #region Защита от возврата на страницу входа
        public override void OnBackPressed()
        {
            if (!CHD.HWBackButtonManager.Instance.NotifyHWBackButtonPressed())
            {
                return;
            }

            base.OnBackPressed();
        }
        #endregion
    }
}


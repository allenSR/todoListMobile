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
    public class MainActivity : Activity//, BottomNavigationView.IOnNavigationItemSelectedListener
    {                          //AppCompatActivity - сверху отображается название лайоута
        Button dailyTaskButton;
        Button commonTaskButton;
        Button exitButton;
        Button weeklyTaskButton;
        Button allTaskButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Toolbar toolbarCommonTasks = FindViewById<Toolbar>(Resource.Id.toolbarMainScreen);
            toolbarCommonTasks.InflateMenu(Resource.Menu.myMenu);

            dailyTaskButton = FindViewById<Button>(Resource.Id.DailyTaskButton);
            commonTaskButton = FindViewById<Button>(Resource.Id.CommonTaskButton);
            exitButton = FindViewById<Button>(Resource.Id.ExitButton);
            weeklyTaskButton = FindViewById<Button>(Resource.Id.weeklyTaskButton);
            allTaskButton = FindViewById<Button>(Resource.Id.allTaskButton);

            toolbarCommonTasks.MenuItemClick += ToolbarCommonTasks_MenuItemClick;
            dailyTaskButton.Click += DailyTaskButton_Click;
            commonTaskButton.Click += CommonTaskButton_Click;
            exitButton.Click += ExitButton_Click;
            weeklyTaskButton.Click += WeeklyTaskButton_Click;
            allTaskButton.Click += AllTaskButton_Click;

            /// Защита от возврата на страницу входа
            bool OnBackButtonPressed()
            {
                return false;
            }
            HWBackButtonManager.OnBackButtonPressedDelegate onBackButtonPressedDelegate = new HWBackButtonManager.OnBackButtonPressedDelegate(OnBackButtonPressed);
            HWBackButtonManager.Instance.SetHWBackButtonListener(onBackButtonPressedDelegate);
            ///
        }

        private void AllTaskButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AllTasks));
            StartActivity(intent);
        }

        private void WeeklyTaskButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(WeeklyTasks));
            StartActivity(intent);
        }

        private void ToolbarCommonTasks_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
           
            Intent intent = new Intent(this, typeof(Settings));
            StartActivity(intent);
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


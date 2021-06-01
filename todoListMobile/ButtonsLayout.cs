using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoList;

namespace todoListMobile
{   [Activity]
    class ButtonsLayout : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ButtonsLayout);

            Button mondayButton = FindViewById<Button>(Resource.Id.mondayButton);
            Button tuesdayButton = FindViewById<Button>(Resource.Id.tuesdayButton);
            Button wednesdayButton = FindViewById<Button>(Resource.Id.wednesdayButton);
            Button thursdayButton = FindViewById<Button>(Resource.Id.thursdayButton);
            Button fridayButton = FindViewById<Button>(Resource.Id.fridayButton);
            Button saturdayButton = FindViewById<Button>(Resource.Id.saturdayButton);
            Button sundayButton = FindViewById<Button>(Resource.Id.sundayButton);

            mondayButton.Click += mondayButton_Click;
            tuesdayButton.Click += tuesdayButton_Click;
            wednesdayButton.Click += wednesdayButton_Click;
            thursdayButton.Click += thursdayButton_Click;
            fridayButton.Click += fridayButton_Click;
            saturdayButton.Click += saturdayButton_Click;
            sundayButton.Click += sundayButton_Click;

            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();

            mondayButton.Text += " " + dateWeek.monday;
            tuesdayButton.Text += " " + dateWeek.tuesday;
            wednesdayButton.Text += " " + dateWeek.wednesday;
            thursdayButton.Text += " " + dateWeek.thursday;
            fridayButton.Text += " " + dateWeek.friday;
            saturdayButton.Text += " " + dateWeek.saturday;
            sundayButton.Text += " " + dateWeek.sunday;
        }

        #region Запуск активити DailyTask
        public string StartActivityDailyTask(string enddate)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("CurrentDate", enddate);
            editor.Apply();
            Intent intent = new Intent(this, typeof(DailyTask));
            StartActivity(intent);
            return "";
        }
        #endregion
        #region Открытие списка дел на конкретный день недели
        private void mondayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateMonday = (dateWeek.monday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateMonday).ToString("O");
            StartActivityDailyTask(endDate);
        }

        private void tuesdayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateTuesday = (dateWeek.tuesday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateTuesday).ToString("O");
            StartActivityDailyTask(endDate);
        }

        private void sundayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateSunday = (dateWeek.sunday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateSunday).ToString("O");
            StartActivityDailyTask(endDate);
        }

        private void saturdayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateSaturday = (dateWeek.saturday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateSaturday).ToString("O");
            StartActivityDailyTask(endDate);
        }

        private void fridayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateFriday = (dateWeek.friday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateFriday).ToString("O");
            StartActivityDailyTask(endDate);
        }

        private void thursdayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateThurdsday = (dateWeek.thursday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateThurdsday).ToString("O");
            StartActivityDailyTask(endDate);
        }

        private void wednesdayButton_Click(object sender, EventArgs e)
        {
            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateWednesday = (dateWeek.wednesday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateWednesday).ToString("O");
            StartActivityDailyTask(endDate);
        }
        #endregion
    }
}
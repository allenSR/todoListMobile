using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace todoListMobile
{
    [Activity]
    class AddCalendarTask : Activity
    {
        EditText descriptonCalendarTaskText;
        DatePicker datePicker;
        Button addCalendarTaskButton;
        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddCalendarTask);
            descriptonCalendarTaskText = FindViewById<EditText>(Resource.Id.descriptonCalendarTaskText);
            datePicker = FindViewById<DatePicker>(Resource.Id.datePicker);
            addCalendarTaskButton = FindViewById<Button>(Resource.Id.addCalendarTaskButton);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbarCalendarTask);
            toolbar.InflateMenu(Resource.Menu.myMenu);
            toolbar.MenuItemClick += Toolbar_MenuItemClick;
            addCalendarTaskButton.Click += AddCalendarTaskButton_Click;
        }

        private void Toolbar_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.TitleFormatted.ToString() == "Настройки")
            {
                Intent intent = new Intent(this, typeof(Settings));
                StartActivity(intent);
            }
        }

        private void AddCalendarTaskButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptonCalendarTaskText.Text))
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alert.SetTitle("Ошибка");
                alert.SetMessage("Введите описание задачи");
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogError = alert.Create();
                dialogError.Show();
                return;
                
            }
            
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            DateTime selectedDate = datePicker.DateTime;
            try
            {
                var url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/CalendarTaskCheck";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                    pars.Add("format", "json");
                    pars.Add("Description", descriptonCalendarTaskText.Text);
                    pars.Add("Date", selectedDate.ToString("O"));
                    byte[] responsebytes = webClient.UploadValues(url, pars);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);
                    if (responsebody != "[]")
                    {
                        AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                        alert.SetTitle("Ошибка");
                        alert.SetMessage("Введенная задача на выбранную дату уже существует.");
                        alert.SetNegativeButton("ОК", (senderAlert, args) =>
                        {
                            return;
                        });
                        Dialog dialogError = alert.Create();
                        dialogError.Show();
                        return;
                    }
                }
            }
            catch
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alert.SetTitle("Ошибка");
                alert.SetMessage("Произошла ошибка.");
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogError = alert.Create();
                dialogError.Show();
                return;
            }

            try
            {
                var url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/CalendarTaskAdd";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    pars.Add("format", "json");
                    webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                    pars.Add("Description", descriptonCalendarTaskText.Text);
                    pars.Add("DateDeadline", null);
                    pars.Add("Date", selectedDate.ToString("O"));
                    byte[] responsebytes = webClient.UploadValues(url, pars);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    Toast.MakeText(this, "Задача успешно добавлена", ToastLength.Long).Show();
                }
            }
            catch
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alert.SetTitle("Ошибка");
                alert.SetMessage("Произошла ошибка.");
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogError = alert.Create();
                dialogError.Show();
                return;
            }
        }
    }
}
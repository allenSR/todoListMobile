using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace todoListMobile
{[Activity(Label ="Настройки")]
    class Settings: Activity
    {
        Button deleteCompletedCommonTasksButton;
        Button deleteAllCommonTasksButton;
        Button newPasswordButton;
        EditText newPasswordText;
        EditText confirmPasswordText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.Settings);

            deleteCompletedCommonTasksButton = FindViewById<Button>(Resource.Id.deleteCompletedCommonTasksButton);
            deleteAllCommonTasksButton = FindViewById<Button>(Resource.Id.deleteAllCommonTasksButton);
            newPasswordButton = FindViewById<Button>(Resource.Id.newPasswordButton);
            newPasswordText = FindViewById<EditText>(Resource.Id.newPasswordText);
            confirmPasswordText = FindViewById<EditText>(Resource.Id.confirmPasswordText);

            deleteCompletedCommonTasksButton.Click += DeleteCompletedCommonTasksButton_Click;
            deleteAllCommonTasksButton.Click += DeleteAllCommonTasksButton_Click;
            newPasswordButton.Click += NewPasswordButton_Click;

        }

        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(newPasswordText.Text))
            {
                AlertDialog.Builder alertError = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alertError.SetTitle("Ошибка");
                alertError.SetMessage("Укажите новый пароль.");
                alertError.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogError = alertError.Create();
                dialogError.Show();
                return;
            }
            if(string.IsNullOrEmpty(confirmPasswordText.Text))
            {
                AlertDialog.Builder alertError = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alertError.SetTitle("Ошибка");
                alertError.SetMessage("Повторите новый пароль");
                alertError.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogError = alertError.Create();
                dialogError.Show();
                return;
            }
            if(newPasswordText.Text != confirmPasswordText.Text)
            {
                AlertDialog.Builder alertError = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alertError.SetTitle("Ошибка");
                alertError.SetMessage("Введенные пароль ни совпадают");
                alertError.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogError = alertError.Create();
                dialogError.Show();
                return;
            }
            AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
            alert.SetTitle("Подтверждение");
            alert.SetMessage("Вы уверены что хотите изменить пароль?");
            alert.SetPositiveButton("Да", (senderAlert, args) =>
            {
                try
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/UpdatePassword";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");
                        pars.Add("Password", newPasswordText.Text);

                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);

                        Toast.MakeText(this, "Пароль успешно изменен.", ToastLength.Long).Show();

                    }
                }
                catch
                {
                    AlertDialog.Builder alertError = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                    alertError.SetTitle("Ошибка");
                    alertError.SetMessage("Произошла ошибка");
                    alertError.SetNegativeButton("ОК", (senderAlert, args) =>
                    {
                        return;
                    });
                    Dialog dialogError = alertError.Create();
                    dialogError.Show();
                    return;

                }
            });
            alert.SetNegativeButton("Нет", (senderAlert, args) =>
            {
                return;
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void DeleteAllCommonTasksButton_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
            alert.SetTitle("Вы уверены, что хотите удалить все  общие задачи?");
            alert.SetPositiveButton("Да", (senderAlert, args) => {
                try
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DeleteAllCommonTasks";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");

                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);

                        Toast.MakeText(this, "Все общие задачи успешно удалены", ToastLength.Long).Show();
                    }
                }
                catch
                {
                    Toast.MakeText(this, "Произошла ошибка", ToastLength.Long).Show();

                }
            });
            alert.SetNegativeButton("Нет", (senderAlert, args) =>
            {
                return;
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void DeleteCompletedCommonTasksButton_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
            alert.SetTitle("Вы уверены, что хотите удалить все выполненные общие задачи?");
            alert.SetPositiveButton("Да", (senderAlert, args) => {
                try
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DeleteComplitedCommonTasks";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");
                        pars.Add("DealStatus", "2");

                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);

                        Toast.MakeText(this, "Все выполненные общие задачи успешно удалены", ToastLength.Long).Show();              
                    }
                }
                catch
                {
                    Toast.MakeText(this, "Произошла ошибка", ToastLength.Long).Show();

                }
            });
            alert.SetNegativeButton("Нет", (senderAlert, args) =>
            {
                return;
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}
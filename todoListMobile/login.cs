using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;


namespace todoListMobile
{
    public class WebClientWithTimeout : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest wr = base.GetWebRequest(address);
            wr.Timeout = 3000; // timeout in milliseconds (ms)
            return wr;
        }
    }

    [Activity(Label = "ToDoList", MainLauncher = true)]
    class login : Activity
    {

        CheckBox checkBox;
        EditText loginText;
        EditText passwordText;
        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);


            loginText = FindViewById<EditText>(Resource.Id.loginText);
            passwordText = FindViewById<EditText>(Resource.Id.passwordText);
            checkBox = FindViewById<CheckBox>(Resource.Id.checkBoxPass);

            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);
            Button registrationButton = FindViewById<Button>(Resource.Id.registrarionButton);
            Button connectionSettinsButton = FindViewById<Button>(Resource.Id.connectionSettingsButton);

            loginButton.Click += LoginButton_Click;
            connectionSettinsButton.Click += connectionSettingsButton_Click;

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            loginText.Text = prefs.GetString("login", "");
            bool checkStatus = prefs.GetBoolean("SavePassCheck", false);
            if (checkStatus == true)
            {
                passwordText.Text = prefs.GetString("password", "");
                checkBox.Checked = true;
            }

            registrationButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Register));
                StartActivity(intent);
            };
        }


        private void connectionSettingsButton_Click(object sender, EventArgs e)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            LayoutInflater inflater = LayoutInflater.From(this);
            View subView = inflater.Inflate(Resource.Layout.ServerAddres, null);
            EditText serverAddresText = (EditText)subView.FindViewById(Resource.Id.serverAddresText);
            EditText serverPortText = (EditText)subView.FindViewById(Resource.Id.serverPortText);
            TextView addres1Text = (TextView)subView.FindViewById(Resource.Id.addres1Text);
            TextView port1Text = (TextView)subView.FindViewById(Resource.Id.port1Text);

            serverAddresText.Text = prefs.GetString("addres", "");
            serverPortText.Text = prefs.GetString("port", "");
            AlertDialog.Builder builder = new AlertDialog.Builder(this, AlertDialog.ThemeDeviceDefaultDark);
            builder.SetView(subView);
            builder.SetPositiveButton("ОК", (senderAlert, args) =>
            {
                if (string.IsNullOrEmpty(serverAddresText.Text))
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeDeviceDefaultDark);
                    alert.SetTitle("Ошибка");
                    alert.SetMessage("Укажите адрес сервера.");
                    alert.SetNegativeButton("ОК", (senderAlert, args) =>
                    {
                        return;
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    return;
                }
                if (string.IsNullOrEmpty(serverPortText.Text))
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeDeviceDefaultDark);
                    alert.SetTitle("Ошибка");
                    alert.SetMessage("Укажите порт сервера.");
                    alert.SetNegativeButton("ОК", (senderAlert, args) =>
                    {
                        return;
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    return;
                }



                editor.PutString("addres", serverAddresText.Text);
                editor.PutString("port", serverPortText.Text);
                editor.Apply();
                Toast.MakeText(this, "Строка подключения изменена.", ToastLength.Long).Show();
            });
            AlertDialog dialogSettings = builder.Create();
            dialogSettings.Show();
        }

        [Obsolete]
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();


            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(loginText.Text)) errors.AppendLine("Введите логин.");
            if (string.IsNullOrWhiteSpace(passwordText.Text)) errors.AppendLine("Введите пароль.");
            if (errors.Length > 0)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Ошибка");
                alert.SetMessage(errors.ToString());
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }

            try
            {
                string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/userLogin";
                using (WebClient wc = new WebClientWithTimeout())
                {
                   
                    var pars = new NameValueCollection();
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    pars.Add("format", "json");
                    pars.Add("Login", loginText.Text);
                    pars.Add("Password", passwordText.Text);
                    byte[] responsebytes = wc.UploadValues(url, pars);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);
                    if (responsebody == "")
                    {
                        AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                        alert.SetTitle("Ошибка");
                        alert.SetMessage("Неверный логин или пароль.");
                        alert.SetNegativeButton("ОК", (senderAlert, args) =>
                        {
                            return;
                        });
                        Dialog dialog = alert.Create();
                        dialog.Show();
                        return;
                    }
                    else
                    {
                        editor.PutString("ID_User", responsebody);
                        editor.Apply();
                    }


                }
                if (prefs.GetString("login", "") != loginText.Text || prefs.GetString("password", "") != passwordText.Text)
                {
                    editor.PutString("login", loginText.Text);
                    editor.PutString("password", passwordText.Text);
                    editor.PutBoolean("SavePassCheck", checkBox.Checked);
                    editor.Apply();
                }



                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
          
            
           catch (Exception ex)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alert.SetTitle("Ошибка");
                if (ex.Message.Contains("Could not find a part of the path "))
                {
                    alert.SetMessage("Некорректная строка подключения к серверу");
                }
                if(ex.Message.Contains("The operation has timed out."))
                {
                    alert.SetMessage("Не удается подключиться к серверу." +
                        " Возможно указан неверный адрес сервера.");
                }
                else
                {
                    alert.SetMessage("Произошла ошибка.");
                }
               
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }
        }
    }
}
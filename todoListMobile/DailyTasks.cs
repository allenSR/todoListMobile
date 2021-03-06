using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using TodoList;

namespace todoListMobile
{

    [Activity(Label = "New activity")]
    public class DailyTask : Activity
    {
        ListView listView;
        TextView textViewDate;
        ImageButton addTaskButton;
        List<Tasks> tasks = new List<Tasks>();

        //private static  int NOTIFY_ID = 101;
        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DailyTask);
            listView = FindViewById<ListView>(Resource.Id.tasksListView);
            textViewDate = FindViewById<TextView>(Resource.Id.textViewDate);
            addTaskButton = FindViewById<ImageButton>(Resource.Id.addTaskButton);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbarDaily);
            toolbar.InflateMenu(Resource.Menu.myMenu_forDailyTasks);

            toolbar.MenuItemClick += Toolbar_MenuItemClick;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            string date = prefs.GetString("CurrentDate", "");

            addTaskButton.Click += addTaskButton_Button;
            DateTime dt = Convert.ToDateTime(date);
            if (dt.DayOfWeek.ToString() == "Wednesday")
            {
                textViewDate.Text += " " + "среду";
            }
            if (dt.DayOfWeek.ToString() == "Friday")
            {
                textViewDate.Text += " " + "пятницу";
            }
            if (dt.DayOfWeek.ToString() == "Saturday")
            {
                textViewDate.Text += " " + "субботу";
            }
            else if (dt.DayOfWeek.ToString() == "Monday" || dt.DayOfWeek.ToString() == "Tuesday" || dt.DayOfWeek.ToString() == "Thursday"
                || dt.DayOfWeek.ToString() == "Sunday")
            {
                textViewDate.Text += " " + dt.ToString("dddd");
            }


            try
            {
                string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/TasksDay";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                    pars.Add("format", "json");
                    pars.Add("Date", date);
                    byte[] responsebytes = webClient.UploadValues(url, pars);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    string time = "";
                    if (responsebody == "[]")
                    {
                        //Нет задач
                    }
                    var objResponse = JsonConvert.DeserializeObject<List<Tasks>>(responsebody);
                    for (int i = 0; i < objResponse.Count; i++)
                    {
                        var a = objResponse[i];
                        var id = a.ID_Task;
                        var numberOfRows = i + 1;
                        var description = a.Description;
                        DateTime dateCur = (DateTime)a.Date;

                        if (a.DateDeadline == null || a.DateDeadline.ToString() == "00:00:00")
                        {
                            time = "---";
                        }
                        else if (a.DateDeadline != null || a.DateDeadline.ToString() != "---")
                        {
                            DateTime deadline = Convert.ToDateTime(a.DateDeadline);
                            time = deadline.ToString("t");
                        }
                        var status = a.DealStatus;

                        tasks.Add(new Tasks()
                        {
                            ID_Task = a.ID_Task,
                            User = a.User,
                            NumberOfRows = i + 1,
                            Description = a.Description,
                            DateDeadline = time,
                            DealStatus = status,
                            Date = dateCur.ToString("O")

                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alert.SetTitle("Ошибка");
                alert.SetMessage("Произошла ошибка.");
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }
            listView.ItemLongClick += listview_ItemLongClick;

            TaskAdapter adapter = new TaskAdapter(this, tasks);
            listView.Adapter = adapter;

            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            DateTime dateNow = DateTime.Now;

            DateTime dateSunday = Convert.ToDateTime(dateWeek.sunday);
            if (dateNow.DayOfWeek <= dt.DayOfWeek)
            {
                addTaskButton.Enabled = true;
            }
            else if (dt.DayOfWeek == dateSunday.DayOfWeek)
            {
                addTaskButton.Enabled = true;
            }
            else
            {
                addTaskButton.Enabled = false;
                addTaskButton.SetImageResource(Resource.Drawable.plus_disable);
            }

/*
            Android.Support.V4.App.NotificationCompat.Builder builder =
                       new Android.Support.V4.App.NotificationCompat.Builder(this)
                       .SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
                       .SetContentTitle("Напоминание")
                       .SetContentText("Пора покормить кота")
                       .SetPriority(Android.Support.V4.App.NotificationCompat.PriorityDefault);

            NotificationManagerCompat notificationManager =
                    NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFY_ID, builder.Build());*/
        }

        private void Toolbar_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.TitleFormatted.ToString() == "Обновить")
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                string date = prefs.GetString("CurrentDate", "");
                try
                {
                    int count = tasks.Count;
                    while (tasks.Count != 0)
                    {
                        tasks.Remove(tasks[count - 1]);
                        count--;
                    }
                    string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/TasksDay";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");
                        //pars.Add("User", prefs.GetInt("ID_User", 0).ToString());
                        pars.Add("Date", date);
                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);

                        string time = "";
                        if (responsebody == "[]")
                        {
                            //Нет задач
                        }
                        var objResponse = JsonConvert.DeserializeObject<List<Tasks>>(responsebody);
                        for (int i = 0; i < objResponse.Count; i++)
                        {
                            var a = objResponse[i];
                            var id = a.ID_Task;
                            var numberOfRows = i + 1;
                            var description = a.Description;
                            DateTime dateCur = (DateTime)a.Date;

                            if (a.DateDeadline == null || a.DateDeadline.ToString() == "00:00:00")
                            {
                                time = "---";
                            }
                            else if (a.DateDeadline != null || a.DateDeadline.ToString() != "---")
                            {
                                DateTime deadline = Convert.ToDateTime(a.DateDeadline);
                                time = deadline.ToString("t");
                            }
                            var status = a.DealStatus;



                            tasks.Add(new Tasks()
                            {
                                ID_Task = a.ID_Task,
                                User = a.User,
                                NumberOfRows = i + 1,
                                Description = a.Description,
                                DateDeadline = time,
                                DealStatus = status,
                                Date = dateCur.ToString("O")

                            });

                        }

                    }
                }
                catch (System.Exception ex)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                    alert.SetTitle("Ошибка");
                    alert.SetMessage("Произошла ошибка.");
                    alert.SetNegativeButton("ОК", (senderAlert, args) =>
                    {
                        return;
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    return;
                }
                Toast.MakeText(this, "Обновлено", ToastLength.Long).Show();

                TaskAdapter adapter = new TaskAdapter(this, tasks);
                listView.Adapter = adapter;
            }
            if (e.Item.TitleFormatted.ToString() == "Настройки")
            {
                Intent intent = new Intent(this, typeof(Settings));
                StartActivity(intent);
            }
            if (e.Item.TitleFormatted.ToString() == "Задачи за всё время")
            {
                Intent intent = new Intent(this, typeof(AllTasks));
                StartActivity(intent);
            }
            if (e.Item.TitleFormatted.ToString() == "Все задачи на текущую неделю")
            {
                Intent intent = new Intent(this, typeof(WeeklyTasks));
                StartActivity(intent);
            }
        }

        private void listview_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            string selectedID_Task = tasks[e.Position].ID_Task.ToString();
            string selectedUser = tasks[e.Position].User.ToString();
            DateTime time;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
            alert.SetTitle("Выберите действие");
            alert.SetNegativeButton("Редактировать", (senderAlert, args) =>
            {

                string Currentdate = prefs.GetString("CurrentDate", "");

                LayoutInflater inflater = LayoutInflater.From(this);
                View subView = inflater.Inflate(Resource.Layout.EditTaskDialog, null);
                EditText descriptionTaskText = (EditText)subView.FindViewById(Resource.Id.addTaskEditText);
                CheckBox deadlineCheckBox = (CheckBox)subView.FindViewById(Resource.Id.deadlineCheckbox);
                TimePicker deadlineTimePicker = (TimePicker)subView.FindViewById(Resource.Id.deadlineTimePicker);
                deadlineTimePicker.SetIs24HourView((Java.Lang.Boolean)true);

                if (tasks[e.Position].DateDeadline.ToString() != "---")
                {
                    deadlineCheckBox.Checked = true;
                    time = Convert.ToDateTime(tasks[e.Position].DateDeadline);
                    DateTime hours = Convert.ToDateTime(tasks[e.Position].DateDeadline);

                    /// Нужно установить время в пикере из выбранной задачи
                    // deadlineTimePicker.Hour = 
                    //deadlineTimePicker.Minute = time;
                    // deadlineTimePicker.SetCurrentHour(new Integer(10));
                }
                if (tasks[e.Position].DateDeadline == null)
                {
                    deadlineCheckBox.Checked = false;
                }
                descriptionTaskText.Text = tasks[e.Position].Description;
                string oldDescription = descriptionTaskText.Text;
                bool oldStatusCheckbox = deadlineCheckBox.Checked;

                AlertDialog.Builder builder = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                builder.SetView(subView);
                builder.SetPositiveButton("ОК", (senderAlert, args) =>
                {
                    if (string.IsNullOrWhiteSpace(descriptionTaskText.Text))
                    {
                        AlertDialog.Builder alertError = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                        alertError.SetTitle("Ошибка");
                        alertError.SetMessage("Введите описание задачи");
                        alertError.SetNegativeButton("ОК", (senderAlert, args) =>
                        {
                            return;
                        });
                        Dialog dialogError = alertError.Create();
                        dialogError.Show();
                        return;
                    }
                    string shortDate = Convert.ToDateTime(Currentdate).ToString("yyyy.MM.dd");

                    // Защита от  повторяющихся задач
                    try
                    {
                        var url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskCheck";
                        using (var webClient = new WebClient())
                        {
                            var pars = new NameValueCollection();
                            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                            pars.Add("format", "json");
                            pars.Add("Date", shortDate);
                            pars.Add("Description", descriptionTaskText.Text);
                            byte[] responsebytes = webClient.UploadValues(url, pars);
                            string responsebody = Encoding.UTF8.GetString(responsebytes);
                            string endDate = Convert.ToDateTime(tasks[e.Position].Date).ToString("O");

                            if (oldDescription == descriptionTaskText.Text && oldStatusCheckbox == deadlineCheckBox.Checked)
                            {
                                Toast.MakeText(this, "Задача не была изменена.", ToastLength.Long).Show();
                                return;
                            }
                            else if (oldDescription == descriptionTaskText.Text && oldStatusCheckbox != deadlineCheckBox.Checked)
                            {
                                try
                                {
                                    string urlUpdate = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskUpdate";
                                    using (var webClientUpdate = new WebClient())
                                    {
                                        var parsUpdate = new NameValueCollection();
                                        webClientUpdate.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                                        webClientUpdate.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                                        parsUpdate.Add("format", "json");
                                        parsUpdate.Add("Date", endDate);
                                        parsUpdate.Add("Description", descriptionTaskText.Text);
                                        parsUpdate.Add("ID_Task", tasks[e.Position].ID_Task.ToString());
                                        if (deadlineCheckBox.Checked == true)
                                        {
                                            string hour = (string)deadlineTimePicker.CurrentHour;
                                            string minute = (string)deadlineTimePicker.CurrentMinute;
                                            time = Convert.ToDateTime(hour + ":" + minute + ":00");
                                            parsUpdate.Add("DateDeadline", time.ToString("t"));
                                        }
                                        else if (deadlineCheckBox.Checked == false)
                                        {
                                            parsUpdate.Add("DateDeadline", null);
                                        }

                                        if (tasks[e.Position].DealStatus == 1)
                                        {
                                            parsUpdate.Add("DealStatus", "1");
                                        }
                                        else if (tasks[e.Position].DealStatus == 2)
                                        {
                                            parsUpdate.Add("DealStatus", "2");
                                        }

                                        DateTime dt;
                                        string hour1 = (string)deadlineTimePicker.CurrentHour;
                                        string minute1 = (string)deadlineTimePicker.CurrentMinute;
                                        time = Convert.ToDateTime(hour1 + ":" + minute1 + ":00");

                                        var elem = tasks.FirstOrDefault(x => x.ID_Task == tasks[e.Position].ID_Task);
                                        if (elem != null)
                                        {
                                            elem.User = tasks[e.Position].User;
                                            elem.NumberOfRows = tasks[e.Position].NumberOfRows;
                                            elem.Description = descriptionTaskText.Text;
                                            elem.DealStatus = tasks[e.Position].DealStatus;
                                            if (deadlineCheckBox.Checked == false)
                                            {
                                                elem.DateDeadline = "---";
                                            }
                                            else if (deadlineCheckBox.Checked == true)
                                                elem.DateDeadline = time.ToString("t");

                                        }
                                        byte[] responsebytesUpdate = webClientUpdate.UploadValues(urlUpdate, parsUpdate);
                                        string responsebodyUpdate = Encoding.UTF8.GetString(responsebytesUpdate);
                                    }
                                    Toast.MakeText(this, "Задача успешно изменена", ToastLength.Long).Show();

                                    listView.Adapter = new TaskAdapter(this, tasks);
                                }
                                catch (System.Exception ex)
                                {
                                    Toast.MakeText(this, "Произошла ошибка ", ToastLength.Long).Show();
                                }
                                return;
                            }
                            else if (responsebody != "[]")
                            {
                                Toast.MakeText(this, "Нельзя изменить задачу на уже существующую.", ToastLength.Long).Show();
                                return;
                            }
                            else
                            {
                                try
                                {
                                    string urlUpdate = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskUpdate";
                                    using (var webClientUpdate = new WebClient())
                                    {
                                        var parsUpdate = new NameValueCollection();
                                        webClientUpdate.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                                        webClientUpdate.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                                        parsUpdate.Add("format", "json");
                                        parsUpdate.Add("Date", endDate);
                                        parsUpdate.Add("Description", descriptionTaskText.Text);
                                        parsUpdate.Add("ID_Task", tasks[e.Position].ID_Task.ToString());
                                        if (deadlineCheckBox.Checked == true)
                                        {
                                            string hour = (string)deadlineTimePicker.CurrentHour;
                                            string minute = (string)deadlineTimePicker.CurrentMinute;
                                            time = Convert.ToDateTime(hour + ":" + minute + ":00");
                                            pars.Add("DateDeadline", time.ToString("t"));
                                        }
                                        else if (deadlineCheckBox.Checked == false)
                                        {
                                            parsUpdate.Add("DateDeadline", null);
                                        }

                                        if (tasks[e.Position].DealStatus == 1)
                                        {
                                            parsUpdate.Add("DealStatus", "1");
                                        }
                                        else if (tasks[e.Position].DealStatus == 2)
                                        {
                                            parsUpdate.Add("DealStatus", "2");
                                        }

                                        DateTime dt;
                                        string hour1 = (string)deadlineTimePicker.CurrentHour;
                                        string minute1 = (string)deadlineTimePicker.CurrentMinute;
                                        time = Convert.ToDateTime(hour1 + ":" + minute1 + ":00");

                                        var elem = tasks.FirstOrDefault(x => x.ID_Task == tasks[e.Position].ID_Task);
                                        if (elem != null)
                                        {
                                            elem.User = tasks[e.Position].User;
                                            elem.NumberOfRows = tasks[e.Position].NumberOfRows;
                                            elem.Description = descriptionTaskText.Text;
                                            elem.DealStatus = tasks[e.Position].DealStatus;
                                            if (deadlineCheckBox.Checked == false)
                                            {
                                                elem.DateDeadline = "---";
                                            }
                                            else if (deadlineCheckBox.Checked == true)
                                                elem.DateDeadline = time.ToString("t");

                                        }
                                        byte[] responsebytesUpdate = webClient.UploadValues(urlUpdate, parsUpdate);
                                        string responsebodyUpdate = Encoding.UTF8.GetString(responsebytesUpdate);
                                    }
                                    Toast.MakeText(this, "Задача успешно изменена", ToastLength.Long).Show();

                                    listView.Adapter = new TaskAdapter(this, tasks);
                                }
                                catch (System.Exception ex)
                                {
                                    Toast.MakeText(this, "Произошла ошибка ", ToastLength.Long).Show();
                                }
                            }
                        }
                    }
                    catch
                    {
                        Toast.MakeText(this, "Произошла ошибка.", ToastLength.Long).Show();
                        return;
                    }
                });
                Dialog dialogEdit = builder.Create();
                dialogEdit.Show();
            });
            alert.SetPositiveButton("Удалить", (senderAlert, args) =>
            {
                AlertDialog.Builder alertConfirm = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alertConfirm.SetTitle("Подтверждение");
                alertConfirm.SetMessage($"Вы уверены, что хотите удалить задачу \"{tasks[e.Position].Description}\" ");
                alertConfirm.SetPositiveButton("Да", (senderAlert, args) =>
                {

                    try
                    {

                        string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskDelete";
                        using (var webClient = new WebClient())
                        {
                            var pars = new NameValueCollection();
                            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                            pars.Add("format", "json");
                            pars.Add("ID_Task", tasks[e.Position].ID_Task.ToString());
                            byte[] responsebytes = webClient.UploadValues(url, pars);
                            string responsebody = Encoding.UTF8.GetString(responsebytes);
                        }
                        Toast.MakeText(this, "Задача успешно удалена.", ToastLength.Long).Show();
                        tasks.Remove(tasks[e.Position]);

                        for (int i = 0; i < tasks.Count; i++)
                        {
                            tasks[i].NumberOfRows = i + 1;
                        }
                        listView.Adapter = new TaskAdapter(this, tasks);

                    }
                    catch (System.Exception ex)
                    {
                        Toast.MakeText(this, "Произошла ошибка ", ToastLength.Long).Show();
                    }
                });
                alertConfirm.SetNegativeButton("Нет", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialogConfirm = alertConfirm.Create();
                dialogConfirm.Show();
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void addTaskButton_Button(object sender, EventArgs e)
        {
            listView = FindViewById<ListView>(Resource.Id.tasksListView);
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            string Currentdate = prefs.GetString("CurrentDate", "");
            string ID_User = prefs.GetString("ID_User", "");
            DateTime currentTime = DateTime.Now;

            LayoutInflater inflater = LayoutInflater.From(this);
            View subView = inflater.Inflate(Resource.Layout.AddTaskDialog, null);
            EditText descriptionTaskText = (EditText)subView.FindViewById(Resource.Id.addTaskEditText);
            CheckBox deadlineCheckBox = (CheckBox)subView.FindViewById(Resource.Id.deadlineCheckbox);
            TimePicker deadlineTimePicker = (TimePicker)subView.FindViewById(Resource.Id.deadlineTimePicker);
            deadlineTimePicker.SetIs24HourView((Java.Lang.Boolean)true);

           /* currentTime.AddHours(1);
            deadlineTimePicker.Hour = currentTime.Hour;
            deadlineTimePicker.Minute = 00;*/
            
            bool checkedStatus = false;
            string descriptionText = "";
            DateTime time;

            AlertDialog.Builder builder = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
            builder.SetView(subView);
            builder.SetPositiveButton("ОК", (senderAlert, args) =>
            {
                if (string.IsNullOrWhiteSpace(descriptionTaskText.Text))
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                    alert.SetTitle("Ошибка");
                    alert.SetMessage("Введите описание задачи");
                    alert.SetNegativeButton("ОК", (senderAlert, args) =>
                    {
                        return;
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    return;
                }
                checkedStatus = deadlineCheckBox.Checked;
                descriptionText = descriptionTaskText.Text;
                string hour = (string)deadlineTimePicker.CurrentHour;
                string minute = (string)deadlineTimePicker.CurrentMinute;
                time = Convert.ToDateTime(hour + ":" + minute + ":00");
                string timeInTasks = "";


                // Защита от  повторяющихся задач
                string shortDate = Convert.ToDateTime(Currentdate).ToString("yyyy.MM.dd");
                try
                {
                    var url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskCheck";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");
                        pars.Add("Date", shortDate);
                        pars.Add("Description", descriptionText);
                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);
                        if (responsebody != "[]")
                        {
                            Toast.MakeText(this, "Введенная задача уже существует.", ToastLength.Long).Show();
                            return;
                        }
                    }
                }
                catch
                {
                    Toast.MakeText(this, "Произошла ошибка.", ToastLength.Long).Show();
                    return;
                }

                try
                {
                    var url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskAdd";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");
                        //pars.Add("User", ID_User.ToString());
                        pars.Add("Date", Currentdate);
                        pars.Add("DealStatus", "1");
                        pars.Add("Description", descriptionText);

                        if (checkedStatus == true)
                        {
                            pars.Add("DateDeadline", time.ToString("t"));
                            timeInTasks = time.ToString("t");
                        }
                        else if (checkedStatus == false)
                        {
                            pars.Add("DateDeadline", null);
                            timeInTasks = "---";
                        }
                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);
                        Toast.MakeText(this, "Задача успешно добавлена.", ToastLength.Long);

                        tasks.Add(new Tasks()
                        {
                            NumberOfRows = tasks.Count + 1,
                            Description = descriptionText,
                            DateDeadline = timeInTasks,
                            DealStatus = 1,
                        });
                        listView.Adapter = new TaskAdapter(this, tasks);
                    }
                }
                catch (System.Exception ex)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                    alert.SetTitle("Ошибка");
                    alert.SetMessage("Произошла ошибка.");
                    alert.SetNegativeButton("ОК", (senderAlert, args) =>
                    {
                        return;
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            });
            AlertDialog alertDialog = builder.Create();
            alertDialog.Show();
        }

        private void deadlineCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            LayoutInflater inflater = LayoutInflater.From(this);
            View subView = inflater.Inflate(Resource.Layout.AddTaskDialog, null);
            TimePicker deadlineTimePicker = (TimePicker)subView.FindViewById(Resource.Id.deadlineTimePicker);

            CheckBox deadlineCheckBox = (CheckBox)subView.FindViewById(Resource.Id.deadlineCheckbox);
            if (deadlineCheckBox.Checked == true)
            {
                deadlineTimePicker.Enabled = true;
            }

            if (deadlineCheckBox.Checked == false)
            {
                deadlineTimePicker.Enabled = false;
            }
        }
    }

    public class TaskAdapter : BaseAdapter<Tasks>
    {
        List<Tasks> items;
        Activity context;
        public TaskAdapter(Activity context, List<Tasks> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Tasks this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public bool isEnabled(int position)
        {
            return true;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;


            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout._items, null);
            view.FindViewById<TextView>(Resource.Id.nuberTaskText).Text = item.NumberOfRows.ToString();
            view.FindViewById<TextView>(Resource.Id.descriptionTaskText).Text = item.Description;
            if (item.DateDeadline != null)
            {
                view.FindViewById<TextView>(Resource.Id.deadlineText).Text = item.DateDeadline.ToString();
            }
            if (item.DealStatus == 2)
            {
                view.FindViewById<CheckBox>(Resource.Id.dealStatusCheckBox).Checked = true;
            }
            if (item.DealStatus == 1)
            {
                view.FindViewById<CheckBox>(Resource.Id.dealStatusCheckBox).Checked = false;
            }
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            CheckBox checkBox = view.FindViewById<CheckBox>(Resource.Id.dealStatusCheckBox);
            ListView list = view.FindViewById<ListView>(Resource.Id.tasksListView);


            checkBox.Click += (s, e) =>
            {
                try
                {
                    string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskUpdateStatus";
                    using (var webClient = new WebClient())
                    {
                        var pars = new NameValueCollection();
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                        pars.Add("format", "json");


                        pars.Add("ID_Task", item.ID_Task.ToString());
                        if (checkBox.Checked == true)
                        {
                            pars.Add("DealStatus", "2");
                            item.DealStatus = 2;
                        }
                        if (checkBox.Checked == false)
                        {
                            pars.Add("DealStatus", "1");
                            item.DealStatus = 1;
                        }

                        byte[] responsebytes = webClient.UploadValues(url, pars);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);


                    }

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(context, ex.Message, ToastLength.Long).Show();
                }
            };

            return view;
        }


        private void CheckBox_Click(object sender, EventArgs e)
        {

        }

    }

};




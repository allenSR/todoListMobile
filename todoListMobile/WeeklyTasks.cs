using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using TodoList;

namespace todoListMobile
{
    [Activity]
    class WeeklyTasks : Activity
    {
        ListView weeklyTasksListView;
        List<Tasks> tasks = new List<Tasks>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WeeklyTasks);

            DateWeek dateWeek = new DateWeek();
            dateWeek.FindDateOfWeek();
            string dateMonday = (dateWeek.monday + "." + dateWeek.year);
            string startDate = Convert.ToDateTime(dateMonday).ToString("O");

            string dateSunday = (dateWeek.sunday + "." + dateWeek.year);
            string endDate = Convert.ToDateTime(dateSunday).ToString("O");

            Toolbar toolbarWeeklyTasks = FindViewById<Toolbar>(Resource.Id.toolbarWeeklyTasks);
            toolbarWeeklyTasks.InflateMenu(Resource.Menu.myMenu);
            toolbarWeeklyTasks.MenuItemClick += ToolbarWeeklyTasks_MenuItemClick;
            weeklyTasksListView = FindViewById<ListView>(Resource.Id.weeklyTasksListView);
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            try
            {
                string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/LoadWeeklyTasks";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                    pars.Add("format", "json");
                    pars.Add("Date1", startDate);
                    pars.Add("Date2", endDate);
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
                        DateTime dayOfWeek = Convert.ToDateTime(a.Date);
                        DateTime day = dayOfWeek.AddDays(1);
                        string nameDay = day.ToString("ddd");
                        var status = a.DealStatus;

                        tasks.Add(new Tasks()
                        {
                            ID_Task = a.ID_Task,
                            User = a.User,
                            NumberOfRows = i + 1,
                            Description = a.Description,
                            Date = dayOfWeek.ToString("dd.MM"),
                            DealStatus = status,
                            nameDay = nameDay

                        });
                    }
                }
            }
            catch (System.Exception ex)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this, AlertDialog.ThemeHoloDark);
                alert.SetTitle("Ошибка");
                alert.SetMessage("Произошла ошибка");
                alert.SetNegativeButton("ОК", (senderAlert, args) =>
                {
                    return;
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }


            WeeklyTaskAdapter adapter = new WeeklyTaskAdapter(this, tasks);
            weeklyTasksListView.Adapter = adapter;
        }

        private void ToolbarWeeklyTasks_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class WeeklyTaskAdapter : BaseAdapter<Tasks>
    {
        List<Tasks> items;
        Activity context;
        public WeeklyTaskAdapter(Activity context, List<Tasks> items)
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
                view = context.LayoutInflater.Inflate(Resource.Layout._itemsWeeklyTasks, null);
            view.FindViewById<TextView>(Resource.Id.numberWeeklyTaskText).Text = item.NumberOfRows.ToString();
            view.FindViewById<TextView>(Resource.Id.descriptionWeeklyTaskText).Text = item.Description;
            view.FindViewById<TextView>(Resource.Id.dateWeeklyTaskText).Text = item.nameDay;

            if (item.DealStatus == 2)
            {
                view.FindViewById<CheckBox>(Resource.Id.statusWeeklyTaskText).Checked = true;
            }
            if (item.DealStatus == 1)
            {
                view.FindViewById<CheckBox>(Resource.Id.statusWeeklyTaskText).Checked = false;
            }
            // ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context); 

            return view;
        }
    }
}
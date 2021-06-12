using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
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
    [Activity]
    class AllTasks : Activity
    {
        ListView allTasksListView;
        List<Tasks> tasks = new List<Tasks>();
        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AllTasks);
            Toolbar toolbarAllTasks = FindViewById<Toolbar>(Resource.Id.toolbarAllTasks);
            toolbarAllTasks.InflateMenu(Resource.Menu.myMenu);
            toolbarAllTasks.MenuItemClick += ToolbarAllTasks_MenuItemClick;
            allTasksListView = FindViewById<ListView>(Resource.Id.allTasksListView);
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            try
            {
                string url = "http://" + prefs.GetString("addres", "") + ":" + prefs.GetString("port", "") + "/DailyTaskAll";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    webClient.Headers.Add("x-auth-token", prefs.GetString("ID_User", ""));
                    pars.Add("format", "json");
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
                alert.SetMessage(ex.Message);
                alert.SetNegativeButton("ОК", (senderAlert, args) => {
                    return;
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }


            AllTaskAdapter adapter = new AllTaskAdapter(this, tasks);
            allTasksListView.Adapter = adapter;
        }

        private void ToolbarAllTasks_MenuItemClick(object sender, Toolbar.MenuItemClickEventArgs e)
        {
            if (e.Item.TitleFormatted.ToString() == "Настройки")
            {
                Intent intent = new Intent(this, typeof(Settings));
                StartActivity(intent);
            }
        }
    }

    public class AllTaskAdapter : BaseAdapter<Tasks>
    {
        List<Tasks> items;
        Activity context;
        public AllTaskAdapter(Activity context, List<Tasks> items)
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

            DateTime dt = Convert.ToDateTime(item.Date);
            
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout._itemsAllTasks, null);
            view.FindViewById<TextView>(Resource.Id.numberOfAllTaskText).Text = item.NumberOfRows.ToString();
            view.FindViewById<TextView>(Resource.Id.descriptionAllTaskText).Text = item.Description;
            view.FindViewById<TextView>(Resource.Id.dateAllTaskText).Text = dt.ToString("dd.MM");
           
            if (item.DealStatus == 2)
            {
                view.FindViewById<CheckBox>(Resource.Id.statusAllTaskText).Checked = true;
            }
            if (item.DealStatus == 1)
            {
                view.FindViewById<CheckBox>(Resource.Id.statusAllTaskText).Checked = false;
            }
           // ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context); 

            return view;
        }
    }
}
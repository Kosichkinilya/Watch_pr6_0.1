namespace Watch_pr6_kosichkin_0._1;

public partial class NewPage1 : ContentPage
{
   
    public NewPage1()
    {
        InitializeComponent();
    }


     private void OnSetAlarmClicked(object sender, EventArgs e)
    {
        DateTime nowDay = DateTime.Now;
        TimeSpan nowTime = new TimeSpan(nowDay.Hour, nowDay.Minute, nowDay.Second);
        TimeSpan selectedTime = alarmTimePicker.Time;
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _time = alarmTimePicker.Time;
        _timer.Start();
        //Device.StartTimer(selectedTime, () =>
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        alarmStatusLabel.Text = "Alarm Triggered!";
        //    });
        //    return false;
        //});
        alarmStatusLabel.Text = $"Будильник установлен на: {selectedTime}";
    }
    TimeSpan _time;
    IDispatcherTimer _timer;

    private void Timer_Tick(object sender, EventArgs e)
    {
        DateTime nowDay = DateTime.Now;
        TimeSpan nowTime = new TimeSpan(nowDay.Hour, nowDay.Minute, nowDay.Second);
        if (_time.CompareTo(nowTime) <= 0)
        {
            if (swMonday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Monday ||
                swTuesday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Tuesday ||
                swWednesday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Wednesday ||
                swThursday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Thursday ||
                swFriday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Friday ||
                swSaturday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Saturday ||
                swSunday.IsToggled == true && nowDay.DayOfWeek == DayOfWeek.Sunday)
            {
                DisplayAlert("Внимание", "Просыпайтесь", "Отмена");
                _timer.Stop();
            }
        }
        //if (_time.Minutes == DateTime.Now.Minute&& _time.Hours == DateTime.Now.Hour) 
        //{
        //    alarmStatusLabel.Text = "Вставай ержан на работу пора!";
        //    _timer.Stop();
        //}


    }


}


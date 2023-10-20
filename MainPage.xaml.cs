namespace Watch_pr6_kosichkin_0._1;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        UpdateTime();
    }

    private void UpdateTime()
    {
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            });

            return true;
        });
    }
}








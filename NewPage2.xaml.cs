namespace Watch_pr6_kosichkin_0._1;

public partial class NewPage2 : ContentPage
{


    private TimeSpan currentTime;
    private bool isTimerRunning;

    public NewPage2()
    {
        InitializeComponent();
    }

    private async void StartButton_Clicked(object sender, EventArgs e)
    {
        if (!isTimerRunning)
        {
            isTimerRunning = true;
            startButton.IsEnabled = false;
            stopButton.IsEnabled = true;

            while (isTimerRunning)
            {
                currentTime = currentTime.Add(TimeSpan.FromSeconds(1));
                timerLabel.Text = currentTime.ToString(@"hh\:mm\:ss");
                await Task.Delay(1000);
            }
        }
    }

    private void StopButton_Clicked(object sender, EventArgs e)
    {
        isTimerRunning = false;
        startButton.IsEnabled = true;
        stopButton.IsEnabled = false;
    }
    
    private void Stop_sec(object sender, EventArgs e) // кнопка "—брос" работает 1 раз, повторно секундомер не сбрасываетс€
    {
        isTimerRunning = false;
        currentTime = TimeSpan.Zero;
        timerLabel.Text = "00:00:00";
        startButton.IsEnabled = true;
        stopButton.IsEnabled = false;
        resetButton.IsEnabled = false;
    }
}
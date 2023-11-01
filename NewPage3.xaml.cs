using System.Threading;

namespace Watch_pr6_kosichkin_0._1;

public partial class NewPage3 : ContentPage
{
    private int totalTimeInSeconds = 60; // Время в секундах
    private bool isTimerRunning = false;
    private CancellationTokenSource cancellationTokenSource;


    public NewPage3()
    {
        InitializeComponent();
    }
    private async void StartTimer(object sender, EventArgs e)
    {
        if (!isTimerRunning)
        {
            isTimerRunning = true;
            startButton.IsEnabled = false;
            stopButton.IsEnabled = true;

            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            for (int remainingSeconds = totalTimeInSeconds; remainingSeconds >= 0; remainingSeconds--)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
                timerLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
                await Task.Delay(1000); // Подождать 1 секунду
            }

            isTimerRunning = false;
            startButton.IsEnabled = true;
            stopButton.IsEnabled = false;
            timerLabel.Text = "00:00:00";
        }
    }
    private void StopTimer(object sender, EventArgs e)
    {
        if (isTimerRunning)
        {
            isTimerRunning = false;
            cancellationTokenSource.Cancel();
            startButton.IsEnabled = true;
            stopButton.IsEnabled = false;
        }
    }
}

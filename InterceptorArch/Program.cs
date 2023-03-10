using InterceptorArch;


//Concrete Framework
public class CdPlayer : IPushCallBack
{
    public Button _playButton;
    public Button _stopButton;
    public void NotifyButtonPushed(Button b)
    {
        if (b == _playButton)
        {
            PlayButtonPushed(b);
        }
        if (b == _stopButton)
        {
            StopButtonPushed(b);
        }
    }
    public void SetPlayButton(Button b)
    {
        _playButton = b;
    }

    public void SetStopButton(Button b)
    {
        _stopButton = b;
    }
    public void PlayButtonPushed(Button b)
    {
        Console.WriteLine("Play button pushed");
    }
    public void StopButtonPushed(Button b)
    {
        Console.WriteLine("Stop button pushed");
    }
}

//Application
public class Program
{
    static void Main(string[] args)
    {
        CdPlayer cdPlayer = new CdPlayer();
        var fileLoggerInterceptor = new FileLoggerInterceptor();

        Dispatcher dispatcher = new Dispatcher();
        dispatcher.Detach(fileLoggerInterceptor);
        Button playButton = new Button(dispatcher, cdPlayer, "play");
        Button stopButton = new Button(dispatcher, cdPlayer, "stop");
        cdPlayer.SetPlayButton(playButton);
        cdPlayer.SetStopButton(stopButton);
        playButton.Push();
        stopButton.Push();
        dispatcher.Detach(fileLoggerInterceptor);
    }
}

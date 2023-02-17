public interface IPushCallBack
{
    void NotifyButtonPushed(Button b);
}

public class Button
{
    private IPushCallBack _iPushCallBack;
    public Button(IPushCallBack ipcb)
    {
        _iPushCallBack = ipcb;
    }
    public void Push()
    {
        _iPushCallBack.NotifyButtonPushed(this);
    }
}

public class CdPlayer : IPushCallBack
{
    private Button _playButton;
    private Button _stopButton;
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

public class Program
{
    static void Main(string[] args)
    {
        CdPlayer cdPlayer = new CdPlayer();
        Button playButton = new Button(cdPlayer);
        Button stopButton = new Button(cdPlayer);
        cdPlayer.SetPlayButton(playButton);
        cdPlayer.SetStopButton(stopButton);
        playButton.Push();
        stopButton.Push();
    }
}

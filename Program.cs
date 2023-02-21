using InterceptorArch;

//public interface IPushCallBack
//{
//    void NotifyButtonPushed(Button b);
//}


//Concrete Framework
public class CdPlayer //: IPushCallBack
{
    public Button playButton;
    public Button stopButton;

    //Possible interception point
    //public void NotifyButtonPushed(Button b)
    //{
    //    if (b == _playButton)
    //    {
    //        PlayButtonPushed(b);
    //    }
    //    if (b == _stopButton)
    //    {
    //        StopButtonPushed(b);
    //    }
    //}
    //public void SetPlayButton(Button b)
    //{
    //    _playButton = b;
    //}
    //public void SetStopButton(Button b)
    //{
    //    _stopButton = b;
    //}
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
        var cdPlayerInterceptor = new CdPlayerInterceptor();
        var dispatcher = new Dispatcher(new List<IInterceptor> { cdPlayerInterceptor });
        Button playButton = new Button(dispatcher, cdPlayer);
        Button stopButton = new Button(dispatcher, cdPlayer);
        cdPlayer.playButton = playButton;
        cdPlayer.stopButton = stopButton;
        playButton.Push();
        stopButton.Push();
    }
}

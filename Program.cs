using InterceptorArch;

public interface IPushCallBack
{
    void NotifyButtonPushed(Button b);
}

public class Button
{
    //private IPushCallBack _iPushCallBack;
    //public Button(IPushCallBack ipcb)
    //{
    //    _iPushCallBack = ipcb;
    //}
    //public void Push()
    //{
    //    _iPushCallBack.NotifyButtonPushed(this);
    //}
    private Dispatcher _dispatcher;
    private CdPlayer _player;
    public Button(Dispatcher dispatcher, CdPlayer player)
    {
        _dispatcher = dispatcher;
        _player = player;
    }

    public CdPlayer getCdPlayer() { 
        return _player;
    }

    public void Push()
    {
        var context = new ButtonContext { button = this };
        _dispatcher.Dispatch(context);
    }
}
public class ButtonContext : IContext
{
    public Button button { get; set; }
    public void controlCdPlayer() {
        CdPlayer cdPlayer = this.button.getCdPlayer();
        if (button == cdPlayer.playButton)
        {
            cdPlayer.PlayButtonPushed(button);
        }
        else if (button == cdPlayer.stopButton)
        {
            cdPlayer.StopButtonPushed(button);
        }
    }
}
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorArch
{
    public interface IPushCallBack
    {
        void NotifyButtonPushed(Button b);
    }
    public class ButtonContext: IContext
    {
        public Button button { get; set; }
        public void notifyButtonPushed()
        {
            IPushCallBack cdPlayer = this.button.getCdPlayer();
            cdPlayer.NotifyButtonPushed(button);
            //if (button == cdPlayer.playButton)
            //{
            //    cdPlayer.PlayButtonPushed(button);
            //}
            //else if (button == cdPlayer.stopButton)
            //{
            //    cdPlayer.StopButtonPushed(button);
            //}
        }
    }
    public class Button
    {
        private IPushCallBack _iPushCallBack;
        private string _name;
        public Button(IPushCallBack ipcb)
        {
            _iPushCallBack = ipcb;
        }
        private Dispatcher _dispatcher;
        //private CdPlayer _player;// bad practice remove this dependency
        public Button(Dispatcher dispatcher, IPushCallBack ipcb, string name)
        {
            _dispatcher = dispatcher;
            _iPushCallBack = ipcb;
            _name = name;
        }

        public IPushCallBack getCdPlayer()
        {
            return _iPushCallBack;
        }
        public string getName()
        {
            return this._name;
        }
        public void Push()
        {
            _iPushCallBack.NotifyButtonPushed(this);
            var context = new ButtonContext { button = this };
            _dispatcher.Dispatch(context);
        }
    }
}

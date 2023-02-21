using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorArch
{
    public class ButtonContext: IContext
    {
        public Button button { get; set; }
        public void notifyButtonPushed()
        {
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

        public CdPlayer getCdPlayer()
        {
            return _player;
        }

        public void Push()
        {
            var context = new ButtonContext { button = this };
            _dispatcher.Dispatch(context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Windows;

namespace FilterWPF
{
    public class DelayAction : IDisposable
    {
        private Timer timer;

        public static DelayAction Initialize(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("DeferredAction Initialize NULL excpetion");
            }

            return new DelayAction(action);
        }

        private DelayAction(Action action)
        {
            this.timer = new Timer(new TimerCallback(delegate
            {
                Application.Current.Dispatcher.Invoke(action);
            }));
        }

        public void Wait(TimeSpan delay)
        {
            this.timer.Change(delay, TimeSpan.FromMilliseconds(-1));
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
                this.timer = null;
            }
        }

        #endregion
    }
}

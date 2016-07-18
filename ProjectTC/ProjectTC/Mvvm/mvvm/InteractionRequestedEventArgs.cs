using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
    public class InteractionRequestedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of <see cref="InteractionRequestedEventArgs"/>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        public InteractionRequestedEventArgs(INotification context, Action callback)
        {
            this.Context = context;
            this.Callback = callback;
        }

        /// <summary>
        /// Gets the context for a requested interaction.
        /// </summary>
        public INotification Context { get; private set; }

        /// <summary>
        /// Gets the callback to execute when an interaction is completed.
        /// </summary>
        public Action Callback { get; private set; }
    }
}

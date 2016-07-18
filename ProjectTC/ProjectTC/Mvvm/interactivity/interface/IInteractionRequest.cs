using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
    public interface IInteractionRequest
    {
        /// <summary>
        /// Fired when the interaction is needed.
        /// </summary>
        event EventHandler<InteractionRequestedEventArgs> Raised;
    }
}

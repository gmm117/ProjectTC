using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
    public interface INotification
    {
        /// <summary>
        /// Gets or sets the title to use for the notification.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the notification.
        /// </summary>
        object Content { get; set; }
    }
}

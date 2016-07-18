using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace Mvvm
{
    public class InteractionRequestTrigger : System.Windows.Interactivity.EventTrigger
    {
        private object sourceObject = null;

        /// <summary>
        /// Specifies the name of the Event this EventTriggerBase is listening for.
        /// </summary>
        /// <returns>This implementation always returns the Raised event name for ease of connection with <see cref="IInteractionRequest"/>.</returns>
        protected override string GetEventName()
        {
            return "Raised";
        }

        /// <summary>
        /// Called after the trigger is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            FrameworkElement element = this.AssociatedObject as FrameworkElement;
            if (element != null)
            {
                element.Loaded += AssociatedObject_Loaded;
                element.Unloaded += AssociatedObject_Unloaded;
            }
        }

        /// <summary>
        /// Called when the trigger is being dettached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            FrameworkElement element = this.AssociatedObject as FrameworkElement;
            if (element != null)
            {
                element.Loaded -= AssociatedObject_Loaded;
                element.Unloaded -= AssociatedObject_Unloaded;
            }
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            this.sourceObject = this.SourceObject;
            this.SourceObject = null;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.SourceObject == null && this.sourceObject != null)
            {
                this.SourceObject = this.sourceObject;
            }
        }
    }
}

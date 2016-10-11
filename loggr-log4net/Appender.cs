using System.Web;

namespace Loggr.Log4Net
{
    public class Appender : log4net.Appender.AppenderSkeleton
    {
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            Loggr.FluentEvent ev = null;
            ev = loggingEvent.ExceptionObject != null ? Loggr.Events.CreateFromException(loggingEvent.ExceptionObject) : Loggr.Events.Create();
            ev.Text( loggingEvent.Level.DisplayName )
                .Data(loggingEvent.RenderedMessage)
                .Tags(loggingEvent.Level.ToString())
                .User(loggingEvent.UserName);
            ev.Post();
        }
    }
}

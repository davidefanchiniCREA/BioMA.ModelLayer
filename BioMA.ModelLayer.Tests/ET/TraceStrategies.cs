using System;
using System.Collections.Generic;
using System.Text;

namespace CRA.Clima
{
    internal static class TraceStrategies
    {
        static private System.Diagnostics.TraceSource Source = new System.Diagnostics.TraceSource(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

        /// <summary>
        ///     Writes a trace event message to the trace listeners in the System.Diagnostics.TraceSource.Listeners
        ///     collection using the specified event type, event identifier, and message.
        /// </summary>
        /// <param Name="eventType">one of the System.Diagnostics.TraceEventType values that specifies the event type of the trace data</param>
        /// <param Name="id">a numeric identifier for the event</param>
        /// <param Name="message">the trace message to write</param>
        [System.Diagnostics.Conditional("TRACE")]
        static public void TraceEvent(System.Diagnostics.TraceEventType eventType, int id, string message) { Source.TraceEvent(eventType, id, message); Source.Flush(); }
    }
}
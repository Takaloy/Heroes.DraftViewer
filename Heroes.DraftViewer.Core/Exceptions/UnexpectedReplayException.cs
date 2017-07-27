using System;
using System.Runtime.Serialization;

namespace Heroes.DraftViewer.Core
{
    [Serializable]
    public class UnexpectedReplayException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public UnexpectedReplayException()
        {
        }

        public UnexpectedReplayException(string message) : base(message)
        {
        }

        public UnexpectedReplayException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UnexpectedReplayException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
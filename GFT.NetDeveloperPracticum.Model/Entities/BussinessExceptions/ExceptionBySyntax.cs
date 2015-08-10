using System;

namespace GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions
{
    public class ExceptionBySyntax : Exception
    {
        /// <summary>
        /// Exception created for syntax error
        /// </summary>
        /// <param name="message"></param>
        public ExceptionBySyntax(string message)
            : base(message)
        {            
        }
    }
}

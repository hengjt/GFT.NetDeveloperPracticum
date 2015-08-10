using System;

namespace GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions
{
   public class ExceptionGeneric :  Exception
    {
       /// <summary>
        /// Exception created for generic error
       /// </summary>
       /// <param name="message"></param>
       public ExceptionGeneric(string message)
           : base(message)
       {

       }
    }
}

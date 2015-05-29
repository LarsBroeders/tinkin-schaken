using System;


namespace TINKIN01.Chess
{
    public class MoveEventArgs : EventArgs
    {
        /// <summary>
        /// The entered move
        /// </summary>
        public Move EnteredMove { get; set; }
    }

}

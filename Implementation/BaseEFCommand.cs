using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Implementation
{
    public class BaseEFCommand
    {
        protected AIContext AiContext { get; }
        protected BaseEFCommand(AIContext context)
        {
            AiContext = context;
        }
		
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Core.Exceptions
{
    public class ProjectAlreadyStartedException : Exception
    {
        public ProjectAlreadyStartedException() : base("Project is already in Started status") // ao utilizar o "base", estamos chamando o comportamento padrão do tipo da classe (Exeption)
        {

        }
    }
}

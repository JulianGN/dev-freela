using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Core.Entities
{
    // essa é uma classe abstrata, ou seja, não podemos instancia-la diretamente, contendo informações que serão utilizadas em diferentes classes. 
    public abstract class BaseEntity
    {
        protected BaseEntity() { } // construtor criado para dar suporte ao EntityFrameworkCore
        public int Id { get; private set; } // Para evitar redundância, já que diversas classes terão um Id, criamos na base
    }
}

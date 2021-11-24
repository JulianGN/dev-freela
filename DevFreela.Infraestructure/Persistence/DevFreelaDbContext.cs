using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Infraestructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 30000),
            };

            Users = new List<User>
            {
                new User("Julian Nunes", "contato@juliannunes.com.br", new DateTime(1989, 4, 7)),
                new User("Gabriela Nunes", "gabi@juliannunes.com.br", new DateTime(1992, 4, 7)),
                new User("Pessoa de Teste", "teste@juliannunes.com.br", new DateTime(2000, 4, 7)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}

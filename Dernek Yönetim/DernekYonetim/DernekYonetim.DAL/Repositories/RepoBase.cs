using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Repositories
{
    public abstract class RepoBase
    {
        protected string ConnectionString { get { return "Server= ; Database= DernekYonetimDb; Integrated Security = true;"; } }
        protected AdoProvider provider;
        public RepoBase()
        {
            this.provider = new AdoProvider(this.ConnectionString);
        }
    }
}

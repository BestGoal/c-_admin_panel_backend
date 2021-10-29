using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace Domain
{
    class DbContextFactory: IDbContextFactory<DbContextImpl>
    {

        DbContextImpl IDbContextFactory<DbContextImpl>.Create()
        {
            return new DbContextImpl("Data Source=DESKTOP-0UVE23V;Initial Catalog=cdcdblast; User Id=sa;Password=P@ssw0rd");
        }
    }
}

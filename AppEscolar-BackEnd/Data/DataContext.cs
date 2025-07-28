using Microsoft.EntityFrameworkCore;

namespace AppEscolar_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base( options ) 
        { 

        }
    }
}

namespace CarWash.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarWashContext : DbContext
    {
        // Your context has been configured to use a 'CarWashContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CarWash.Models.Database.CarWashContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CarWashContext' 
        // connection string in the application configuration file.
        public CarWashContext()
            : base("name=CarWashContext")
        {
        }

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<DataModels.User> Users { get; set; }
        public virtual DbSet<DataModels.Statistic> Statistics { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
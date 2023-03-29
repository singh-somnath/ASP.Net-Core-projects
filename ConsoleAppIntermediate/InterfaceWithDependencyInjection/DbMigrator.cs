using System;

namespace ConsoleAppIntermediate.InterfaceWithDependencyInjection
{
    public class DbMigrator
    {
        private readonly ILoger _loger;
        public DbMigrator(ILoger loger)
        {
            _loger = loger;
        }
        public void Migration()
        {
            _loger.LogError("Migration Started at " + DateTime.Now);
            _loger.LogInfo("Migration Finished at " + DateTime.Now);
        }
    }
}
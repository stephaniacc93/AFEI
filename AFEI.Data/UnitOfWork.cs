using System;
using System.ComponentModel.DataAnnotations.Schema;
using AFEI.Data.Repositories;
using AFEI.Models;

namespace AFEI.Data
{
    [NotMapped]
    public class UnitOfWork : IDisposable
    {
        public AFEIEntities Context { get; set; }

        #region<--Repositories-->

        public GenericRepository<Client> ClientRepository { get; set; }
        public GenericRepository<Price> PriceRepository { get; set; }
        public GenericRepository<Product> ProductRepository { get; set; }
        public GenericRepository<Provider> ProviderRepository { get; set; }
        public GenericRepository<Transaction> TransactionRepository { get; set; }
        public GenericRepository<ChangesLog> ChangesLogRepository { get; set; }
        public GenericRepository<User> UserRepository { get; set; }
        public GenericRepository<History> HistoryRepository { get; set; }

        #endregion

        public Guid Version { get; private set; }


        public UnitOfWork()
        {
            Context = new AFEIEntities();
            Version = Guid.NewGuid();
            InitializeRepositories(Context);
        }

        private void InitializeRepositories(AFEIEntities context)
        {
            ClientRepository = new GenericRepository<Client>(context);
            PriceRepository = new GenericRepository<Price>(context);
            ProductRepository = new GenericRepository<Product>(context);
            ProviderRepository = new GenericRepository<Provider>(context);
            TransactionRepository = new GenericRepository<Transaction>(context);
            ChangesLogRepository = new GenericRepository<ChangesLog>(context);
            UserRepository = new GenericRepository<User>(context);
            HistoryRepository = new GenericRepository<History>(context);
        }

        public void CommitChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Odasoft.DataProvider.Repositories;

namespace EZPark.Data
{
    [NotMapped]
    public class UnitOfWork : IDisposable
    {
        //public EZParkDbContext Context { get; set; }

        #region<--Repositories-->
        //public GenericRepository<Ad> AdRepository { get; set; }
        //public GenericRepository<Payment> BillRepository { get; set; }
        //public GenericRepository<Mall> MallRepository { get; set; }
        //public GenericRepository<MallAd> MallAdRepository { get; set; }
        //public GenericRepository<Store> StoreRepository { get; set; }
        //public GenericRepository<StoreAd> StoreAdRepository { get; set; }
        //public GenericRepository<Ticket> TicketRepository { get; set; }
        //public GenericRepository<User> UserRepository { get; set; }

        #endregion

        public Guid Version { get; private set; }


        public UnitOfWork()
        {
            //Context = new EZParkDbContext();
            //Version = Guid.NewGuid();
            //InitializeRepositories(Context);
        }

        //private void InitializeRepositories(EZParkDbContext context)
        //{
        //    AdRepository = new GenericRepository<Ad>(context);
        //    BillRepository = new GenericRepository<Payment>(context);
        //    MallRepository = new GenericRepository<Mall>(context);
        //    MallAdRepository = new GenericRepository<MallAd>(context);
        //    StoreRepository = new GenericRepository<Store>(context);
        //    StoreAdRepository = new GenericRepository<StoreAd>(context);
        //    TicketRepository = new GenericRepository<Ticket>(context);
        //    UserRepository = new GenericRepository<User>(context);
        //}

        //public void CommitChanges()
        //{
        //    Context.SaveChanges();
        //}

        public void Dispose()
        {

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class HistoryPersistence
    {

        public History Create(History entity)
        {
            History response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    entity.User = AFEIEntities.Users.First(x => x.Id == entity.User.Id);
                    entity.Transaction = AFEIEntities.Transactions.First(x => x.Id == entity.User.Id);
                    entity.Provider = AFEIEntities.Providers.First(x => x.Id == entity.User.Id);
                    entity.Product = AFEIEntities.Products.First(x => x.Id == entity.User.Id);
                    AFEIEntities.Histories.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Histories.Single(x => x.Id == entity.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public History Read(int entityId)
        {
            History response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Histories
                        .Include("Product").Include("Provider").Include("Transaction").Include("User")
                        .Single(x => x.Id == entityId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public History Update(History entity)
        {
            History response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new History() { Id = entity.Id };
                    stub.TransactionAmount = entity.TransactionAmount;
                    stub.Date = entity.Date;
                    stub.Balance = entity.Balance;
                    stub.Justification = entity.Justification;
                    stub.Product = entity.Product;
                    stub.Provider = entity.Provider;
                    stub.Transaction = entity.Transaction;
                    stub.User = entity.User;
                    AFEIEntities.SaveChanges();

                    var history = AFEIEntities.Histories
                        .Include("Product").Include("Provider").Include("Transaction").Include("User");

                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Histories.Single(x => x.Id == entity.Id);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }


        public int Delete(int entityId)
        {
            int response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    var price = GetList().FirstOrDefault(x => x.Id == entityId);
                    var documentTypeToDelete = AFEIentities.Histories
                        .Include("Product").Include("Provider").Include("Transaction").Include("User").Single(x => x.Id == entityId);
                    AFEIentities.Histories.DeleteObject(documentTypeToDelete);
                    AFEIentities.SaveChanges();
                    response = entityId;

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public List<History> GetList()
        {
            List<History> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Histories
                        .Include("Product").Include("Provider").Include("Transaction").Include("User").ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
    }
}
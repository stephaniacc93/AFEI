using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class ChangesLogPersistence
    {
        public ChangesLog Create(ChangesLog entity)
        {
            ChangesLog response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    entity.User = AFEIEntities.Users.FirstOrDefault(x => x.Id == entity.User.Id);
                    AFEIEntities.ChangesLogs.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.ChangesLogs.Single(x => x.Id == entity.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public ChangesLog Read(int entityId)
        {
            ChangesLog response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.ChangesLogs
                        .Include("User")
                        .Single(x => x.Id == entityId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public ChangesLog Update(ChangesLog entity)
        {
            ChangesLog response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new ChangesLog() { Id = entity.Id };
                    stub.Module = entity.Module;
                    stub.Description = entity.Description;
                    stub.Date = entity.Date;
                    stub.User = entity.User;
                    AFEIEntities.SaveChanges();

                    var changes = AFEIEntities.Clients
                        .Include("User");

                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.ChangesLogs.Single(x => x.Id == entity.Id);

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
                    var client = GetList().FirstOrDefault(x => x.Id == entityId);
                    var documentTypeToDelete = AFEIentities.ChangesLogs
                        .Include("User").Single(x => x.Id == entityId);
                    AFEIentities.ChangesLogs.DeleteObject(documentTypeToDelete);
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

        public List<ChangesLog> GetList()
        {
            List<ChangesLog> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.ChangesLogs
                        .Include("User").ToList();
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

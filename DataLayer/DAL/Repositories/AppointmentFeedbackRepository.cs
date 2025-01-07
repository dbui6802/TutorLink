using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL.Repositories
{
    public class AppointmentFeedbackRepository : GenericRepository<AppointmentFeedback>
    {
        public AppointmentFeedbackRepository(TutorDbContext context) : base(context) { }

        

        public IEnumerable<AppointmentFeedback> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                throw new Exception($"Error retrieving all Appointments: {ex.Message}", ex);
            }
        }

        public IEnumerable<AppointmentFeedback> GetAppointmentsByAccountId(Guid accountId)
        {
            return _dbSet.Where(a => a.AccountId == accountId).ToList();
        }

        public IEnumerable<AppointmentFeedback> GetAppointmentsByTutorId(Guid tutorId)
        {
            return _dbSet.Where(a => a.TutorId == tutorId).ToList();
        }
    }

}

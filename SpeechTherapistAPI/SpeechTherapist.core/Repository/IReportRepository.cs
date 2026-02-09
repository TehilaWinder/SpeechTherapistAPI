using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Repository
{
    public interface IReportRepository
    {
        public Task<IEnumerable<Report>> GetReportsByPatientAsync(int patientId);
        public Task<IEnumerable<Report>> GetReportsBySpeechTherapistAsync(int speechTherapist);
        public Task<Report> GetByIdAsync(int id);
        public void AddReport(Report report);
        public Task UpdateVisibilityAsync(int reportId, bool isApproved);
        public Task SaveAsync();



    }
}

using Microsoft.EntityFrameworkCore;
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Data.Repositories
{
    public class ReportRepository:IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        // שליפת כל הדוחות של מטופל ספציפי
        public async Task<IEnumerable<Report>> GetReportsByPatientAsync(int patientId)
        {
            var r = await _context.reports.Where(r => r.PatientCode == patientId).OrderByDescending(r => r.CreatedAt).ToListAsync();
            return r;

        }
        public async Task<IEnumerable<Report>> GetReportsBySpeechTherapistAsync(int speechTherapist)
        {
            var r = await _context.reports.Where(r => r.SpeechTherapistCode == speechTherapist).OrderByDescending(r => r.CreatedAt).ToListAsync();
            return r;

        }
        public async Task<Report> GetByIdAsync(int id)
        {
            var r = await _context.reports.FirstOrDefaultAsync(x => x.ReportCode == id);
            return r;
        }

        // הוספת דוח חדש
        public  void AddReport(Report report)
        {
            _context.reports.Add(report);
        }

        // עדכון סטטוס חשיפה למטופל
        public async Task UpdateVisibilityAsync(int reportId, bool isApproved)
        {
            var report = await GetByIdAsync(reportId);

            report.IsApprovedByTherapist = isApproved;
            
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

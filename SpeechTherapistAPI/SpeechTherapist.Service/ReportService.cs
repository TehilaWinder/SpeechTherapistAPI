using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using SpeechTherapist.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SpeechTherapist.Service
{
    public class ReportService:IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // לוגיקה ליצירת דוח חדש (כולל הכנה ל-Google Docs)
        public async Task AddReportAsync(Report report)
        {
            // כאן בעתיד תבוא הקריאה ל-Google API:
            // string googleUrl = await _googleDocsService.CreateDoc(patientName);
            string googleUrl = "https://docs.google.com/document/d/example";

            var newReport = new Report
            {
                PatientCode = report.PatientCode,
                SpeechTherapistCode = report.SpeechTherapistCode,
                GoogleDocUrl = googleUrl,
                CreatedAt = DateTime.Now,
                IsApprovedByTherapist = false // דוח חדש תמיד מתחיל כטיוטה
            };
            _reportRepository.AddReport(newReport);
            await _reportRepository.SaveAsync();  
            
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _reportRepository.GetByIdAsync(id);    
        }

        // שליפת דוחות עבור המטופל (רק מה שמאושר!)
        public async Task<IEnumerable<Report>> GetReportsByPatientAsync(int patientId)
        {
            return await GetReportsByPatientAsync(patientId);
        }
        public async Task<IEnumerable<Report>> GetReportsBySpeechTherapistAsync(int speechTherapist)
        {
           return await GetReportsBySpeechTherapistAsync(speechTherapist);
        }

        // אישור דוח ע"י הקלינאית
        public async Task UpdateVisibilityAsync(int reportId, bool isApproved)
        {
           await _reportRepository.UpdateVisibilityAsync(reportId, isApproved);
            await _reportRepository.SaveAsync();
        }

        
    }
}
using SpeechTherapist.Core.Entities;
using SpeechTherapist.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Data
{
    public class TreatmentRepository : ITreatmentsRepository
    {
        private readonly DataContext _context;
        public TreatmentRepository(DataContext context)
        {
            _context = context;
        }
        public List<Treatments> GetAll()
        {
            return _context.treatments.ToList();
        }
        public Treatments GetById(int id)
        {
            var t = _context.treatments.ToList().Find(x => x.TreatmentCode == id);
            return t;
        }
        public void Add(Treatments treatment)
        {
            _context.treatments.Add(treatment);
        }
        
        public void Update(int id,Treatments treatments)
        {
            var t= GetById(id);
            t.TreatmentName = treatments.TreatmentName;
            t.DurationMinutes = treatments.DurationMinutes;
        }

        public void Delete(int id)
        {
            _context.treatments.Remove(GetById(id));    
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}

using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Repository
{
    public interface ITreatmentsRepository
    {
        public List<Treatments> GetAll();
        public Treatments GetById(int id);
        public void Add(Treatments treatments);
    }
}

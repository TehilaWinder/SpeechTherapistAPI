using SpeechTherapist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapist.Core.Service
{
    public interface ITreatmentsServie
    {
        public List<Treatments> GetAll();
        public Treatments GetById(int id);
        public void Add(Treatments treatments);
        public void Update(int id,Treatments treatments);
        public void Delete(int id);

    }
}

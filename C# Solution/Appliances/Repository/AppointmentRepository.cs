using Appliances.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appliances.Repository
{
    public interface AppointmentRepository
    {
        bool add(Appointment appointment);
        ICollection<Appointment> findByEngineer(int id);
    }
}

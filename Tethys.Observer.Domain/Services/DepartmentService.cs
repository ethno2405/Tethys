﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Services
{
    public class DepartmentService : BaseService
    {
        public DepartmentService(TethysContext context)
            : base(context)
        {
        }

        public void AssignRoom(Department department, Room room)
        {
            if (department == null) throw new ArgumentNullException("department");
            if (room == null) throw new ArgumentNullException("room");

            var existingDepartment = Context.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (existingDepartment == null)
            {
                throw new InvalidOperationException(string.Format("Department with id {0} does not exist", department.Id));
            }

            if (room.Id == Guid.Empty)
            {
                room.Id = Guid.NewGuid();
            }

            if (existingDepartment.Rooms.Any(x => x.Name == room.Name))
            {
                throw new InvalidOperationException(string.Format("Room {0} is already assigned to department {1}", room.Name, existingDepartment.Name));
            }

            existingDepartment.Rooms.Add(room);
            Context.SaveChanges();
        }

        public void Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            Context.Departments.Add(department);
            Context.SaveChanges();
        }
    }
}
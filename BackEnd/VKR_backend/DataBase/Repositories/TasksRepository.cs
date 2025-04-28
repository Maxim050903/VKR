using Api.Interfaces.Repositories;
using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Core.Types.Types;

namespace DataBase.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly VKRDBContext _context;

        public TasksRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddTask(_Task task)
        {
            var taskEntity = new _TaskEntity
            {
                Id = task.Id,
                Name = task.Name,
                IdBoss = task.IdBoss,
                IdAgragete = task.IdAgragete,
                Type = task.Type,
                idUorD = task.idUorD
            };

            await _context.Tasks.AddAsync(taskEntity);

            await _context.SaveChangesAsync();

            return taskEntity.Id;
        }

        public async Task<Guid> DeleteTask(Guid id)
        {
            await _context.Tasks.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> UpdateTask(Guid Id, string Name, Guid IdBoss, Guid IdAgragete, TaskType type, Guid IdUorD)
        {
            await _context.Tasks
                .Where(x => x.Id == Id)
                .ExecuteUpdateAsync(u => u
                .SetProperty(b => b.Name, b => Name)
                .SetProperty(b => b.IdBoss, b => IdBoss)
                .SetProperty(b => b.IdAgragete, b => IdAgragete)
                .SetProperty(b => b.Type, b => type)
                .SetProperty(b => b.idUorD, b => IdUorD));

            await _context.SaveChangesAsync();
            return Id;
        }

        public async Task<_Task> GetTask(Guid IdTask)
        {
            var taskEntity = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == IdTask);

            if (taskEntity == null)
            {
                return null;
            }
            else
            {
                return _Task.CreateTask(
                    taskEntity.Id,
                    taskEntity.Name,
                    taskEntity.IdBoss,
                    taskEntity.IdAgragete,
                    taskEntity.Type,
                    taskEntity.idUorD).task;
            }
        }

        public async Task<List<_Task>> GetTasksForUser(Guid IdUser, Guid IdDepartment, int page)
        {
            var tasksEntity = await _context.Tasks.Where(x => (x.idUorD == IdUser) || (x.idUorD == IdDepartment)).Skip((page - 1) * 5).Take(5).ToListAsync();

            var tasks = tasksEntity.Select(b => _Task.CreateTask(b.Id, b.Name, b.IdBoss, b.IdAgragete, b.Type, b.idUorD).task).ToList();

            return tasks;
        }
    }
}

using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Types.Types;

namespace Api.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<List<_Task>> GetTasksForUser(Guid IdUser, Guid IdDepartment, int page)
        {
            var TasksList = await _tasksRepository.GetTasksForUser(IdUser, IdDepartment, page);

            return TasksList;
        }

        public async Task<_Task> GetTask(Guid IdTask)
        {
            var Task = await _tasksRepository.GetTask(IdTask);

            return Task;
        }


        public async Task<Guid> CreateTask(string Name, Guid IdBoss, Guid IdAgregate, TaskType Type, Guid idUorD)
        {
            var id = Guid.NewGuid();

            var task = _Task.CreateTask(id, Name, IdBoss, IdAgregate, Type, idUorD);

            if (task.error == "None")
            {
                return await _tasksRepository.AddTask(task.task);
            }
            else
            {
                throw new Exception(task.error);
            }

        }
    }
}


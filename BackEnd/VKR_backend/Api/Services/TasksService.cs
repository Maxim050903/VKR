using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<Guid> AddNewTask(_Task task)
        {
            await _tasksRepository.AddTask(task);

            return task.Id;
        }
    }
}

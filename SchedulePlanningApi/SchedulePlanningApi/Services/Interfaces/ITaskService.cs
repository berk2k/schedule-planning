﻿using SchedulePlanningApi.Models;
using SchedulePlanningApi.Models.DTOs;

namespace SchedulePlanningApi.Services.Interfaces
{
    public interface ITaskService
    {
        
        Task<List<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> GetTaskByIdAsync(int id);
        Task<TaskModel> CreateTaskAsync(CreateTaskDTO task);
        Task<TaskModel> UpdateTaskAsync(int id, UpdateTaskDTO task);
        Task<bool> DeleteTaskAsync(int id);
    }
}


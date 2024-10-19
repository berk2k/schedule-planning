using SchedulePlanningApi.Context;
using SchedulePlanningApi.Models.DTOs;
using SchedulePlanningApi.Models;
using SchedulePlanningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SchedulePlanningApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<TaskModel> CreateTaskAsync(CreateTaskDTO task)
        {
            try
            {
                var createdTask = new TaskModel
                {
                    Title = task.Title,
                    Description = task.Description,
                    CreatedDate = task.CreatedDate,
                    DueDate = task.DueDate,
                };

                await _context.Tasks.AddAsync(createdTask);
                await _context.SaveChangesAsync();

                return createdTask;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating task.", ex);
            }
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return false; 
                }

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting task.", ex);
            }
        }


        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            try
            {
                var tasks = await _context.Tasks.ToListAsync();

                return tasks;
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("An error occurred while finding tasks.", ex);

            }
            
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);

                if (task == null)
                {
                    throw new ApplicationException($"Finding task error id {id}");
                }
                return task;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while finding task.", ex);
            }
            
        }

        public async Task<TaskModel> UpdateTaskAsync(int id, UpdateTaskDTO task)
        {
            try
            {
                
                var existingTask = await _context.Tasks.FindAsync(id);
                if (existingTask == null)
                {
                    throw new ApplicationException($"Finding task error id {id}");
                }

                
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.IsDone = task.IsDone;
                existingTask.DueDate = task.DueDate;

                
                await _context.SaveChangesAsync();

                return existingTask; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating task.", ex);
            }
        }
    }
}

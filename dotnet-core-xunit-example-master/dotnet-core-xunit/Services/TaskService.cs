using AutoMapper;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Entities.TestDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Services
{
    public interface ITaskService
    {
        TaskDto.Task GetTask(int id);

        TaskDto.Task AddTask(TaskDto.Task task);

        TaskDto.Task UpdateTask(TaskDto.Task task);
        TaskDto.Task DeleteTask(int id);
    }

    public class TaskService : ITaskService
    {

        private TestDbContext _testDbContext;

        private IMapper _mapper;

        public TaskService(TestDbContext testDbContext, IMapper mapper)
        {
            _testDbContext = testDbContext;
            _mapper = mapper;
        }

        public TaskDto.Task AddTask(TaskDto.Task task)
        {
            try
            {
                Tasks tasks = _mapper.Map<Tasks>(task);

                _testDbContext.Tasks.Add(tasks);
                _testDbContext.SaveChanges();

                return _mapper.Map<TaskDto.Task>(tasks);
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public TaskDto.Task DeleteTask(int id)
        {
            Tasks tasks = _testDbContext.Tasks.Where(w => w.Id == id).FirstOrDefault();

            if (tasks == null)
                return null;

            _testDbContext.Tasks.Remove(tasks);
            _testDbContext.SaveChanges();

            return _mapper.Map<TaskDto.Task>(tasks);
        }

        public TaskDto.Task GetTask(int id)
        {
            Tasks tasks = _testDbContext.Tasks.Where(w => w.Id == id).FirstOrDefault();

            return _mapper.Map<TaskDto.Task>(tasks);
        }

        public TaskDto.Task UpdateTask(TaskDto.Task task)
        {
            Tasks task_ = _mapper.Map<Tasks>(task);
            Tasks tasks = _testDbContext.Tasks.Where(w => w.Id == task.Id).FirstOrDefault();


            if (tasks != null)
            {
                _testDbContext.Tasks.Remove(tasks);
                _testDbContext.SaveChanges();
                _testDbContext.Tasks.Add(task_);

                _testDbContext.SaveChanges();

            }
            return _mapper.Map<TaskDto.Task>(tasks);
        }
    }
}

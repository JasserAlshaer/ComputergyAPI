using ComputergyAPI.Contexts;
using ComputergyAPI.Entites;
using ComputergyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ComputergyAPI.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : MainEntity
    {
        private readonly ComputergyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ComputergyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
           await  _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();


        }
        public async Task<T> GetByIdAsync(int id)
        {
            var targetObj = await _dbSet.FindAsync(id);
            if (targetObj == null)
            {
                throw new Exception("Doesn't Exists");
            }

            return targetObj;
        }
        public async Task<T> DeleteAsync(int id)
        {
            var targetObj=await  GetByIdAsync(id);
            targetObj.IsActive = false;
            _dbSet.Update(targetObj);
            await _context.SaveChangesAsync();
            return targetObj;
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> objects2 = await _dbSet.ToListAsync();
            return objects2;
        }

        

        public async Task<bool> IsExistsAsync(int id)
        {
            var targetObj = await GetByIdAsync(id);
            return targetObj is not null;

        }

        public async Task<List<T>> SearchAsync(string keyword) 
        {
            List<T> result = new List<T>();

            var objects = await _dbSet.ToListAsync(); 

            foreach (var obj in objects)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.PropertyType == typeof(string)) 
                    {
                        var value = (string)prop.GetValue(obj);

                        if (!string.IsNullOrEmpty(value) && value.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(obj);
                            break;             
                        }
                    }
                }
            }

            return result;
        }




        public async Task<bool> UpdateAsync<T>(T entity)
        {
            var idProp = entity.GetType().GetProperty("Id");
            var id = (int)idProp.GetValue(entity);
            var existingObj = await GetByIdAsync(id);

            if (existingObj is null)
            {
                throw new Exception("Doesn't Exists");
            }
            foreach (var prop in entity.GetType().GetProperties())
            {
                var newValue = prop.GetValue(entity);
                if (newValue != null)
                {
                    prop.SetValue(existingObj, newValue);
                }
            }
            _dbSet.Update(existingObj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComputergyAPI.Services
{
    public class DiscountService : IDiscount
    {
        private readonly ComputergyDbContext _Context;
        public DiscountService(ComputergyDbContext computergyDbContext)
        {
            _Context = computergyDbContext;
        }
        public async Task<string> CreateDiscount(DiscountInputDTO input)
        {
            Discount discount = new Discount();
            discount.Title = input.Title;
            discount.StartDate = input.StartDate;
            discount.EndDate = input.EndDate;
            discount.Percentage = input.Percentage;
            discount.CreationDate = DateTime.Now;
            discount.CreatedBy = "System";
            discount.Description = input.Description;
            discount.ImageUrl = input.ImageUrl;
            discount.LimitAmount = input.LimitAmount;
            discount.LimitUser = input.LimitUser;   
            discount.Code= input.Code;
            _Context.Add(discount);
            _Context.SaveChanges();
            return "discount added sueccefully";

        }

        public async Task<bool> DeleteDiscount(int discountId)
        {
        
        
            var discount = await _Context.Discount.FindAsync(discountId);
            if (discount == null)
                return false;

            _Context.Discount.Remove(discount);
            await _Context.SaveChangesAsync();

            return true;
        
        }

        public async Task<List<DiscountDTO>> GetAllDiscount()
        {

            var discounts = _Context.Discount.ToList();

            var discountDTOs = discounts.Select(d => new DiscountDTO
            {

                Title = d.Title,
                Percentage = d.Percentage,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                Code=d.Code,


            }).ToList();




            return discountDTOs;
        }

        public async Task<string> UpdateDiscount(int discountId, DiscountInputDTO input)
        {
            var discount = await _Context.Discount.FindAsync(discountId);
            if (discount == null)
                return "Discount not found";

            discount.Title = input.Title;
            discount.Percentage = input.Percentage;
            discount.StartDate = input.StartDate;
            discount.EndDate = input.EndDate;
            discount.Code = input.Code; 

            discount.ImageUrl=input.ImageUrl;
            discount.Description= input.Description;
            discount.LimitUser = input.LimitUser;
            discount.LimitAmount = input.LimitAmount;

            _Context.Update(discount);
            _Context.SaveChangesAsync();
            return "Discount updated successfully";
        }



        Task<DiscountDTO> IDiscount.GetAllDiscount()
        {
            throw new NotImplementedException();
        }


    }
    }


    

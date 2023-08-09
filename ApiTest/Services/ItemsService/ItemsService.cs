using ApiTest.Data;
using ApiTest.Dtos.Items;
using ApiTest.Models;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Services.ItemsService
{
    public class ItemsService : IItemsService
    {

        private readonly TestdbContext _context;
        private readonly IMapper _mapper;

        public ItemsService(TestdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
             
        public async Task<ServiceResponse<List<GetItemsDto>>> GetItems()
        {
            var serviceResponse = new ServiceResponse<List<GetItemsDto>>();
         

            try
            {
                var dbItems =  _context.Items.ToList();
               

                serviceResponse.Data = _mapper.Map<List<GetItemsDto>>(dbItems);
                
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return null;
            }



        }

        public async Task<ServiceResponse<List<GetItemsDto>>> AddItem(AddItemsDto newItem)
        {
            var serviceResponse = new ServiceResponse<List<GetItemsDto>>();
            try
            {
                var it = _mapper.Map<Item>(newItem);

                _context.Items.Add(it);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<List<GetItemsDto>>(_context.Items.ToList());

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return null;
            }

        }

        public async Task<ServiceResponse<List<GetItemsDto>>> DeleteItem(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetItemsDto>>();

            try
            {
                var it = await _context.Items
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (it is null)
                    throw new Exception($"Item with Id '{id}' not found.");

                _context.Items.Remove(it);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<List<GetItemsDto>>(_context.Items.ToList());

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return null;
            }


        }

        public async Task<ServiceResponse<List<GetItemsDto>>> UpdateItem(UpdateItemDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetItemsDto>>();

            var item = await _context.Items.FindAsync(request.Id);
            if (item is null)
                return null;

            item.ItemState = request.itemState;
            
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<List<GetItemsDto>>(_context.Items.ToList());
            return serviceResponse;
            throw new NotImplementedException();
        }
    }
}

using ApiTest.Dtos.Items;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Services.ItemsService
{
    public interface IItemsService
    {
        Task<ServiceResponse<List<GetItemsDto>>> GetItems();
        Task<ServiceResponse<List<GetItemsDto>>> AddItem(AddItemsDto newItem);
        Task<ServiceResponse<List<GetItemsDto>>> DeleteItem(int id);
        Task<ServiceResponse<List<GetItemsDto>>> UpdateItem(UpdateItemDto newItem);
    }
}

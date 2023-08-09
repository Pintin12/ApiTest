using ApiTest.Data;
using ApiTest.Dtos.Items;
using ApiTest.Models;
using ApiTest.Services.ItemsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        private readonly ILogger<ItemsController> _logger;

        public ItemsController(ILogger<ItemsController> logger, IItemsService itemsService)
        {
            _logger = logger;
            _itemsService = itemsService;
        }

        [HttpGet("GetItems")]
        public async Task<ActionResult<ServiceResponse<List<GetItemsDto>>>> GetItems()
        {
            return Ok(_itemsService.GetItems());
        }

        [HttpPost("CreateItem")]
        public async Task<ActionResult<ServiceResponse<List<GetItemsDto>>>> AddItem(AddItemsDto newItem)
        {
            return Ok(await _itemsService.AddItem(newItem));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetItemsDto>>> DeleteItem(int id)
        {
            var response = await _itemsService.DeleteItem(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
        [HttpPut("UpdateItem")]
        public async Task<ActionResult<ServiceResponse<GetItemsDto>>> UpdateItem(UpdateItemDto newItem)
        {
            var response = await _itemsService.UpdateItem(newItem);
            if (response is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
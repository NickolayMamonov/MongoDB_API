using Microsoft.AspNetCore.Mvc;
using MongoDB_API.DTO;
using MongoDB_API.Models;
using MongoDB_API.Services;

namespace MongoDB_API.Controllers;

[ApiController]
[Route("api/videocards")]
public class VideocardsController:ControllerBase
{
    private readonly VideocardService _service;

    public VideocardsController(VideocardService service)
    {
        _service = service;
    }

    [HttpPost("addNewVideocard")]
    public async Task<ActionResult> AddNewVideocard(VideocardDto videocardDto)
    {
        var videocard = new Videocard()
        {
            Vendor = videocardDto.Vendor,
            Name = videocardDto.Name,
            Capacity = videocardDto.Capacity
        };
        
        await _service.CreateNewVideocardAsync(videocard);
        
        return Ok(videocard);
    }

    [HttpGet("getVideocardById/{id:length(24)}")]
    public async Task<ActionResult> GetVideocardById(string id)
    {
        var result = await _service.GetVideocardByIdAsync(id);

        if (result!=null)
        {
            return Ok(result);
        }

        return BadRequest("not found");
    }

    [HttpGet("getVideocards")]
    public async Task<ActionResult> GetVideocards()
    {
        var result = await _service.GetVideocardsAsync();
        
        return Ok(result);
    }

    [HttpPut("updateVideocard")]
    public async Task<ActionResult> UpdateVideocard(Videocard videocard)
    { 
        await _service.UpdateVideocardAsync(videocard);

        return Ok(videocard);
    }

    [HttpDelete("deleteVideocard{id:length(24)}")]
    public async Task<ActionResult> DeleteVideocard(string id)
    {
        var result = await _service.GetVideocardByIdAsync(id);
        await _service.DeleteVideocardAsync(id);

        return Ok(result);
    }
}
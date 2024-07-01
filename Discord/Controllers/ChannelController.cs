using Discord.Dtos.Channel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Discord.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly IDiscordApi _discordApi;
    private readonly AuthorizationToken _authorizationToken;

    public ChannelController(IDiscordApi discordApi, IOptions<AuthorizationToken> authorizationToken)
    {
        _discordApi = discordApi;
        _authorizationToken = authorizationToken.Value;
    }

    [HttpGet("get_all_guild_channels")]
    public async Task<ActionResult<List<GetAllChannelsResponse>>> GetGuildChannelsAsync(string guildId)
    {
        var channels  = await _discordApi.GetChannelsAsync(guildId, _authorizationToken.Token);
        return Ok(channels);
    }

    [HttpGet("get_by_id_channel")]
    public async Task<ActionResult<GetByIdChannelResponse>> GetChannelByIdAsync(string channelId)
    {
        var channel = await _discordApi.GetChannelAsync(channelId, _authorizationToken.Token);
        return Ok(channel);
    }

    [HttpPost("create_channel")]
    public async Task<ActionResult<CreateChannelResponse>> CreateChannelAsync(string guildId, [FromBody] CreateChannelRequest channel)
    {
        var createdChannel = await _discordApi.CreateChannelAsync(guildId, channel,  _authorizationToken.Token);
        return Ok(createdChannel);
    }
    
    [HttpPatch("update_channel")]
    public async Task<ActionResult<UpdateChannelResponse>> UpdateChannelAsync(string channelId, [FromBody] UpdateChannelRequest channel)
    {
        var updatedChannel = await _discordApi.UpdateChannelAsync(channelId, channel, _authorizationToken.Token);
        return Ok(updatedChannel);
    }
    
    [HttpDelete("delete_channel")]
    public async Task<ActionResult> DeleteChannelAsync(string channelId)
    {
        await _discordApi.DeleteChannelAsync(channelId, _authorizationToken.Token);
        return NoContent();
    }
}
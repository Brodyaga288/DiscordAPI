using Discord.Dtos.Guild;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Discord.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuildsController : ControllerBase
{
    private readonly IDiscordApi _discordApi;
    private readonly AuthorizationToken _authorizationToken;

    public GuildsController(IDiscordApi discordApi, IOptions<AuthorizationToken> authorizationToken)
    {
        _discordApi = discordApi;
        _authorizationToken = authorizationToken.Value;
    }

    [HttpGet("get_all_guilds")]
    public async Task<ActionResult<List<GetAllGuildsResponse>>> GetGuilds()
    {
        var guilds = await _discordApi.GetGuildsAsync(_authorizationToken.Token);
        return Ok(guilds);
    }

    [HttpGet("get_by_id_guild")]
    public async Task<ActionResult<GetByIdGuildResponse>> GetGuild(string guildId)
    {
        var guild = await _discordApi.GetGuildAsync(guildId, _authorizationToken.Token);
        return Ok(guild);
    }
  
    [HttpPost("create_guild")]
    public async Task<ActionResult<CreateGuildResponse>> CreateGuild([FromBody] CreateGuildRequest guild)
    {
        var createdGuild = await _discordApi.CreateGuildAsync(guild, _authorizationToken.Token);
        return Ok(createdGuild);
    }

    [HttpPatch("update_guild")]
    public async Task<ActionResult<UpdateGuildResponse>> UpdateGuild(string guildId, [FromBody] UpdateGuildRequest guild)
    {
        var updatedGuild = await _discordApi.UpdateGuildAsync(guildId, guild, _authorizationToken.Token);
        return Ok(updatedGuild);
    }

    [HttpDelete("delete_guild")]
    public async Task<ActionResult> DeleteGuild(string guildId)
    {
        await _discordApi.DeleteGuildAsync(guildId, _authorizationToken.Token);
        return NoContent();
    }
}
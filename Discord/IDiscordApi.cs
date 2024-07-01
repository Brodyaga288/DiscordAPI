using Discord.Dtos.Guild;
using Discord.Dtos.Channel;
using Microsoft.AspNetCore.Mvc;
using Refit;
namespace Discord;

public interface IDiscordApi
{
    [Get("/users/@me/guilds")]
    public Task<List<GetAllGuildsResponse>> GetGuildsAsync([Header("Authorization")] string authorization);
    
    [Get("/guilds/{guildId}")]
    public Task<GetByIdGuildResponse> GetGuildAsync(string guildId, [Header("Authorization")] string authorization);
    
    [Post("/guilds")]
    public Task<CreateGuildResponse> CreateGuildAsync([FromBody] CreateGuildRequest guild, [Header("Authorization")] string authorization);

    [Patch("/guilds/{guildId}")]
    public Task<UpdateGuildResponse> UpdateGuildAsync(string guildId, [FromBody] UpdateGuildRequest guild, [Header("Authorization")] string authorization);

    [Delete("/guilds/{guildId}")]
    public Task DeleteGuildAsync(string guildId, [Header("Authorization")] string authorization);
  
    [Get("/guilds/{guildId}/channels")]
    public Task<List<GetAllChannelsResponse>> GetChannelsAsync(string guildId, [Header("Authorization")] string authorization);

    [Get("/channels/{channelId}")]
    public Task<GetByIdChannelResponse> GetChannelAsync(string channelId, [Header("Authorization")] string authorization);

    [Post("/guilds/{guildId}/channels")]
    public Task<CreateChannelResponse> CreateChannelAsync(string guildId, [FromBody] CreateChannelRequest channel, [Header("Authorization")] string authorization);

    [Patch("/channels/{channelId}")]
    public Task<UpdateChannelResponse> UpdateChannelAsync(string channelId, [FromBody] UpdateChannelRequest channel, [Header("Authorization")] string authorization);

    [Delete("/channels/{channelId}")]
    public Task DeleteChannelAsync(string channelId, [Header("Authorization")] string authorization);
}
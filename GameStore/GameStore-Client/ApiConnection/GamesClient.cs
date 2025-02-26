using System;
using GameStore_Client.ApiConnection.Dtos;

namespace GameStore_Client.ApiConnection;

public class GamesClient(HttpClient httpClient)
{
    public async Task<List<GameDto>> GetGamesAsync() => await httpClient.GetFromJsonAsync<List<GameDto>>("games") ?? [];
}

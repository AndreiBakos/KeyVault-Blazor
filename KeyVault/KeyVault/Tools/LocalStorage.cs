using KeyVault.Data;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace KeyVault.Tools;

public class LocalStorage
{
    public async Task<object> Get<T>(IJSRuntime jsRuntime, StorageData name)
    {
        var data = await jsRuntime.InvokeAsync<string>("localStorage.getItem", name);
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        if (typeof(T) == typeof(string))
        {
            return data;
        }

        var parsedResponse = JsonConvert.DeserializeObject<T>(data);
        if (parsedResponse == null)
        {
            return null;
        }

        return parsedResponse;
    }
    public async Task Set(IJSRuntime jsRuntime, StorageData name, string value)
    {
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", name, value);
    }
    
    public async Task Remove(IJSRuntime jsRuntime, StorageData name)
    {
        await jsRuntime.InvokeVoidAsync("localStorage.removeItem", name);
    }
}
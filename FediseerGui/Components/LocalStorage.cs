using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace FediseerGui.Components;

public class LocalStorage
{
    //private readonly ProtectedBrowserStorage storage;

    //public ApiKey(ProtectedBrowserStorage storage)
    //{
    //    this.storage = storage;
    //}

    private string? Value { get; set; }
    public bool KeyIsValid => !string.IsNullOrEmpty(Value);

    public async Task<string?> GetValueAsync()
    {
        return Value;
        //if (Value is not null)
        //    return Value;
        //var v = await storage.GetAsync<string>("fediseertoken");
        //if (!v.Success || string.IsNullOrEmpty(v.Value))
        //{
        //    Value = null;
        //    return null;
        //}
        //else
        //{
        //    Value = v.Value;
        //    return Value;
        //}
    }

    public Task SetValue(string Key)
    {
        //await storage.SetAsync("fediseertoken", Key);
        Value = Key;

        Console.WriteLine("Key Set To " + Key);

        return Task.CompletedTask;
    }
}
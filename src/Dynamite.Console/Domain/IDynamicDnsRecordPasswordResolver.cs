namespace Dynamite.Console.Domain
{
    public interface IDynamicDnsRecordPasswordResolver
    {
        string Resolve(string label);
    }
}
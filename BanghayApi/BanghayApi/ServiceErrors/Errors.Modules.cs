using ErrorOr;
namespace BanghayApi.ServiceErrors;


public static class Errors
{
    public static class Module // this is the part which represents all the errors in our system
    {
        public static Error NotFound => Error.NotFound( // this method originates from ErrorOr package. Returns what error is currently happening to the process.
            code: "Module.NotFound",
            description: "Module not not found!"
        );
    }
}
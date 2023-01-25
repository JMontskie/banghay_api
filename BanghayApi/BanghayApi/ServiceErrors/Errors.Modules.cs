using ErrorOr;
namespace BanghayApi.ServiceErrors;


public static class Errors
{
    public static class Module // this is the part which represents all the errors in our system
    {
        public static Error InvalidName => Error.Validation( // this method originates from ErrorOr package. Returns what 404 Not Found.
            code: "Module.InvalidName",
            description: $"Module name must be at least {Models.Module.MinNameLength}" +
                        $" characters long and at most {Models.Module.MaxNameLength}");

        public static Error InvalidDescription => Error.Validation( // this method originates from ErrorOr package. Returns what 404 Not Found.
            code: "Module.InvalidDescription",
            description: $"Module description must be at least {Models.Module.MinDescriptionLength}" + 
                        $" characters long and at most {Models.Module.MaxDescriptionLength}");

         public static Error NotFound => Error.NotFound( // this method originates from ErrorOr package. Returns what 404 Not Found.
            code: "Module.NotFound",
            description: "Module not not found!");
    }
}
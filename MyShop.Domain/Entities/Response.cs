namespace MyShop.Domain.Entities
{ 
    public record Response<T>(bool success, T? data, string? message, IEnumerable<string>? errors)
    {
        public static Func<T, string?, Response<T>> Success => (data, message) => new(true, data, message, null);
        public static Func<string?, Response<T>> Fail => message => new(false, default, message, Enumerable.Empty<string>());
        public static Func<string, IEnumerable<string>, Response<T>> FailWithErrors => (message, errors) => new(false, default, message, errors);
    }
}

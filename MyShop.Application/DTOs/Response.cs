namespace MyShop.Application.DTOs
{
    public record Response<T>(bool success, T? data, string? message, IEnumerable<string>? errors)
    {
        public static Response<T> Success(T data, string? message = null)
            => new(true, data, message, null);

        public static Response<T> Fail(string? message)
            => new(false, default, message, Enumerable.Empty<string>());

        public static Response<T> FailWithErrors(string message, IEnumerable<string> errors)
            => new(false, default, message, errors);
    }
}

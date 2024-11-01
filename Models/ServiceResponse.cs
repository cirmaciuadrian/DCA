﻿namespace DCA.Models;

public sealed class ServiceResponse<T>
{
    public bool IsSuccess { get; set; } = true;
    public string ErrorMessage { get; set; } = string.Empty;
    public T Response { get; set; } = default(T)!;
}

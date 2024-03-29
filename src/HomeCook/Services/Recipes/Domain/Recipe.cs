﻿namespace Domain;

public record Recipe
{
    public Guid Id { get; internal set; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string AuthorEmail { get; init; }
    public Guid MainPhotoId { get; init; }
}